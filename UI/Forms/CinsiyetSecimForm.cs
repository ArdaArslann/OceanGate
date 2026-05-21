using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.Entities;

namespace oceangate_r.UI.Forms
{
    /// <summary>
    /// ARCHITECT PHASE – Modal Dialog:
    /// Boş bir koltuğa tıklandığında açılan cinsiyet seçim penceresi.
    /// ShowDialog() ile çağrılır; SecilenCinsiyet property'si sonucu döndürür.
    /// Reviewer kontrolü: Hiçbir harici kütüphane yok, saf WinForms.
    /// </summary>
    public class CinsiyetSecimForm : Form
    {
        // ── Sonuç property'si – null ise kullanıcı iptal etti ──────────────
        public KoltukDurum? SecilenCinsiyet { get; private set; } = null;

        private RadioButton _rdKadin;
        private RadioButton _rdErkek;
        private Button      _btnTamam;
        private Button      _btnIptal;

        public CinsiyetSecimForm(int koltukNo)
        {
            // Form ayarları
            Text            = $"Koltuk {koltukNo} – Cinsiyet Seçimi";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition   = FormStartPosition.CenterParent;
            Size            = new Size(300, 200);
            MaximizeBox     = false;
            MinimizeBox     = false;
            BackColor       = AppTheme.BgMedium;
            ForeColor       = AppTheme.TextLight;
            Font            = AppTheme.BodyFont;

            BuildUI(koltukNo);
        }

        private void BuildUI(int koltukNo)
        {
            // Başlık
            var lblBaslik = new Label
            {
                Text      = $"Koltuk {koltukNo} için cinsiyet seçin:",
                Location  = new Point(16, 16),
                Size      = new Size(260, 24),
                ForeColor = AppTheme.TextLight,
                Font      = AppTheme.BodyBold,
            };

            // RadioButton – Kadın
            _rdKadin = new RadioButton
            {
                Text      = "Kadın",
                Location  = new Point(24, 52),
                Size      = new Size(100, 28),
                ForeColor = Color.FromArgb(249, 168, 212),   // pembe tonu
                Font      = AppTheme.BodyFont,
                Checked   = true,
            };

            // RadioButton – Erkek
            _rdErkek = new RadioButton
            {
                Text      = "Erkek",
                Location  = new Point(140, 52),
                Size      = new Size(100, 28),
                ForeColor = Color.FromArgb(147, 197, 253),   // mavi tonu
                Font      = AppTheme.BodyFont,
            };

            // Tamam Butonu
            _btnTamam = new Button
            {
                Text      = "Tamam",
                Location  = new Point(80, 100),
                Size      = new Size(90, 34),
                BackColor = AppTheme.Accent,
                ForeColor = AppTheme.TextLight,
                FlatStyle = FlatStyle.Flat,
                Font      = AppTheme.BodyBold,
                Cursor    = Cursors.Hand,
            };
            _btnTamam.FlatAppearance.BorderSize = 0;
            _btnTamam.Click += (s, e) =>
            {
                SecilenCinsiyet = _rdKadin.Checked ? KoltukDurum.DoluKadin : KoltukDurum.DoluErkek;
                DialogResult    = DialogResult.OK;
                Close();
            };

            // İptal Butonu
            _btnIptal = new Button
            {
                Text      = "İptal",
                Location  = new Point(182, 100),
                Size      = new Size(76, 34),
                BackColor = AppTheme.BgCard,
                ForeColor = AppTheme.TextMuted,
                FlatStyle = FlatStyle.Flat,
                Font      = AppTheme.BodyFont,
                Cursor    = Cursors.Hand,
            };
            _btnIptal.FlatAppearance.BorderSize = 0;
            _btnIptal.Click += (s, e) =>
            {
                SecilenCinsiyet = null;
                DialogResult    = DialogResult.Cancel;
                Close();
            };

            Controls.AddRange(new Control[] { lblBaslik, _rdKadin, _rdErkek, _btnTamam, _btnIptal });
        }
    }
}
