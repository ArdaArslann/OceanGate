using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>Admin – Sefer CRUD yönetim formu.</summary>
    public partial class SeferYonetimForm : Form
    {
        private int _seciliId = -1;

        public SeferYonetimForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            UIHelper.StyleGrid(_dgv);
            _dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",    HeaderText = "ID",         FillWeight = 6,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "Bolge", HeaderText = "Bölge",       FillWeight = 24 },
                new DataGridViewTextBoxColumn { Name = "Saat",  HeaderText = "Kalkış",      FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Kap",   HeaderText = "Kapasite",   FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Sure",  HeaderText = "Süre",        FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Fiyat", HeaderText = "Fiyat (TL)", FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Aktif", HeaderText = "Aktif",       FillWeight = 10 }
            );
            _dgv.SelectionChanged += DgvSelectionChanged;
            _btnGuncelle.SetMuted();
            _btnSil.SetDanger();
            _btnEkle.Click     += (s, e) => AciklaForm(-1);
            _btnGuncelle.Click += (s, e) => AciklaForm(_seciliId);
            _btnSil.Click      += BtnSil_Click;
            btnKaydet.Click    += BtnKaydet_Click;
            btnIptal.Click     += (s, e) => _formPanel.Visible = false;
            foreach (var b in DAL.BolgeDAL.Listele(true)) _cbBolge.Items.Add(b);
            Resize += (s, e) => DoLayout();
            DoLayout();
            YukleVeriler();
        }

        private TextBox MakeTextBox(int x, int y, int w) => new TextBox
        {
            Location    = new Point(x, y),
            Size        = new Size(w, 28),
            BackColor   = AppTheme.BgMedium,
            ForeColor   = AppTheme.TextLight,
            Font        = AppTheme.BodyFont,
            BorderStyle = BorderStyle.FixedSingle,
        };

        private void DoLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            bool panelAcik = _formPanel.Visible;

            int panelW = 420;
            int gridW  = panelAcik ? w - panelW - 32 : w - 48;

            _dgv.Location       = new Point(24, 124);
            _dgv.Size           = new Size(Math.Max(gridW, 100), h - 150);
            _formPanel.Location = new Point(w - panelW - 8, 124);
            _formPanel.Size     = new Size(panelW, h - 150);
        }

        private void YukleVeriler()
        {
            _dgv.SelectionChanged -= DgvSelectionChanged;
            _dgv.Rows.Clear();
            foreach (var s in SeferDAL.Listele())
                _dgv.Rows.Add(s.Id, s.BolgeAdi, s.KalkisSaati, s.KapasiteSayisi,
                    s.SureMetni, $"{s.FiyatKisiBasiTL:N0}", s.AktifMi ? "" : "");
            _dgv.ClearSelection();
            _seciliId = -1;
            _btnGuncelle.Enabled = false;
            _btnSil.Enabled      = false;
            _dgv.SelectionChanged += DgvSelectionChanged;
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
                _lblFormBaslik.Text = "Yeni Sefer Ekle";
                if (_cbBolge.Items.Count > 0) _cbBolge.SelectedIndex = 0;
                _txtSaat.Text       = "09:00";
                _nudKapasite.Value  = 20;
                _nudSure.Value      = 120;
                _txtFiyat.Text      = "5000";
                _chkAktif.Checked   = true;
            }
            else
            {
                _lblFormBaslik.Text = "Sefer Düzenle";
                var row = _dgv.SelectedRows[0];
                _txtSaat.Text      = row.Cells["Saat"].Value?.ToString() ?? "";
                int.TryParse(row.Cells["Kap"].Value?.ToString() ?? "20", out int kap);
                _nudKapasite.Value = Math.Min(kap, 200);
                _txtFiyat.Text     = row.Cells["Fiyat"].Value?.ToString()?.Replace(".", "").Replace(",", "") ?? "";
                _chkAktif.Checked  = row.Cells["Aktif"].Value?.ToString() == "";
            }
            _formPanel.Visible = true;
            DoLayout();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (_cbBolge.SelectedItem == null || string.IsNullOrWhiteSpace(_txtSaat.Text))
            {
                MessageBox.Show("Bölge ve saat zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(_txtFiyat.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double fiyat))
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sefer = new Sefer
            {
                Id              = _seciliId < 0 ? 0 : _seciliId,
                BolgeId         = ((Bolge)_cbBolge.SelectedItem).Id,
                KalkisSaati     = _txtSaat.Text.Trim(),
                KapasiteSayisi  = (int)_nudKapasite.Value,
                SureDakika      = (int)_nudSure.Value,
                FiyatKisiBasiTL = fiyat,
                AktifMi         = _chkAktif.Checked,
            };
            if (_seciliId < 0) SeferDAL.Ekle(sefer);
            else               SeferDAL.Guncelle(sefer);
            _formPanel.Visible = false;
            YukleVeriler();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (_seciliId < 0) return;
            if (MessageBox.Show("Sefer pasife alınacak. Emin misiniz?",
                    "Sefer Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SeferDAL.Sil(_seciliId);
                YukleVeriler();
            }
        }
    }
}
