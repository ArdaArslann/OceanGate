using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>Admin – Hızlı ücret güncelleme formu.</summary>
    public class UcretYonetimForm : Form
    {
        private DataGridView _dgv;
        private OceanButton _btnGuncelle;
        private int _seciliId = -1;
        private double _seciliFiyat;

        public UcretYonetimForm()
        {
            DoubleBuffered = true;
            BuildUI();
            YukleVeriler();
        }

        private void BuildUI()
        {
            var lblH = UIHelper.MakeLabel("Ücret Yönetimi", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 22, 400, 36);
            var lblSub = UIHelper.MakeLabel("Sefer seçin ve yeni fiyatı belirleyin.",
                AppTheme.BodyFont, AppTheme.TextMuted, 24, 62, 600, 24);
            Controls.AddRange(new Control[] { lblH, lblSub });

            _dgv = new DataGridView { Location = new Point(24, 96) };
            UIHelper.StyleGrid(_dgv);
            _dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",     HeaderText = "ID",           FillWeight = 6,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "Bolge",  HeaderText = "Bölge",        FillWeight = 30 },
                new DataGridViewTextBoxColumn { Name = "Saat",   HeaderText = "Kalkış",       FillWeight = 12 },
                new DataGridViewTextBoxColumn { Name = "Sure",   HeaderText = "Süre",         FillWeight = 12 },
                new DataGridViewTextBoxColumn { Name = "Kap",    HeaderText = "Kapasite",     FillWeight = 12 },
                new DataGridViewTextBoxColumn { Name = "Fiyat",  HeaderText = "Güncel Fiyat", FillWeight = 18 },
                new DataGridViewTextBoxColumn { Name = "Aktif",  HeaderText = "Aktif",        FillWeight = 10 }
            );
            _dgv.SelectionChanged += DgvSelectionChanged;
            Controls.Add(_dgv);

            // Güncelleme kutusu
            var fiyatBox = UIHelper.MakeCard(24, 0, 500, 110, AppTheme.BgCard);
            var lblFB = UIHelper.MakeLabel("Yeni Fiyat Belirle (TL/kişi)", AppTheme.BodyBold,
                AppTheme.TextLight, 16, 14, 460, 26);

            var txtYeni = new OceanTextBox
            {
                Location        = new Point(16, 50),
                Size            = new Size(240, 44),
                BackColor       = AppTheme.BgMedium,
                PlaceholderText = "Yeni fiyat (TL)",
            };

            _btnGuncelle = UIHelper.MakeButton("Fiyatı Güncelle", 270, 48, 200, 36);
            _btnGuncelle.SetSuccess();
            _btnGuncelle.Enabled = false;
            _btnGuncelle.Click += (s, e) =>
            {
                if (_seciliId < 0) return;
                if (!double.TryParse(txtYeni.Text.Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double yeni))
                {
                    MessageBox.Show("Geçerli bir fiyat giriniz.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SeferDAL.FiyatGuncelle(_seciliId, yeni);
                txtYeni.Text = "";
                YukleVeriler();
                MessageBox.Show("Fiyat başarıyla güncellendi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            fiyatBox.Controls.AddRange(new Control[] { lblFB, txtYeni, _btnGuncelle });
            Controls.Add(fiyatBox);

            Resize += (s, e) => DoLayout();
            DoLayout();
        }

        private void DoLayout()
        {
            int w = Width, h = Height;
            _dgv.Size = new Size(w - 48, h - 230);
            // fiyatBox konumu
            if (Controls.Count > 3)
                Controls[3].Location = new Point(24, h - 126);
        }

        private void YukleVeriler()
        {
            _dgv.Rows.Clear();
            foreach (var s in SeferDAL.Listele())
                _dgv.Rows.Add(s.Id, s.BolgeAdi, s.KalkisSaati, s.SureMetni,
                    s.KapasiteSayisi, $"{s.FiyatKisiBasiTL:N0} TL", s.AktifMi ? "" : "");
        }

        private void DgvSelectionChanged(object sender, EventArgs e)
        {
            bool sel = _dgv.SelectedRows.Count > 0;
            _btnGuncelle.Enabled = sel;
            if (sel)
            {
                _seciliId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
                string fiyatStr = _dgv.SelectedRows[0].Cells["Fiyat"].Value?.ToString()
                    ?.Replace(" TL", "")?.Replace(".", "")?.Replace(",", ".") ?? "0";
                double.TryParse(fiyatStr, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out _seciliFiyat);
            }
        }
    }
}
