using System.Drawing;
using System.Windows.Forms;
using oceangate_r.UI.Controls;

namespace oceangate_r.UI
{
    /// <summary>
    /// Tüm formlarda ortak kullanılan stil yardımcı metotları.
    /// </summary>
    public static class UIHelper
    {
        // Form genel ayarları 

        public static void ApplyFormStyle(Form form, string title = "Oceangate")
        {
            form.BackColor         = AppTheme.BgDark;
            form.ForeColor         = AppTheme.TextLight;
            form.Font              = AppTheme.BodyFont;
            form.FormBorderStyle   = FormBorderStyle.None;
            form.StartPosition     = FormStartPosition.CenterScreen;
            // DoubleBuffered protected — typeof(Control) üzerinden reflection ile set et
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(form, true, null);
        }

        // Etiket 

        public static Label MakeLabel(string text, Font font, Color color,
            int x, int y, int w = 0, int h = 0)
        {
            var lbl = new Label
            {
                Text      = text,
                Font      = font,
                ForeColor = color,
                BackColor = Color.Transparent,
                Location  = new Point(x, y),
                AutoSize  = (w == 0),
            };
            if (w > 0) { lbl.Width = w; lbl.Height = h > 0 ? h : 24; }
            return lbl;
        }

        // Panel / Kart 

        public static Panel MakeCard(int x, int y, int w, int h, Color? bg = null)
        {
            return new Panel
            {
                Location  = new Point(x, y),
                Size      = new Size(w, h),
                BackColor = bg ?? AppTheme.BgCard,
                Padding   = new Padding(16),
            };
        }

        // Buton (OceanButton) 

        public static OceanButton MakeButton(string text, int x, int y, int w, int h)
        {
            return new OceanButton
            {
                Text     = text,
                Location = new Point(x, y),
                Size     = new Size(w, h),
            };
        }

        // DataGridView stilini uygula 

        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor           = AppTheme.BgMedium;
            dgv.GridColor                 = AppTheme.BgCard;
            dgv.BorderStyle               = BorderStyle.None;
            dgv.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle  = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible         = false;
            dgv.AllowUserToAddRows        = false;
            dgv.AllowUserToDeleteRows     = false;
            dgv.ReadOnly                  = true;
            dgv.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode       = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height        = 40;
            dgv.Font                      = AppTheme.BodyFont;

            dgv.ColumnHeadersDefaultCellStyle.BackColor   = AppTheme.BgCard;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor   = AppTheme.Accent;
            dgv.ColumnHeadersDefaultCellStyle.Font        = AppTheme.BodyBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding     = new Padding(8, 0, 0, 0);
            dgv.ColumnHeadersHeight                        = 44;

            dgv.DefaultCellStyle.BackColor          = AppTheme.BgMedium;
            dgv.DefaultCellStyle.ForeColor          = AppTheme.TextLight;
            dgv.DefaultCellStyle.SelectionBackColor = AppTheme.AccentDark;
            dgv.DefaultCellStyle.SelectionForeColor = AppTheme.TextLight;
            dgv.DefaultCellStyle.Padding            = new Padding(8, 0, 0, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 55, 80);
        }

        // Form sürükleme (FormBorderStyle = None için) 

        private static Point _dragStart;

        public static void EnableDrag(Control dragArea, Form form)
        {
            dragArea.MouseDown += (s, e) => { _dragStart = e.Location; };
            dragArea.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    form.Location = new Point(
                        form.Location.X + e.X - _dragStart.X,
                        form.Location.Y + e.Y - _dragStart.Y);
            };
        }

        // Durum rengi 

        public static Color DurumRengi(string durum)
        {
            switch (durum)
            {
                case "Onaylandi":           return AppTheme.Success;
                case "Bekliyor":            return AppTheme.Warning;
                case "IptalOnayBekliyor":   
                case "DegisiklikOnayBekliyor":
                case "DigerOnayBekliyor":   return AppTheme.Warning;
                case "Iptal":               return AppTheme.Danger;
                case "Reddedildi":          return AppTheme.Danger;
                default:                    return AppTheme.TextMuted;
            }
        }

        public static string DurumMetni(string durum)
        {
            switch (durum)
            {
                case "Onaylandi":           return "Onaylandı";
                case "Bekliyor":            return "Bekliyor";
                case "IptalOnayBekliyor":   return "İptal Bekliyor";
                case "DegisiklikOnayBekliyor": return "Değişiklik Bekliyor";
                case "DigerOnayBekliyor":   return "Talep Bekliyor";
                case "Iptal":               return "İptal Edildi";
                case "Reddedildi":          return "Reddedildi";
                default:                    return durum;
            }
        }
    }
}
