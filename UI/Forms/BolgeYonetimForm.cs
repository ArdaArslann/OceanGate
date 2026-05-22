using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>Admin – Bölge CRUD yönetim formu.</summary>
    public partial class BolgeYonetimForm : Form
    {
        private int _seciliId = -1;

        public BolgeYonetimForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            UIHelper.StyleGrid(_dgv);
            _dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",       HeaderText = "ID",           FillWeight = 6,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "Ad",       HeaderText = "Bölge Adı",    FillWeight = 28 },
                new DataGridViewTextBoxColumn { Name = "Aciklama", HeaderText = "Açıklama",     FillWeight = 40 },
                new DataGridViewTextBoxColumn { Name = "Derinlik", HeaderText = "Derinlik (m)", FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Aktif",    HeaderText = "Aktif",        FillWeight = 12 }
            );
            _dgv.SelectionChanged += DgvSelectionChanged;
            _btnEkle.Click     += (s, e) => AciklaForm(-1);
            _btnGuncelle.Click += (s, e) => AciklaForm(_seciliId);
            _btnSil.Click      += BtnSil_Click;

            btnKaydet.Click    += BtnKaydet_Click;
            btnIptal.Click     += (s, e) => _formPanel.Visible = false;
            _btnGuncelle.SetMuted();
            _btnSil.SetDanger();
            Resize += (s, e) => DoLayout();
            DoLayout();
            YukleVeriler();
        }

        private void DoLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            bool panelAcik = _formPanel.Visible;

            // formPanel her zaman sağ kenarda sabit 420px genişlikte
            int panelW = 420;
            int gridW  = panelAcik ? w - panelW - 32 : w - 48;

            _dgv.Location       = new Point(24, 124);
            _dgv.Size           = new Size(Math.Max(gridW, 100), h - 150);
            _formPanel.Location = new Point(w - panelW - 8, 124);
            _formPanel.Size     = new Size(panelW, h - 150);
        }

        private void YukleVeriler()
        {
            _dgv.Rows.Clear();
            foreach (var b in BolgeDAL.Listele())
                _dgv.Rows.Add(b.Id, b.Ad, b.Aciklama, $"{b.Derinlik:N0}", b.AktifMi ? "Evet" : "Hayır");
            _seciliId = -1;
            _btnGuncelle.Enabled = false;
            _btnSil.Enabled      = false;
        }

        private void DgvSelectionChanged(object sender, EventArgs e)
        {
            bool sel = _dgv.SelectedRows.Count > 0;
            _btnGuncelle.Enabled = sel;
            _btnSil.Enabled      = sel;
            if (sel) _seciliId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        }

        private void AciklaForm(int id)
        {
            _seciliId = id;
            if (id == -1)
            {
                _lblFormBaslik.Text = "Yeni Bölge Ekle";
                _txtAd.Text        = "";
                _txtAciklama.Text  = "";
                _nudDerinlik.Value = 0;
                _chkAktif.Checked  = true;
            }
            else
            {
                _lblFormBaslik.Text = "Bölge Düzenle";
                var row = _dgv.SelectedRows[0];
                _txtAd.Text         = row.Cells["Ad"].Value?.ToString() ?? "";
                _txtAciklama.Text   = row.Cells["Aciklama"].Value?.ToString() ?? "";
                double.TryParse(row.Cells["Derinlik"].Value?.ToString()?.Replace(".", ",") ?? "0",
                    out double d);
                _nudDerinlik.Value = Math.Min((decimal)d, _nudDerinlik.Maximum);
                _chkAktif.Checked  = row.Cells["Aktif"].Value?.ToString().Contains("") == true;
            }
            _formPanel.Visible = true;
            DoLayout();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtAd.Text))
            {
                MessageBox.Show("Bölge adı zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var b = new Bolge
            {
                Id       = _seciliId < 0 ? 0 : _seciliId,
                Ad       = _txtAd.Text.Trim(),
                Aciklama = _txtAciklama.Text.Trim(),
                Derinlik = (double)_nudDerinlik.Value,
                AktifMi  = _chkAktif.Checked,
            };
            if (_seciliId < 0) BolgeDAL.Ekle(b);
            else               BolgeDAL.Guncelle(b);

            _formPanel.Visible = false;
            YukleVeriler();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (_seciliId < 0) return;
            string ad = _dgv.SelectedRows[0].Cells["Ad"].Value?.ToString() ?? "";
            if (MessageBox.Show($"'{ad}' bölgesi pasife alınacak. Emin misiniz?",
                    "Bölge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BolgeDAL.Sil(_seciliId);
                YukleVeriler();
            }
        }
    }
}
