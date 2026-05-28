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
 
    public partial class Rez6OzetForm : Form
    {
        private readonly Form _oncekiForm;

        public Rez6OzetForm(Form oncekiForm)
        {
            _oncekiForm = oncekiForm;
            InitializeComponent();
            OÖzetiDoldur();
        }


        private void OÖzetiDoldur()
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


        private void btnOnayla_Click(object sender, EventArgs e)
        {
            var sefer  = RezervasyonContext.SeciliSefer;
            double top = sefer.FiyatKisiBasiTL * RezervasyonContext.KisiSayisi;
            
            double guncelBakiye = KullaniciDAL.BakiyeGetir(SessionManager.AktifKullanici.Id);
            if (guncelBakiye < top)
            {
                MessageBox.Show($"Yetersiz bakiye!\n\nToplam Tutar: {top:N0} TL\nMevcut Bakiyeniz: {guncelBakiye:N0} TL\n\nLütfen Kullanıcı Paneli'nden bakiye yükleyiniz.", "Yetersiz Bakiye", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                var rezForms = System.Windows.Forms.Application.OpenForms.Cast<System.Windows.Forms.Form>().Where(x => x.Name.StartsWith("Rez")).ToList();
                foreach (var f in rezForms) f.Close();
                
                var ud = System.Windows.Forms.Application.OpenForms.OfType<UserDashboard>().FirstOrDefault();
                ud?.Show();
                return;
            }

            KullaniciDAL.BakiyeDus(SessionManager.AktifKullanici.Id, top);
            SessionManager.AktifKullanici.Bakiye = KullaniciDAL.BakiyeGetir(SessionManager.AktifKullanici.Id);

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
                SeferBilgisi      = $"{RezervasyonContext.SeciliBolge.Ad} - {RezervasyonContext.SeciliSefer.KalkisSaati}",
                KullaniciAdi      = SessionManager.AktifKullanici.KullaniciAdi,
            };

            int rezId = RezervasyonDAL.Ekle(rez);
            if (rezId > 0)
            {
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

            RezervasyonContext.Sifirla();
            KapatVeDashboaraDon();
        }

      
        private void KapatVeDashboaraDon()
        {
            UserDashboard dashboard = null;
            foreach (Form f in Application.OpenForms)
            {
                if (f is UserDashboard d)
                {
                    dashboard = d;
                    break;
                }
            }

            var rezForms = Application.OpenForms
                .Cast<Form>()
                .Where(f => f.Name.StartsWith("Rez"))
                .ToList();

            foreach (var f in rezForms)
                if (!f.IsDisposed) f.Close();

            if (dashboard != null && !dashboard.IsDisposed)
                dashboard.Yenile();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            _oncekiForm?.Show();
            Close();
        }
    }
}




