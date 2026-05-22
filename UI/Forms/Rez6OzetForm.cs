using System.Linq;
using System;
using System.Globalization;
using System.Windows.Forms;
using oceangate_r.Core;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;

namespace oceangate_r
{
    /// <summary>
    /// Rezervasyon Adım 6 ? Özet ve Onay.
    /// RezervasyonContext'ten t?m verileri al?r, Özetler ve DB'ye kaydeder.
    /// </summary>
    public partial class Rez6OzetForm : Form
    {
        private readonly Form _oncekiForm;

        public Rez6OzetForm(Form oncekiForm)
        {
            _oncekiForm = oncekiForm;
            InitializeComponent();
            OzetiDoldur();
        }

        // ?? Özet Verilerini Doldur ????????????????????????????????????????????

        private void OzetiDoldur()
        {
            var bolge = RezervasyonContext.SeciliBolge;
            var sefer = RezervasyonContext.SeciliSefer;
            var tarih = RezervasyonContext.SeferTarihi;
            int kişi  = RezervasyonContext.KisiSayisi;
            var odalar = RezervasyonContext.SeciliOdalar;

            string koltukStr = RezervasyonContext.KoltukAtamalar.Count > 0
                ? string.Join(", ", RezervasyonContext.KoltukAtamalar.ConvertAll(a => a.KoltukNo.ToString()))
                : "?";

            string odaStr = (odalar != null && odalar.Count > 0)
                ? $"Oda {odalar[0].OdaNo}  ({odalar.Sum(o => o.Kapasite)} kişilik)"
                : "Oda rezervasyonu yok";

            double toplam = sefer != null ? sefer.FiyatKisiBasiTL * kişi : 0;

            lblBolge.Text      = bolge?.Ad ?? "?";
            lblSefer.Text      = bolge?.Ad ?? "?";
            lblSaat.Text       = sefer?.KalkisSaati ?? "?";
            lblSure.Text       = sefer?.SureMetni ?? "?";
            lblTarih.Text      = tarih.ToString("dd MMMM yyyy dddd", new CultureInfo("tr-TR"));
            lblKisi.Text       = $"{kişi} kişi";
            lblKoltuklar.Text  = koltukStr;
            lblOda.Text        = odaStr;
            lblBirimFiyat.Text = $"{sefer?.FiyatKisiBasiTL:N0} TL / kişi";
            lblToplam.Text     = $"{toplam:N0} TL";
        }

        // ?? Olay ??leyicileri ????????????????????????????????????????????????

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            var sefer  = RezervasyonContext.SeciliSefer;
            double top = sefer.FiyatKisiBasiTL * RezervasyonContext.KisiSayisi;
            string dNo = DatabaseManager.YeniDekontNo();

            var rez = new Rezervasyon
            {
                KullaniciId       = SessionManager.AktifKullanici.Id,
                SeferId           = RezervasyonContext.SeciliSefer.Id,
                KisiSayisi        = RezervasyonContext.KisiSayisi,
                ToplamTutar       = top,
                RezervasyonTarihi = DateTime.Now,
                SeferTarihi       = RezervasyonContext.SeferTarihi,
                Durum             = "Onaylandi",
                DekontNo          = dNo,
                SeferBilgisi      = $"{RezervasyonContext.SeciliBolge.Ad} ? {RezervasyonContext.SeciliSefer.KalkisSaati}",
                KullaniciAdi      = SessionManager.AktifKullanici.KullaniciAdi,
            };

            RezervasyonDAL.Ekle(rez);

            var yeniRez = RezervasyonDAL.KullanicininRezervasyonlari(SessionManager.AktifKullanici.Id);
            if (yeniRez.Count > 0)
            {
                int rezId = yeniRez[0].Id;
                KoltukDAL.KoltuklariKaydet(
                    rezId,
                    RezervasyonContext.SeciliSefer.Id,
                    RezervasyonContext.SeferTarihi,
                    RezervasyonContext.KoltukAtamalar);

                if (RezervasyonContext.SeciliOdalar != null)
                    foreach (var o in RezervasyonContext.SeciliOdalar)
                        OtelOdaDAL.OdaKaydet(rezId, o.Id,
                            RezervasyonContext.SeciliSefer.Id,
                            RezervasyonContext.SeferTarihi);
            }

            using (var dekont = new DekontForm(rez))
                dekont.ShowDialog(this);

            // Context temizle ve wizard'? kapat; geri d?n?? UserDashboard'dan gelir
            RezervasyonContext.Sifirla();
            KapatVeDashboaraDon();
        }

        /// <summary>
        /// T?m wizard zincirini (Rez1-Rez5) kapat?r ve UserDashboard'? g?sterir.
        /// </summary>
        private void KapatVeDashboaraDon()
        {
            // _oncekiForm ? Rez5OdaForm ? Rez4KoltukForm ? ... ? Rez1BolgeForm
            // Rez1BolgeForm'un _oncekiForm'u UserDashboard'dur.
            // Basit y?ntem: t?m Rez* formlar?n? bul ve kapat
            foreach (Form f in Application.OpenForms)
            {
                if (f is UserDashboard dash)
                {
                    dash.Show();
                    break;
                }
            }
            // Geri kalan Rez* formlar?n? kapat (Close bu formdan sonra zaten ?a?r?lacak)
            _oncekiForm?.Close();
            Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            _oncekiForm?.Show();
            Close();
        }
    }
}




