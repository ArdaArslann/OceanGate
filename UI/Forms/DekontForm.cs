using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>
    /// Rezervasyon dekontu: Yazdırma desteği ile şık fatura görünümü.
    /// ShowDialog() olarak çağrılır — uygulama kapanmaz.
    /// </summary>
    public partial class DekontForm : Form
    {
        private readonly Rezervasyon _rezervasyon;
        private PrintDocument _printDoc;

        public DekontForm(Rezervasyon rez)
        {
            _rezervasyon = rez;
            _printDoc    = new System.Drawing.Printing.PrintDocument();
            _printDoc.PrintPage += PrintDoc_PrintPage;
            InitializeComponent();

            // Event bağlamaları
            _btnYazdir.Click += (s, e) =>
            {
                using (var pd = new System.Windows.Forms.PrintDialog { Document = _printDoc, UseEXDialog = true })
                {
                    if (pd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        _printDoc.Print();
                }
            };
            _btnKapat.Click += (s, e) => Close();

            // Çalışma zamanı: Dekont satırlarını doldur
            BuildDekontRows();
        }

        private void BuildDekontRows()
        {
            var satirlar = new (string Anahtar, string Deger)[]
            {
                ("Dekont No",    _rezervasyon.DekontNo),
                ("Tarih",        _rezervasyon.RezervasyonTarihi.ToString("dd.MM.yyyy HH:mm")),
                ("Müşteri",      _rezervasyon.KullaniciAdi),
                ("Sefer",        _rezervasyon.SeferBilgisi),
                ("Sefer Tarihi", _rezervasyon.SeferTarihiStr),
                ("Kişi Sayısı",  $"{_rezervasyon.KisiSayisi} kişi"),
                ("Toplam Tutar", _rezervasyon.ToplamTutarStr),
                ("Durum",        "Onaylandı"),
            };

            int sy = 64;
            bool dark = false;
            foreach (var (anahtar, deger) in satirlar)
            {
                var rowBg = new System.Windows.Forms.Panel
                {
                    Location  = new System.Drawing.Point(0, sy - 4),
                    Size      = new System.Drawing.Size(600, 36),
                    BackColor = dark ? System.Drawing.Color.FromArgb(30, 255, 255, 255)
                                     : System.Drawing.Color.Transparent,
                };
                var lKey = UIHelper.MakeLabel(anahtar, AppTheme.SmallFont,
                    AppTheme.TextMuted, 20, 4, 180, 24);
                var lVal = UIHelper.MakeLabel(deger, AppTheme.BodyBold,
                    anahtar == "Toplam Tutar" ? AppTheme.Accent :
                    anahtar == "Durum"        ? AppTheme.Success : AppTheme.TextLight,
                    210, 4, 370, 24);
                if (anahtar == "Toplam Tutar") lVal.Font = AppTheme.SubFont;
                rowBg.Controls.Add(lKey);
                rowBg.Controls.Add(lVal);
                _card.Controls.Add(rowBg);
                sy += 40;
                dark = !dark;
            }
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }


        // Yazdırma

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            g.FillRectangle(Brushes.White, e.PageBounds);

            int x = 60, y = 40;
            var titleFont  = new Font("Segoe UI", 18f, FontStyle.Bold);
            var headerFont = new Font("Segoe UI", 11f, FontStyle.Bold);
            var bodyFont   = new Font("Segoe UI", 10f);
            var mutedColor = Color.FromArgb(100, 100, 100);

            // Başlık
            g.DrawString("OCEANGATE", titleFont, Brushes.DarkSlateBlue, x, y); y += 36;
            g.DrawString("Denizaltı Rezervasyon Sistemi", bodyFont, new SolidBrush(mutedColor), x, y); y += 44;

            using (var pen = new Pen(Color.DarkSlateBlue, 2))
                g.DrawLine(pen, x, y, 740, y);
            y += 16;

            g.DrawString("REZERVASYON DEKONTU", headerFont, Brushes.DarkSlateBlue, x, y); y += 36;

            var satirlar = new (string, string)[]
            {
                ("Dekont No:",    _rezervasyon.DekontNo),
                ("Tarih:",        _rezervasyon.RezervasyonTarihi.ToString("dd.MM.yyyy HH:mm")),
                ("Müşteri:",      _rezervasyon.KullaniciAdi),
                ("Sefer:",        _rezervasyon.SeferBilgisi),
                ("Sefer Tarihi:", _rezervasyon.SeferTarihiStr),
                ("Kişi Sayısı:",  $"{_rezervasyon.KisiSayisi} kişi"),
                ("Toplam Tutar:", _rezervasyon.ToplamTutarStr),
                ("Durum:",        "Onaylandı"),
            };

            bool altRow = false;
            foreach (var (k, v) in satirlar)
            {
                if (altRow)
                    g.FillRectangle(new SolidBrush(Color.FromArgb(240, 248, 255)),
                        new Rectangle(x - 4, y - 2, 680, 26));
                g.DrawString(k, headerFont, new SolidBrush(mutedColor), x, y);
                g.DrawString(v, bodyFont, Brushes.Black, x + 200, y);
                y += 30;
                altRow = !altRow;
            }

            y += 24;
            using (var pen = new Pen(Color.LightGray, 1))
                g.DrawLine(pen, x, y, 740, y);
            y += 16;
            g.DrawString("Bu dekont Oceangate sisteminden otomatik oluşturulmuştur.",
                new Font("Segoe UI", 8f), new SolidBrush(mutedColor), x, y);
            y += 20;
            g.DrawString($"Yazdırma tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}",
                new Font("Segoe UI", 8f), new SolidBrush(mutedColor), x, y);

            e.HasMorePages = false;
        }

        private void _lblCheck_Click(object sender, EventArgs e)
        {

        }
    }
}
