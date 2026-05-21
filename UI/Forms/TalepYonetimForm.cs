using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>Admin – Kullanıcı talep yönetim formu (Onayla / Reddet).</summary>
    public class TalepYonetimForm : Form
    {
        private DataGridView _dgv;
        private OceanButton  _btnOnayla, _btnReddet, _btnYenile;
        private OceanButton  _btnTabTumu, _btnTabBekleyen;
        private Panel        _actionBar;   // Alan olarak sakla — DoLayout'ta kullanılır
        private int          _seciliId = -1;

        public TalepYonetimForm()
        {
            DoubleBuffered = true;
            BuildUI();
            YukleVeriler();
        }

        private void BuildUI()
        {
            var lblH = UIHelper.MakeLabel("Talep Yönetimi", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 22, 500, 36);
            var lblSub = UIHelper.MakeLabel("Kullanıcıların gönderdiği iptal, değişiklik ve iade talepleri",
                AppTheme.BodyFont, AppTheme.TextMuted, 24, 62, 700, 24);
            Controls.AddRange(new Control[] { lblH, lblSub });

            // Filtre butonları (Sekmeler)
            _btnTabTumu = UIHelper.MakeButton("Tümü", 24, 100, 100, 36);
            _btnTabTumu.SetColors(AppTheme.Accent, AppTheme.AccentHover, AppTheme.AccentDark); // Varsayılan aktif
            _btnTabTumu.Click += (s, e) => SetTab(false);

            _btnTabBekleyen = UIHelper.MakeButton("Bekleyenler", 136, 100, 160, 36);
            _btnTabBekleyen.SetMuted();
            _btnTabBekleyen.Click += (s, e) => SetTab(true);

            _btnYenile = UIHelper.MakeButton("Yenile", 308, 100, 100, 36);
            _btnYenile.SetMuted();
            _btnYenile.Click += (s, e) => {
                bool isBekleyen = _btnTabBekleyen.BackColor != AppTheme.BgCard; // Accent ise true
                YukleVeriler(isBekleyen);
            };

            Controls.AddRange(new Control[] { _btnTabTumu, _btnTabBekleyen, _btnYenile });

            // Grid — 148 px üstten başlıyor
            _dgv = new DataGridView { Location = new Point(24, 150) };
            UIHelper.StyleGrid(_dgv);
            _dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",        HeaderText = "ID",           FillWeight = 5,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "RezId",     HeaderText = "Rez.ID",       FillWeight = 5,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "Dekont",    HeaderText = "Dekont No",    FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Kullanici", HeaderText = "Kullanıcı",    FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Tip",       HeaderText = "Talep Türü",   FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Aciklama",  HeaderText = "Açıklama",     FillWeight = 24 },
                new DataGridViewTextBoxColumn { Name = "Tarih",     HeaderText = "Talep Tarihi", FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Durum",     HeaderText = "Durum",        FillWeight = 14 }
            );
            _dgv.SelectionChanged += DgvSelectionChanged;
            Controls.Add(_dgv);

            // Aksiyon çubuğu (alan olarak) 
            _actionBar = UIHelper.MakeCard(24, 0, 700, 70, AppTheme.BgCard);

            _btnOnayla = UIHelper.MakeButton("Onayla", 16, 12, 200, 46);
            _btnOnayla.SetSuccess();
            _btnOnayla.Enabled = false;
            _btnOnayla.Click += BtnOnayla_Click;

            _btnReddet = UIHelper.MakeButton("Reddet", 228, 12, 200, 46);
            _btnReddet.SetDanger();
            _btnReddet.Enabled = false;
            _btnReddet.Click += BtnReddet_Click;

            var lblHint = UIHelper.MakeLabel("Bir talep seçerek işlem yapabilirsiniz.",
                AppTheme.SmallFont, AppTheme.TextMuted, 440, 20, 250, 30);

            _actionBar.Controls.AddRange(new Control[] { _btnOnayla, _btnReddet, lblHint });
            Controls.Add(_actionBar);

            Resize += (s, e) => DoLayout();
            DoLayout();
        }

        private void DoLayout()
        {
            int w = Width, h = Height;
            int gridH = h - 150 - 86;          // Üst 150px + alt aksiyon 70px + boşluk
            if (gridH < 60) gridH = 60;
            _dgv.Size        = new Size(w - 48, gridH);
            _actionBar.Location = new Point(24, 150 + gridH + 8);
            _actionBar.Size     = new Size(w - 48, 70);
        }

        private void SetTab(bool sadeceBekleyen)
        {
            if (sadeceBekleyen)
            {
                _btnTabBekleyen.SetColors(AppTheme.Accent, AppTheme.AccentHover, AppTheme.AccentDark);
                _btnTabTumu.SetMuted();
            }
            else
            {
                _btnTabTumu.SetColors(AppTheme.Accent, AppTheme.AccentHover, AppTheme.AccentDark);
                _btnTabBekleyen.SetMuted();
            }
            YukleVeriler(sadeceBekleyen);
        }

        private void YukleVeriler(bool sadeceBekleyen = false)
        {
            _dgv.SelectionChanged -= DgvSelectionChanged; // Eklerken eventi tetikleme
            _dgv.Rows.Clear();
            var list = sadeceBekleyen ? TalepDAL.Bekleyenler() : TalepDAL.Tumunu();

            foreach (var t in list)
            {
                string tipGoster;
                switch (t.TalepTipi)
                {
                    case "Iptal":      tipGoster = "İptal ve İade"; break;
                    case "Degisiklik": tipGoster = "Tarih Değişikliği"; break;
                    default:           tipGoster = t.TalepTipi; break;
                }

                int idx = _dgv.Rows.Add(
                    t.Id, t.RezervasyonId, t.DekontNo, t.KullaniciAdi,
                    tipGoster, t.Aciklama, t.TalepTarihiStr,
                    t.Durum == "Bekliyor"   ? "Bekliyor" :
                    t.Durum == "Onaylandi"  ? "Onaylandı" : "Reddedildi");

                Color renk = t.Durum == "Bekliyor"  ? AppTheme.Warning :
                             t.Durum == "Onaylandi" ? AppTheme.Success : AppTheme.Danger;
                _dgv.Rows[idx].DefaultCellStyle.ForeColor = renk;
            }

            _dgv.ClearSelection(); // Seçimi temizle
            _seciliId = -1;
            _btnOnayla.Enabled = false;
            _btnReddet.Enabled = false;
            _dgv.SelectionChanged += DgvSelectionChanged; // Eventi tekrar bağla
        }

        private void DgvSelectionChanged(object sender, EventArgs e)
        {
            if (_dgv.SelectedRows.Count == 0) return;
            _seciliId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
            string durum = _dgv.SelectedRows[0].Cells["Durum"].Value?.ToString() ?? "";
            bool bekliyor = durum.Contains("Bekliyor");
            _btnOnayla.Enabled = bekliyor;
            _btnReddet.Enabled = bekliyor;
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (_seciliId < 0) return;
            TalepDAL.DurumGuncelle(_seciliId, "Onaylandi");

            string tip   = _dgv.SelectedRows[0].Cells["Tip"].Value?.ToString() ?? "";
            int    rezId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["RezId"].Value);
            if (tip == "İptal ve İade")
                RezervasyonDAL.DurumGuncelle(rezId, "Iptal");
            else
                RezervasyonDAL.DurumGuncelle(rezId, "Onaylandi");

            MessageBox.Show("Talep onaylandı.", "Başarılı",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            YukleVeriler(false);
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (_seciliId < 0) return;
            TalepDAL.DurumGuncelle(_seciliId, "Reddedildi");

            string tip   = _dgv.SelectedRows[0].Cells["Tip"].Value?.ToString() ?? "";
            int    rezId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["RezId"].Value);
            // Talep reddedildiğinde, talep türü ne olursa olsun rezervasyon mevcut onaylı statüsüne döner
            RezervasyonDAL.DurumGuncelle(rezId, "Onaylandi");

            MessageBox.Show("Talep reddedildi.", "Reddedildi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            YukleVeriler(false);
        }
    }
}
