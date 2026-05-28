using System;
using System.Collections.Generic;
using System.Windows.Forms;
using oceangate_r.Core;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;

namespace oceangate_r
{

    public partial class Rez4KoltukForm : Form
    {
        private readonly Form _oncekiForm;

        public Rez4KoltukForm(Form oncekiForm)
        {
            _oncekiForm = oncekiForm;
            InitializeComponent();

            int kapasite     = RezervasyonContext.SeciliSefer?.KapasiteSayisi ?? 20;
            var doluAtamalar = KoltukDAL.DoluKoltuklariGetir(
                RezervasyonContext.SeciliSefer.Id,
                RezervasyonContext.SeferTarihi);

            var mevcutDurumlar = doluAtamalar.ConvertAll(a => new Koltuk
            {
                No    = a.KoltukNo,
                Durum = a.Cinsiyet == "Kadin" ? KoltukDurum.DoluKadin : KoltukDurum.DoluErkek,
            });

            koltukSecimPanel1.Baslat(kapasite, mevcutDurumlar);
            koltukSecimPanel1.SecimDegisti += seciliKoltuklar =>
            {
                lblSecimBilgi.Text = $"Seçilen koltuk say-s-: {seciliKoltuklar.Count}  (Maks 4)";
            };
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            int secilen = koltukSecimPanel1.SeciliKoltuklar.Count;
            if (secilen == 0)
            {
                MessageBox.Show("Lütfen en az 1 koltuk seçiniz.", "Koltuk Seçimi Eksik",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RezervasyonContext.KisiSayisi     = secilen;
            RezervasyonContext.KoltukAtamalar = koltukSecimPanel1.SeciliAtamalar;

            var form5 = new Rez5OdaForm(this);
            form5.Show();
            Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            _oncekiForm?.Show();
            Close();
        }

        private void lblSecimBilgi_Click(object sender, EventArgs e)
        {

        }
    }
}
