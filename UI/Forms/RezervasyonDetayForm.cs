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
    public class RezervasyonDetayForm : Form
    {
        private readonly Rezervasyon _rez;

        public RezervasyonDetayForm(Rezervasyon rez)
        {
            _rez = rez;
            BackColor       = AppTheme.BgDark;
            ForeColor       = AppTheme.TextLight;
            Font            = AppTheme.BodyFont;
            FormBorderStyle = FormBorderStyle.None;
            Size            = new Size(700, 680); // Varsayılan tam boyut
            StartPosition   = FormStartPosition.CenterParent;
            DoubleBuffered  = true;

            BuildUI();
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }

        private void BuildUI()
        {
            // Başlık
            var titleBar = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(700, 50),
                BackColor = AppTheme.BgSidebar,
            };
            UIHelper.EnableDrag(titleBar, this);

            var lblTitle = UIHelper.MakeLabel("Rezervasyon Detayı", AppTheme.SubFont,
                AppTheme.TextLight, 20, 0, 400, 50);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            var btnKapat = new Button
            {
                Text      = "",
                Font      = AppTheme.BodyFont,
                ForeColor = AppTheme.TextMuted,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(654, 0),
                Size      = new Size(46, 50),
                Cursor    = Cursors.Hand,
            };
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Click += (s, e) => Close();
            titleBar.Controls.AddRange(new Control[] { lblTitle, btnKapat });

            // Bilgi kartı
            var card = UIHelper.MakeCard(24, 64, 652, 320, AppTheme.BgCard);

            var satirlar = new (string, string, Color)[]
            {
                ("Dekont No",    _rez.DekontNo,                       AppTheme.Accent),
                ("Sefer",        _rez.SeferBilgisi,                   AppTheme.TextLight),
                ("Sefer Tarihi", _rez.SeferTarihiStr,                  AppTheme.TextLight),
                ("Rez. Tarihi",  _rez.RezervasyonTarihiStr,           AppTheme.TextLight),
                ("Kişi Sayısı",  $"{_rez.KisiSayisi} kişi",           AppTheme.TextLight),
                ("Toplam Tutar", _rez.ToplamTutarStr,                  AppTheme.Warning),
                ("Durum",        UIHelper.DurumMetni(_rez.Durum),     UIHelper.DurumRengi(_rez.Durum)),
            };

            int sy = 14;
            foreach (var (k, v, c) in satirlar)
            {
                var lk = UIHelper.MakeLabel(k, AppTheme.SmallFont, AppTheme.TextMuted, 16, sy, 180, 28);
                var lv = UIHelper.MakeLabel(v, AppTheme.BodyBold, c, 200, sy, 430, 28);
                card.Controls.Add(lk);
                card.Controls.Add(lv);
                sy += 40;
            }

            if (_rez.Durum != "Onaylandi")
            {
                Size = new Size(700, 420);
                var lblUyari = UIHelper.MakeLabel("Bu rezervasyon için talep oluşturulamaz.", AppTheme.BodyFont, AppTheme.TextMuted, 24, 400, 400, 24);
                Controls.AddRange(new Control[] { titleBar, card, lblUyari });
                return;
            }

            // Talep bölümü başlığı
            var lblTalepBaslik = UIHelper.MakeLabel("Talep Oluştur", AppTheme.SubFont,
                AppTheme.TextLight, 24, 400, 300, 32);

            // Talep tipi seçimi
            var lblTip = UIHelper.MakeLabel("Talep Türü:", AppTheme.BodyFont,
                AppTheme.TextMuted, 24, 442, 120, 28);
            var cbTip = new ComboBox
            {
                Location      = new Point(150, 440),
                Size          = new Size(260, 32),
                BackColor     = AppTheme.BgCard,
                ForeColor     = AppTheme.TextLight,
                Font          = AppTheme.BodyFont,
                FlatStyle     = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            cbTip.Items.AddRange(new object[] { "İptal ve İade", "Tarih Değişikliği", "Diğer" });
            cbTip.SelectedIndex = 0;

            // Yeni tarih (tarih değişikliği için)
            var lblYeniTarih = UIHelper.MakeLabel("Yeni Tarih:", AppTheme.BodyFont,
                AppTheme.TextMuted, 24, 490, 120, 28);
            var dtpYeni = new DateTimePicker
            {
                Location  = new Point(150, 488),
                Size      = new Size(260, 32),
                MinDate   = DateTime.Today.AddDays(1),
                Font      = AppTheme.BodyFont,
                Visible   = false,
            };

            cbTip.SelectedIndexChanged += (s, e) =>
            {
                dtpYeni.Visible = cbTip.SelectedIndex == 1;
            };

            // Açıklama
            var lblAc = UIHelper.MakeLabel("Açıklama:", AppTheme.BodyFont,
                AppTheme.TextMuted, 24, 536, 120, 28);
            var txtAc = new TextBox
            {
                Location    = new Point(150, 534),
                Size        = new Size(526, 52),
                BackColor   = AppTheme.BgCard,
                ForeColor   = AppTheme.TextLight,
                Font        = AppTheme.BodyFont,
                BorderStyle = BorderStyle.None,
                Multiline   = true,
            };

            // Gönder butonu
            var btnGonder = UIHelper.MakeButton("Talep Gönder", 24, 610, 280, 46);
            btnGonder.SetSuccess();

            btnGonder.Click += (s, e) =>
            {
                string tip;
                switch (cbTip.SelectedIndex)
                {
                    case 0: tip = "Iptal"; break;
                    case 1: tip = "Degisiklik"; break;
                    default: tip = "Diger"; break;
                }

                var talep = new Talep
                {
                    RezervasyonId   = _rez.Id,
                    KullaniciId     = SessionManager.AktifKullanici.Id,
                    TalepTipi       = tip,
                    Aciklama        = txtAc.Text.Trim(),
                    YeniSeferTarihi = (cbTip.SelectedIndex == 1) ? dtpYeni.Value.ToString("o") : "",
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
            };

            Controls.AddRange(new Control[]
            {
                titleBar, card, lblTalepBaslik,
                lblTip, cbTip, lblYeniTarih, dtpYeni,
                lblAc, txtAc, btnGonder,
            });
        }
    }
}
