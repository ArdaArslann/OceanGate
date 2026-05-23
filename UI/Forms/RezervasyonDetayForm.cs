using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>
    /// Rezervasyon detayı ve talep oluşturma formu (modal dialog).
    /// </summary>
    public partial class RezervasyonDetayForm : Form
    {
        private readonly Rezervasyon _rez;

        public RezervasyonDetayForm(Rezervasyon rez)
        {
            _rez = rez;
            InitializeComponent();
            _cbTip.SelectedIndexChanged += (s, e) =>
            {
                _dtpYeni.Visible = _cbTip.SelectedIndex == 1;
            };
            _btnGonder.Click += BtnGonder_Click;

            // Bilgi kartını çalışma zamanında doldur
            BuildInfoRows();

            // Sadece Onaylandi ise talep bölümünü göster
            if (_rez.Durum != "Onaylandi")
            {
                this.Size = new Size(700, 420);
                _lblTalepBaslik.Visible = false;
                _lblTip.Visible    = false;
                _cbTip.Visible     = false;
                _lblYeniTarih.Visible = false;
                _dtpYeni.Visible   = false;
                _lblAc.Visible     = false;
                _txtAc.Visible     = false;
                _btnGonder.Visible = false;

                var lblUyari = UIHelper.MakeLabel(
                    "Bu rezervasyon için talep oluşturulamaz.",
                    AppTheme.BodyFont, AppTheme.TextMuted, 24, 400, 400, 24);
                Controls.Add(lblUyari);
            }
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }

        private void BuildInfoRows()
        {
            var satirlar = new (string K, string V, Color C)[]
            {
                ("Dekont No",    _rez.DekontNo,                    AppTheme.Accent),
                ("Sefer",        _rez.SeferBilgisi,                AppTheme.TextLight),
                ("Sefer Tarihi", _rez.SeferTarihiStr,              AppTheme.TextLight),
                ("Rez. Tarihi",  _rez.RezervasyonTarihiStr,        AppTheme.TextLight),
                ("Kişi Sayısı",  $"{_rez.KisiSayisi} kişi",        AppTheme.TextLight),
                ("Toplam Tutar", _rez.ToplamTutarStr,              AppTheme.Warning),
                ("Durum",        UIHelper.DurumMetni(_rez.Durum),  UIHelper.DurumRengi(_rez.Durum)),
            };

            int sy = 14;
            foreach (var (k, v, c) in satirlar)
            {
                var lk = UIHelper.MakeLabel(k, AppTheme.SmallFont, AppTheme.TextMuted, 16, sy, 180, 28);
                var lv = UIHelper.MakeLabel(v, AppTheme.BodyBold, c, 200, sy, 430, 28);
                _card.Controls.Add(lk);
                _card.Controls.Add(lv);
                sy += 40;
            }
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            string tip;
            switch (_cbTip.SelectedIndex)
            {
                case 0:  tip = "Iptal";      break;
                case 1:  tip = "Degisiklik"; break;
                default: tip = "Diger";      break;
            }

            var talep = new Talep
            {
                RezervasyonId   = _rez.Id,
                KullaniciId     = SessionManager.AktifKullanici.Id,
                TalepTipi       = tip,
                Aciklama        = _txtAc.Text.Trim(),
                YeniSeferTarihi = (_cbTip.SelectedIndex == 1) ? _dtpYeni.Value.ToString("o") : "",
            };

            TalepDAL.Ekle(talep);

            if (tip == "Iptal")
                RezervasyonDAL.DurumGuncelle(_rez.Id, "IptalOnayBekliyor");
            else if (tip == "Degisiklik")
                RezervasyonDAL.DurumGuncelle(_rez.Id, "DegisiklikOnayBekliyor");
            else
                RezervasyonDAL.DurumGuncelle(_rez.Id, "DigerOnayBekliyor");

            MessageBox.Show("Talebiniz Admin'e iletildi. Onay bekleyiniz.",
                "Talep Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
