using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>
    /// Yönetici ana paneli. Sol menü + sekmeli yönetim alanları.
    /// </summary>
    public partial class AdminDashboard : Form
    {
        private const int W = 1360, H = 820, TH = 50, SW = 240;

        public AdminDashboard()
        {
            InitializeComponent();
            UIHelper.EnableDrag(_titleBar, this);
            _lblAdminTag.Text = SessionManager.AktifKullanici?.TamAd ?? "Admin";

            // Buton metinleri (Designer'dan eksik kaldı)
            _btnMenuGenel.Text = "  📊  Genel Bakış";
            _btnMenuBolge.Text = "  🗺️  Bölgeler";
            _btnMenuSefer.Text = "  🚢  Seferler";
            _btnMenuTalep.Text = "  📋  Talepler";
            _btnCikis.Text     = "  🚪  Çıkış Yap";

            // Event bağlamaları
            _btnCikis.Click    += (s, e) => Close();

            _btnMenuGenel.Click += (s, e) => { SetActiveMenu(_btnMenuGenel); ShowGenel(); };
            _btnMenuBolge.Click += (s, e) => { SetActiveMenu(_btnMenuBolge); ShowBolge(); };
            _btnMenuSefer.Click += (s, e) => { SetActiveMenu(_btnMenuSefer); ShowSefer(); };

            _btnMenuTalep.Click += (s, e) => { SetActiveMenu(_btnMenuTalep); ShowTalep(); };

            _titleBar.Paint += (s, e) =>
            {
                using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(30, 41, 59), 1))
                    e.Graphics.DrawLine(pen, 0, 49, 1360, 49);
            };
            _sidebar.Paint += (s, e) =>
            {
                using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(30, 41, 59), 1))
                    e.Graphics.DrawLine(pen, 239, 0, 239, 770);
            };

            ShowGenel();
            SetActiveMenu(_btnMenuGenel);
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }

        // ════════════════════════════════════════════════════════════════════
        //  Sayfa Yükleyiciler
        // ════════════════════════════════════════════════════════════════════

        private void ShowGenel()
        {
            _contentArea.Controls.Clear();
            int cw = W - SW - 40;

            var lblH = UIHelper.MakeLabel("Genel Bakış", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 24, 400, 36);
            _contentArea.Controls.Add(lblH);

            var talepler      = TalepDAL.Bekleyenler();
            var rezervasyonlar = RezervasyonDAL.Tumunu();
            var bolgeler      = BolgeDAL.Listele(true);
            var seferler      = SeferDAL.Listele(true);

            var statlar = new (string, string, Color)[]
            {
                ("Bekleyen Talepler",  talepler.Count.ToString(),       AppTheme.Warning),
                ("Toplam Rezervasyon", rezervasyonlar.Count.ToString(), AppTheme.Accent),
                ("Aktif Bölge",        bolgeler.Count.ToString(),       AppTheme.Success),
                ("Aktif Sefer",        seferler.Count.ToString(),       AppTheme.Info),
            };

            int sx = 24, cardW = (cw - 72) / 4;
            foreach (var (baslik, deger, renk) in statlar)
            {
                var card = UIHelper.MakeCard(sx, 76, cardW, 100);
                var ld = UIHelper.MakeLabel(deger, AppTheme.TitleFont, renk, 0, 14, cardW, 40);
                ld.TextAlign = ContentAlignment.MiddleCenter;
                var lb = UIHelper.MakeLabel(baslik, AppTheme.SmallFont,
                    AppTheme.TextMuted, 0, 58, cardW, 24);
                lb.TextAlign = ContentAlignment.MiddleCenter;
                card.Controls.AddRange(new Control[] { ld, lb });
                _contentArea.Controls.Add(card);
                sx += cardW + 24;
            }

            var lblSon = UIHelper.MakeLabel("Son Rezervasyonlar", AppTheme.SubFont,
                AppTheme.TextLight, 24, 200, 360, 28);
            _contentArea.Controls.Add(lblSon);

            var dgv = new DataGridView
            {
                Location = new Point(24, 238),
                Size     = new Size(cw, 300),
            };
            UIHelper.StyleGrid(dgv);
            dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Dekont No",  FillWeight = 16 },
                new DataGridViewTextBoxColumn { HeaderText = "Kullanıcı",  FillWeight = 16 },
                new DataGridViewTextBoxColumn { HeaderText = "Sefer",      FillWeight = 30 },
                new DataGridViewTextBoxColumn { HeaderText = "Tarih",      FillWeight = 14 },
                new DataGridViewTextBoxColumn { HeaderText = "Tutar",      FillWeight = 14 },
                new DataGridViewTextBoxColumn { HeaderText = "Durum",      FillWeight = 14 }
            );
            foreach (var r in rezervasyonlar)
            {
                int idx = dgv.Rows.Add(r.DekontNo, r.KullaniciAdi, r.SeferBilgisi,
                    r.SeferTarihiStr, r.ToplamTutarStr, UIHelper.DurumMetni(r.Durum));
                dgv.Rows[idx].DefaultCellStyle.ForeColor = UIHelper.DurumRengi(r.Durum);
            }
            _contentArea.Controls.Add(dgv);
        }

        private void ShowBolge()  { LoadSubForm(new BolgeYonetimForm()); }
        private void ShowSefer()  { LoadSubForm(new SeferYonetimForm()); }

        private void ShowTalep()  { LoadSubForm(new TalepYonetimForm()); }

        private void LoadSubForm(Form form)
        {
            // Gerçek pencere olarak aç — kendi başlık çubuğu ve X butonu ile
            form.Owner           = this;
            form.StartPosition   = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox     = false;
            form.MinimizeBox     = false;
            form.ShowInTaskbar   = false;
            form.FormClosed     += (s, e) => ShowGenel();
            form.Show(this);
        }

        // ════════════════════════════════════════════════════════════════════
        //  Yardımcı
        // ════════════════════════════════════════════════════════════════════

        private void SetActiveMenu(Button btn)
        {
            if (_activeMenu != null)
            {
                _activeMenu.BackColor = Color.Transparent;
                _activeMenu.ForeColor = AppTheme.TextMuted;
            }
            _activeMenu = btn;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(20, 245, 158, 11);
                btn.ForeColor = AppTheme.Warning;
            }
        }
    }
}
