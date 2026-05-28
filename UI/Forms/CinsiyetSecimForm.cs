using System.Windows.Forms;
using oceangate_r.Entities;

namespace oceangate_r.UI.Forms
{
   
    public partial class CinsiyetSecimForm : Form
    {
        public KoltukDurum? SecilenCinsiyet { get; private set; } = null;

        public CinsiyetSecimForm(int koltukNo)
        {
            InitializeComponent();
            Text           = $"Koltuk {koltukNo} – Cinsiyet Seçimi";
            lblBaslik.Text = $"Koltuk {koltukNo} için cinsiyet seçin:";
            _btnTamam.FlatAppearance.BorderSize = 0;
            _btnIptal.FlatAppearance.BorderSize = 0;
            _btnTamam.Click += (s, e) =>
            {
                SecilenCinsiyet = _rdKadin.Checked
                    ? KoltukDurum.DoluKadin
                    : KoltukDurum.DoluErkek;
                DialogResult = DialogResult.OK;
                Close();
            };
            _btnIptal.Click += (s, e) =>
            {
                SecilenCinsiyet = null;
                DialogResult    = DialogResult.Cancel;
                Close();
            };
        }

        private void _btnTamam_Click(object sender, System.EventArgs e)
        {

        }
    }
}
