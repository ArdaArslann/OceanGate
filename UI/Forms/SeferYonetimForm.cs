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
    public class SeferYonetimForm : Form
    {
        private DataGridView _dgv;
        private OceanButton _btnEkle, _btnGuncelle, _btnSil;
        private Panel  _formPanel;
        private ComboBox _cbBolge;
        private TextBox  _txtSaat;
        private NumericUpDown _nudKapasite, _nudSure;
        private TextBox _txtFiyat;
        private CheckBox _chkAktif;
        private Label _lblFormBaslik;
        private int _seciliId = -1;

        public SeferYonetimForm()
        {
            DoubleBuffered = true;
            BuildUI();
            YukleVeriler();
        }

        private void BuildUI()
        {
            var lblH = UIHelper.MakeLabel("Sefer Yönetimi", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 22, 400, 36);
            Controls.Add(lblH);

            _btnEkle     = UIHelper.MakeButton("+ Yeni Sefer",  24, 70, 160, 42);
            _btnGuncelle = UIHelper.MakeButton("Güncelle",  196, 70, 140, 42);
            _btnGuncelle.SetMuted(); _btnGuncelle.Enabled = false;
            _btnSil      = UIHelper.MakeButton("Sil",        348, 70, 120, 42);
            _btnSil.SetDanger(); _btnSil.Enabled = false;

            _btnEkle.Click     += (s, e) => AciklaForm(-1);
            _btnGuncelle.Click += (s, e) => AciklaForm(_seciliId);
            _btnSil.Click      += BtnSil_Click;

            Controls.AddRange(new Control[] { _btnEkle, _btnGuncelle, _btnSil });

            _dgv = new DataGridView { Location = new Point(24, 124) };
            UIHelper.StyleGrid(_dgv);
            _dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",      HeaderText = "ID",            FillWeight = 6,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "Bolge",   HeaderText = "Bölge",         FillWeight = 24 },
                new DataGridViewTextBoxColumn { Name = "Saat",    HeaderText = "Kalkış",        FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Kap",     HeaderText = "Kapasite",      FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Sure",    HeaderText = "Süre",          FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Fiyat",   HeaderText = "Fiyat (TL)",    FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Aktif",   HeaderText = "Aktif",         FillWeight = 10 }
            );
            _dgv.SelectionChanged += DgvSelectionChanged;
            Controls.Add(_dgv);

            // Form paneli
            _formPanel = UIHelper.MakeCard(0, 0, 420, 480, AppTheme.BgCard);
            _formPanel.Visible = false;

            _lblFormBaslik = UIHelper.MakeLabel("Yeni Sefer", AppTheme.SubFont,
                AppTheme.TextLight, 16, 14, 380, 30);

            // Bölge
            var lB = UIHelper.MakeLabel("Bölge *", AppTheme.SmallFont, AppTheme.TextMuted, 16, 56, 200, 22);
            _cbBolge = new ComboBox
            {
                Location      = new Point(16, 80),
                Size          = new Size(380, 28),
                BackColor     = AppTheme.BgMedium,
                ForeColor     = AppTheme.TextLight,
                Font          = AppTheme.BodyFont,
                FlatStyle     = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            foreach (var b in BolgeDAL.Listele(true)) _cbBolge.Items.Add(b);

            // Saat
            var lS = UIHelper.MakeLabel("Kalkış Saati * (HH:mm)", AppTheme.SmallFont, AppTheme.TextMuted, 16, 118, 220, 22);
            _txtSaat = MakeTextBox(16, 142, 180);

            // Kapasite
            var lK = UIHelper.MakeLabel("Kapasite (Kişi)", AppTheme.SmallFont, AppTheme.TextMuted, 16, 180, 160, 22);
            _nudKapasite = new NumericUpDown { Location = new Point(16, 204), Size = new Size(120, 28),
                Minimum = 1, Maximum = 200, Value = 20,
                BackColor = AppTheme.BgMedium, ForeColor = AppTheme.TextLight, Font = AppTheme.BodyFont };

            // Süre
            var lSure = UIHelper.MakeLabel("Süre (Dakika)", AppTheme.SmallFont, AppTheme.TextMuted, 160, 180, 140, 22);
            _nudSure = new NumericUpDown { Location = new Point(160, 204), Size = new Size(120, 28),
                Minimum = 30, Maximum = 1440, Value = 120,
                BackColor = AppTheme.BgMedium, ForeColor = AppTheme.TextLight, Font = AppTheme.BodyFont };

            // Fiyat
            var lF = UIHelper.MakeLabel("Kişi Başı Fiyat (TL) *", AppTheme.SmallFont, AppTheme.TextMuted, 16, 244, 200, 22);
            _txtFiyat = MakeTextBox(16, 268, 220);

            _chkAktif = new CheckBox
            {
                Text      = "Aktif",
                Location  = new Point(16, 312),
                Size      = new Size(120, 28),
                Checked   = true,
                ForeColor = AppTheme.TextLight,
                Font      = AppTheme.BodyFont,
            };

            var btnKaydet = UIHelper.MakeButton("Kaydet", 16, 360, 180, 44);
            btnKaydet.SetSuccess();
            btnKaydet.Click += BtnKaydet_Click;

            var btnIptal = UIHelper.MakeButton("İptal", 208, 360, 160, 44);
            btnIptal.SetMuted();
            btnIptal.Click += (s, e) => _formPanel.Visible = false;

            _formPanel.Controls.AddRange(new Control[]
            {
                _lblFormBaslik, lB, _cbBolge, lS, _txtSaat, lK, _nudKapasite,
                lSure, _nudSure, lF, _txtFiyat, _chkAktif, btnKaydet, btnIptal,
            });
            Controls.Add(_formPanel);

            Resize += (s, e) => DoLayout();
            DoLayout();
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
            int w = Width, h = Height;
            _dgv.Size           = new Size(_formPanel.Visible ? w - 460 : w - 48, h - 150);
            _formPanel.Location = new Point(w - 440, 124);
            _formPanel.Size     = new Size(416, h - 150);
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
