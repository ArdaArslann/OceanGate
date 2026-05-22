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
    /// Rezervasyon Ad�m 1 � B�lge Se�imi.
    /// Kullan�c� bir b�lge se�er ve �leri'ye basar; bu form gizlenir, Ad�m 2 a��l�r.
    /// </summary>
    public partial class Rez1BolgeForm : Form
    {
        private readonly Form _oncekiForm;   // Geri butonunda bu form g�sterilir (UserDashboard)

        public Rez1BolgeForm(Form oncekiForm)
        {
            _oncekiForm = oncekiForm;
            RezervasyonContext.Sifirla();     // Her yeni rezervasyonda s�f�rla
            InitializeComponent();
            BolgeleriYukle();
        }

        // �� Veri Y�kleme �����������������������������������������������������

        private void BolgeleriYukle()
        {
            listBoxBolgeler.Items.Clear();
            foreach (var b in BolgeDAL.Listele(true))
                listBoxBolgeler.Items.Add(b);
        }

        // �� Olay ��leyicileri ������������������������������������������������

        private void btnIleri_Click(object sender, EventArgs e)
        {
            if (listBoxBolgeler.SelectedItem == null)
            {
                MessageBox.Show("L�tfen bir b�lge se�iniz.", "Uyar�",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RezervasyonContext.SeciliBolge = (Bolge)listBoxBolgeler.SelectedItem;

            var form2 = new Rez2SeferForm(this);
            form2.Show();
            Hide();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            RezervasyonContext.Sifirla();
            _oncekiForm?.Show();
            Close();
        }

        private void listBoxBolgeler_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var bolge = (Bolge)listBoxBolgeler.Items[e.Index];
            bool sel  = (e.State & DrawItemState.Selected) != 0;

            e.Graphics.FillRectangle(
                new SolidBrush(sel ? AppTheme.AccentDark
                                   : (e.Index % 2 == 0 ? AppTheme.BgMedium
                                                        : Color.FromArgb(36, 55, 80))),
                e.Bounds);

            if (sel)
                using (var pen = new Pen(AppTheme.Accent, 2))
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Left, e.Bounds.Bottom);

            e.Graphics.DrawString(bolge.Ad, AppTheme.BodyBold,
                new SolidBrush(AppTheme.TextLight), new Point(e.Bounds.Left + 20, e.Bounds.Top + 8));
            e.Graphics.DrawString($"Derinlik: {bolge.Derinlik} m  �  {bolge.Aciklama}", AppTheme.SmallFont,
                new SolidBrush(AppTheme.TextMuted), new Point(e.Bounds.Left + 20, e.Bounds.Top + 34));
        }
    }
}
