using System;
using System.Windows.Forms;
using System.Drawing;
using oceangate_r.Core;
using oceangate_r.DAL;
using oceangate_r.UI;

namespace oceangate_r
{
    /// <summary>
    /// Rezervasyon Adım 3 — Tarih Seçimi.
    /// Tarih seçildikten sonra o sefer+tarih için boş oda kapasitesi kontrol edilir.
    /// Yeterli kapasite yoksa İleri butonu kilitlenir ve kullanıcı farklı tarih seçmeye yönlendirilir.
    /// </summary>
    public partial class Rez3TarihForm : Form
    {
        private readonly Form _oncekiForm;

        // Uyarı etiketi — Designer'a eklemek yerine kodda oluşturuyoruz
        private Label _lblKapasite;

        public Rez3TarihForm(Form oncekiForm)
        {
            _oncekiForm = oncekiForm;
            InitializeComponent();

            // Uyarı etiketi
            _lblKapasite = new Label
            {
                Location  = new Point(28, 232),
                Size      = new Size(800, 40),
                Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                BackColor = Color.Transparent,
                Text      = "",
            };
            Controls.Add(_lblKapasite);
            _lblKapasite.BringToFront();

            dateTimePicker1.MinDate       = DateTime.Today.AddDays(1);
            dateTimePicker1.Value         = RezervasyonContext.SeferTarihi;
            dateTimePicker1.ValueChanged += (s, e) => KapasitiKontrol();

            KapasitiKontrol();  // ilk yüklemede de kontrol et
        }

        // Sefer+tarih için boş oda kapasitesini kontrol eder
        // Sefer henüz seçilmemisse kontrol geçilir (Rez2'den geçmeden direkt açılamaz)
        private void KapasitiKontrol()
        {
            var sefer = RezervasyonContext.SeciliSefer;
            if (sefer == null)
            {
                // Sefer bilgisi yoksa kontrol yapma
                btnIleri.Enabled      = true;
                _lblKapasite.Text     = "";
                return;
            }

            DateTime seciliTarih = dateTimePicker1.Value.Date;
            int bosKap = OtelOdaDAL.ToplamBosKapasite(sefer.Id, seciliTarih);
            int koltukKap = sefer.KapasiteSayisi;

            if (bosKap < koltukKap)
            {
                // Oda kapasitesi sefer kapasitesinden az — bazı yolcular oda bulamaz
                string mesaj = bosKap == 0
                    ? "⚠️  Bu tarihte otel tamamen dolu! Lütfen farklı bir tarih seçin."
                    : $"⚠️  Bu tarihte yalnızca {bosKap} kişilik boş oda kalmıştır " +
                      $"(sefer kapasitesi: {koltukKap} kişi). " +
                      $"Oda garantisi verilemiyor. Lütfen başka bir tarih seçin.";

                _lblKapasite.Text      = mesaj;
                _lblKapasite.ForeColor = Color.FromArgb(239, 68, 68);   // kırmızı
                btnIleri.Enabled       = false;
                btnIleri.BackColor     = Color.FromArgb(51, 65, 85);
            }
            else
            {
                // Yeterli oda var
                _lblKapasite.Text      = bosKap == koltukKap
                    ? $"✓  Bu tarihte tüm odalar boş. ({bosKap} kişilik kapasite)"
                    : $"✓  Bu tarihte {bosKap} kişilik boş oda kapasitesi var.";
                _lblKapasite.ForeColor = Color.FromArgb(16, 185, 129);   // yeşil
                btnIleri.Enabled       = true;
                btnIleri.BackColor     = Color.FromArgb(14, 165, 233);
            }
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            // Son kontrol — güvenlik katmanı
            var sefer = RezervasyonContext.SeciliSefer;
            if (sefer != null)
            {
                int bosKap = OtelOdaDAL.ToplamBosKapasite(sefer.Id, dateTimePicker1.Value.Date);
                if (bosKap < sefer.KapasiteSayisi && bosKap == 0)
                {
                    MessageBox.Show(
                        "Bu tarihte otelde hiç boş oda bulunmamaktadır.\nLütfen farklı bir tarih seçiniz.",
                        "Oda Garantisi Yok",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            RezervasyonContext.SeferTarihi = dateTimePicker1.Value.Date;

            var form4 = new Rez4KoltukForm(this);
            form4.Show();
            Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            _oncekiForm?.Show();
            Close();
        }
    }
}
