using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.Core;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;

namespace oceangate_r
{
    /// <summary>
    /// Rezervasyon Adým 2 – Sefer Seçimi.
    /// </summary>
    public partial class Rez2SeferForm : Form
    {
        private readonly Form _oncekiForm;

        public Rez2SeferForm(Form oncekiForm)
        {
            _oncekiForm = oncekiForm;
            InitializeComponent();
            SeferleriYukle();
        }

        private void SeferleriYukle()
        {
            listBoxSeferler.Items.Clear();
            foreach (var s in SeferDAL.BolgeninSefer(RezervasyonContext.SeciliBolge.Id))
                listBoxSeferler.Items.Add(s);
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            if (listBoxSeferler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir sefer seçiniz.", "Uyarý",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RezervasyonContext.SeciliSefer = (Sefer)listBoxSeferler.SelectedItem;

            var form3 = new Rez3TarihForm(this);
            form3.Show();
            Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            _oncekiForm?.Show();
            Close();
        }

        private void listBoxSeferler_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var sefer = (Sefer)listBoxSeferler.Items[e.Index];
            bool sel  = (e.State & DrawItemState.Selected) != 0;

            e.Graphics.FillRectangle(
                new SolidBrush(sel ? AppTheme.AccentDark
                                   : (e.Index % 2 == 0 ? AppTheme.BgMedium
                                                        : Color.FromArgb(36, 55, 80))),
                e.Bounds);

            if (sel)
                using (var pen = new Pen(AppTheme.Accent, 2))
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Left, e.Bounds.Bottom);

            e.Graphics.DrawString($"{sefer.KalkisSaati}", AppTheme.MedBold,
                new SolidBrush(AppTheme.Accent), new Point(e.Bounds.Left + 16, e.Bounds.Top + 8));
            e.Graphics.DrawString(
                $"Süre: {sefer.SureMetni}   |   Kapasite: {sefer.KapasiteSayisi} kişi",
                AppTheme.SmallFont, new SolidBrush(AppTheme.TextMuted),
                new Point(e.Bounds.Left + 16, e.Bounds.Top + 34));
            e.Graphics.DrawString($"{sefer.FiyatKisiBasiTL:N0} TL / kişi", AppTheme.SubFont,
                new SolidBrush(AppTheme.Success),
                new System.Drawing.RectangleF(e.Bounds.Right - 220, e.Bounds.Top + 16, 200, 40));
        }
    }
}
