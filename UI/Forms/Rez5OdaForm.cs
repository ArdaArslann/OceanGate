using System.Linq;
using System;
using System.Windows.Forms;
using oceangate_r.Core;
using oceangate_r.Entities;
using oceangate_r.UI;

namespace oceangate_r
{
    /// <summary>
    /// Rezervasyon Ad?m 5 ? Otel Odas? Se?imi.
    /// OtelOdaSecimPanel bu form i?ine g?m?l?d?r.
    /// Yaln?zca ki?i say?s?yla e?le?en kapasitedeki odalar aktiftir.
    /// </summary>
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

            // Boş oda kontrolü — sefer+tarih bazlı
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

            // 1. Oda seçilmeli
            if (secili == null || secili.Count == 0)
            {
                MessageBox.Show(
                    "Lütfen en az bir oda seçiniz.",
                    "Oda Seçimi Gerekli",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Toplam kapasite >= kişi sayısı (kesin engel)
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
                return;  // Kesinlikle geçme
            }

            var form6 = new Rez6OzetForm(this);
            form6.Show();
            Hide();
        }

        // Sefer+tarih bazlı boş oda kapasitesini hesaplar
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
    }
}
