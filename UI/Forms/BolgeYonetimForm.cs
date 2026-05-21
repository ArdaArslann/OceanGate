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
    public class BolgeYonetimForm : Form
    {
        private DataGridView _dgv;
        private OceanButton _btnEkle, _btnGuncelle, _btnSil, _btnYenile;
        private Panel _formPanel;
        private TextBox _txtAd, _txtAciklama;
        private NumericUpDown _nudDerinlik;
        private CheckBox _chkAktif;
        private Label _lblFormBaslik;
        private int _seciliId = -1;

        public BolgeYonetimForm()
        {
            DoubleBuffered = true;
            BuildUI();
            YukleVeriler();
        }

        private void BuildUI()
        {
            int w = Width > 0 ? Width : 1120, h = Height > 0 ? Height : 770;

            var lblH = UIHelper.MakeLabel("🗺Bölge Yönetimi", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 22, 400, 36);
            Controls.Add(lblH);

            // Butonlar
            _btnEkle     = UIHelper.MakeButton("+ Yeni Bölge",    24, 70, 160, 42);
            _btnGuncelle = UIHelper.MakeButton("Güncelle",      196, 70, 140, 42);
            _btnGuncelle.SetMuted(); _btnGuncelle.Enabled = false;
            _btnSil      = UIHelper.MakeButton("Sil",           348, 70, 120, 42);
            _btnSil.SetDanger(); _btnSil.Enabled = false;
            _btnYenile   = UIHelper.MakeButton("Yenile",         24, 70, 100, 42);

            _btnEkle.Click     += (s, e) => AciklaForm(-1);
            _btnGuncelle.Click += (s, e) => AciklaForm(_seciliId);
            _btnSil.Click      += BtnSil_Click;
            _btnYenile.Click   += (s, e) => YukleVeriler();

            Controls.AddRange(new Control[] { _btnEkle, _btnGuncelle, _btnSil });

            // Grid
            _dgv = new DataGridView { Location = new Point(24, 124), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            UIHelper.StyleGrid(_dgv);
            _dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",       HeaderText = "ID",        FillWeight = 6,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "Ad",       HeaderText = "Bölge Adı", FillWeight = 28 },
                new DataGridViewTextBoxColumn { Name = "Aciklama", HeaderText = "Açıklama",  FillWeight = 40 },
                new DataGridViewTextBoxColumn { Name = "Derinlik", HeaderText = "Derinlik (m)", FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Aktif",    HeaderText = "Aktif",     FillWeight = 12 }
            );
            _dgv.SelectionChanged += DgvSelectionChanged;
            Controls.Add(_dgv);

            // Form paneli (sağ taraf)
            _formPanel = UIHelper.MakeCard(0, 0, 400, 400, AppTheme.BgCard);
            _formPanel.Visible = false;

            _lblFormBaslik = UIHelper.MakeLabel("Yeni Bölge", AppTheme.SubFont,
                AppTheme.TextLight, 16, 14, 360, 30);

            var lAd = UIHelper.MakeLabel("Bölge Adı *", AppTheme.SmallFont, AppTheme.TextMuted, 16, 56, 160, 22);
            _txtAd = new TextBox
            {
                Location    = new Point(16, 80),
                Size        = new Size(368, 28),
                BackColor   = AppTheme.BgMedium,
                ForeColor   = AppTheme.TextLight,
                Font        = AppTheme.BodyFont,
                BorderStyle = BorderStyle.FixedSingle,
            };

            var lAc = UIHelper.MakeLabel("Açıklama", AppTheme.SmallFont, AppTheme.TextMuted, 16, 120, 160, 22);
            _txtAciklama = new TextBox
            {
                Location    = new Point(16, 144),
                Size        = new Size(368, 60),
                BackColor   = AppTheme.BgMedium,
                ForeColor   = AppTheme.TextLight,
                Font        = AppTheme.BodyFont,
                BorderStyle = BorderStyle.FixedSingle,
                Multiline   = true,
            };

            var lDer = UIHelper.MakeLabel("Derinlik (m)", AppTheme.SmallFont, AppTheme.TextMuted, 16, 216, 160, 22);
            _nudDerinlik = new NumericUpDown
            {
                Location   = new Point(16, 240),
                Size       = new Size(140, 28),
                Minimum    = 0,
                Maximum    = 11000,
                DecimalPlaces = 1,
                BackColor  = AppTheme.BgMedium,
                ForeColor  = AppTheme.TextLight,
                Font       = AppTheme.BodyFont,
            };

            _chkAktif = new CheckBox
            {
                Text      = "Aktif",
                Location  = new Point(16, 288),
                Size      = new Size(120, 28),
                Checked   = true,
                ForeColor = AppTheme.TextLight,
                Font      = AppTheme.BodyFont,
            };

            var btnKaydet = UIHelper.MakeButton("Kaydet", 16, 332, 180, 44);
            btnKaydet.SetSuccess();
            btnKaydet.Click += BtnKaydet_Click;

            var btnIptal = UIHelper.MakeButton("İptal", 208, 332, 160, 44);
            btnIptal.SetMuted();
            btnIptal.Click += (s, e) => _formPanel.Visible = false;

            _formPanel.Controls.AddRange(new Control[]
            {
                _lblFormBaslik, lAd, _txtAd, lAc, _txtAciklama, lDer, _nudDerinlik,
                _chkAktif, btnKaydet, btnIptal,
            });
            Controls.Add(_formPanel);

            Resize += (s, e) => DoLayout();
            DoLayout();
        }

        private void DoLayout()
        {
            int w = Width, h = Height;
            int gridW = _formPanel.Visible ? w - 460 : w - 48;
            _dgv.Size       = new Size(gridW, h - 150);
            _formPanel.Location = new Point(w - 440, 124);
            _formPanel.Size     = new Size(416, h - 150);
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
