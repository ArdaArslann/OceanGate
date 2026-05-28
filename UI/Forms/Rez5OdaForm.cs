using System.Linq;
using System;
using System.Windows.Forms;
using oceangate_r.Core;
using oceangate_r.Entities;
using oceangate_r.UI;

namespace oceangate_r
{

    public partial class Rez5OdaForm : Form
    {
        private readonly Form _oncekiForm;

        public Rez5OdaForm(Form oncekiForm)
        {
            _oncekiForm = oncekiForm;
            InitializeComponent();

            otelOdaSecimPanel1.Baslat(
                RezervasyonContext.KisiSayisi,
                RezervasyonContext.SeciliSefer?.Id ?? 0,
                RezervasyonContext.SeferTarihi);

            
            int bosKap = ToplamBosKapasite();
            if (bosKap < RezervasyonContext.KisiSayisi)
            {
                MessageBox.Show(
                    bosKap == 0
                        ? "Bu sefer ve tarih için otelde hiç boş oda bulunmamaktadır.\nLütfen farklı bir tarih seçiniz."
                        : $"Bu sefer için yalnızca {bosKap} kişilik boş oda kapasitesi kalmıştır.\n" +
                          $"Rezervasyonunuz {RezervasyonContext.KisiSayisi} kişiliktir, herkes odaya yerleşemez.",
                    "Oda Kapasitesi Yetersiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            otelOdaSecimPanel1.SecimDegisti += oda =>
            {
                RezervasyonContext.SeciliOdalar = oda;
                if (oda == null || oda.Count == 0)
                {
                    lblSecimBilgi.Text = "Oda seçilmedi.";
                }
                else
                {
                    int toplamKap  = oda.Sum(o => o.Kapasite);
                    int kisiSayisi = RezervasyonContext.KisiSayisi;
                    string kapasite = toplamKap >= kisiSayisi
                        ? $"{toplamKap} kişilik (✓ Tüm yolcular yerleşebilir)"
                        : $"{toplamKap} kişilik (⚠ {kisiSayisi - toplamKap} kişi odaya sığmıyor!)"; 
                    lblSecimBilgi.Text = $"Seçilen: {oda.Count} oda — {kapasite}";
                }
            };
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            var secili = RezervasyonContext.SeciliOdalar;

            if (secili == null || secili.Count == 0)
            {
                MessageBox.Show(
                    "Lütfen en az bir oda seçiniz.",
                    "Oda Seçimi Gerekli",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            int toplamKap  = secili.Sum(o => o.Kapasite);
            int kisiSayisi = RezervasyonContext.KisiSayisi;

            if (toplamKap < kisiSayisi)
            {
                MessageBox.Show(
                    $"Seçtiğiniz odaların toplam kapasitesi {toplamKap} kişiliktir.\n" +
                    $"Rezervasyonunuz {kisiSayisi} kişiliktir — {kisiSayisi - toplamKap} kişi odaya yerleşemeyecek!\n\n" +
                    "Lütfen toplam kapasitesi yeterli olacak şekilde daha fazla oda seçiniz.",
                    "Kapasite Yetersiz — Geçiş Engellendi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  
            }

            var form6 = new Rez6OzetForm(this);
            form6.Show();
            Hide();
        }

        private int ToplamBosKapasite()
        {
            return DAL.OtelOdaDAL.ToplamBosKapasite(
                RezervasyonContext.SeciliSefer?.Id ?? 0,
                RezervasyonContext.SeferTarihi);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            _oncekiForm?.Show();
            Close();
        }

        private void otelOdaSecimPanel1_Load(object sender, EventArgs e)
        {

        }
    }
}
