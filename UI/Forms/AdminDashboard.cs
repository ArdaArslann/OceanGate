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
    public class AdminDashboard : Form
    {
        private Panel _titleBar;
        private Panel _sidebar;
        private Panel _contentArea;
        private Button _activeMenu;

        private const int W = 1360, H = 820, TH = 50, SW = 240;

        public AdminDashboard()
        {
            UIHelper.ApplyFormStyle(this);
            Size = new Size(W, H);
            BuildUI();
            ShowGenel();
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }

        // ════════════════════════════════════════════════════════════════════

        private void BuildUI()
        {
            BuildTitleBar();
            BuildSidebar();
            BuildContentArea();
        }

        private void BuildTitleBar()
        {
            _titleBar = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(W, TH),
                BackColor = AppTheme.BgSidebar,
            };
            UIHelper.EnableDrag(_titleBar, this);

            var lblLogo = UIHelper.MakeLabel("OCEANGATE", AppTheme.SubFont,
                AppTheme.Accent, 20, 0, 250, TH);
            lblLogo.TextAlign = ContentAlignment.MiddleLeft;

            var lblAdmin = UIHelper.MakeLabel("Admin Paneli", AppTheme.BodyFont,
                AppTheme.Warning, 280, 0, 200, TH);
            lblAdmin.TextAlign = ContentAlignment.MiddleLeft;

            var lblUser = UIHelper.MakeLabel(SessionManager.AktifKullanici?.TamAd ?? "Admin",
                AppTheme.BodyBold, AppTheme.TextLight, W - 250, 0, 210, TH);
            lblUser.TextAlign = ContentAlignment.MiddleRight;

            var btnMin   = MakeTitleBtn("-", W - 92, AppTheme.TextMuted);
            btnMin.Click += (s, e) => WindowState = FormWindowState.Minimized;
            var btnClose = MakeTitleBtn("X", W - 46, AppTheme.Danger);
            btnClose.Click += (s, e) => Close();

            _titleBar.Paint += (s, e) =>
            {
                using (var pen = new Pen(AppTheme.Border, 1))
                    e.Graphics.DrawLine(pen, 0, TH - 1, W, TH - 1);
            };

            _titleBar.Controls.AddRange(new Control[] { lblLogo, lblAdmin, lblUser, btnMin, btnClose });
            Controls.Add(_titleBar);
        }

        private void BuildSidebar()
        {
            _sidebar = new Panel
            {
                Location  = new Point(0, TH),
                Size      = new Size(SW, H - TH),
                BackColor = AppTheme.BgSidebar,
            };

            // Admin avatarı
            var userCard = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(SW, 100),
                BackColor = Color.FromArgb(15, 28, 52),
            };
            var lblAv = UIHelper.MakeLabel("", new Font("Segoe UI", 28f, FontStyle.Regular, GraphicsUnit.Point),
                AppTheme.Warning, 0, 12, SW, 48);
            lblAv.TextAlign = ContentAlignment.MiddleCenter;
            var lblRole = UIHelper.MakeLabel("YÖNETİCİ", AppTheme.SmallBold, AppTheme.Warning, 0, 64, SW, 24);
            lblRole.TextAlign = ContentAlignment.MiddleCenter;
            userCard.Controls.AddRange(new Control[] { lblAv, lblRole });
            _sidebar.Controls.Add(userCard);

            var menuItems = new (string, string, Action)[]
            {
                ("❖", "Genel Bakış",     ShowGenel),
                ("🗺", "Bölge Yönetimi",  ShowBolge),
                ("⚓", "Sefer Yönetimi",  ShowSefer),
                ("₺", "Ücret Yönetimi",  ShowUcret),
                ("✉", "Talep Yönetimi",  ShowTalep),
            };

            int my = 116;
            foreach (var (icon, text, action) in menuItems)
            {
                var btn = MakeMenuButton(icon, text, my);
                var act = action;
                btn.Click += (s, e) => { SetActiveMenu(btn); act(); };
                _sidebar.Controls.Add(btn);
                my += 56;
            }

            var btnCikis = MakeMenuButton("", "Çıkış Yap", H - TH - 60);
            btnCikis.ForeColor = AppTheme.Danger;
            btnCikis.Click += (s, e) => Close();
            _sidebar.Controls.Add(btnCikis);

            _sidebar.Paint += (s, e) =>
            {
                using (var pen = new Pen(AppTheme.Border, 1))
                    e.Graphics.DrawLine(pen, SW - 1, 0, SW - 1, H - TH);
            };
            Controls.Add(_sidebar);
        }

        private void BuildContentArea()
        {
            _contentArea = new Panel
            {
                Location   = new Point(SW, TH),
                Size       = new Size(W - SW, H - TH),
                BackColor  = AppTheme.BgDark,
                AutoScroll = true,
            };
            Controls.Add(_contentArea);
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

            var talepler     = TalepDAL.Bekleyenler();
            var rezervasyonlar = RezervasyonDAL.Tumunu();
            var bolgeler     = BolgeDAL.Listele(true);
            var seferler     = SeferDAL.Listele(true);

            var statlar = new (string, string, Color)[]
            {
                ("Bekleyen Talepler",    talepler.Count.ToString(),       AppTheme.Warning),
                ("Toplam Rezervasyon",   rezervasyonlar.Count.ToString(), AppTheme.Accent),
                ("Aktif Bölge",          bolgeler.Count.ToString(),       AppTheme.Success),
                ("Aktif Sefer",          seferler.Count.ToString(),       AppTheme.Info),
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

            // Son rezervasyonlar
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

        private void ShowBolge()
        {
            LoadSubForm(new BolgeYonetimForm());
        }

        private void ShowSefer()
        {
            LoadSubForm(new SeferYonetimForm());
        }

        private void ShowUcret()
        {
            LoadSubForm(new UcretYonetimForm());
        }

        private void ShowTalep()
        {
            LoadSubForm(new TalepYonetimForm());
        }

        private void LoadSubForm(Form form)
        {
            _contentArea.Controls.Clear();
            form.TopLevel        = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Location        = new Point(0, 0);
            form.Size            = new Size(W - SW, H - TH);
            form.BackColor       = AppTheme.BgDark;
            form.ForeColor       = AppTheme.TextLight;
            form.Font            = AppTheme.BodyFont;
            _contentArea.Controls.Add(form);
            form.Show();
        }

        // ════════════════════════════════════════════════════════════════════
        //  Yardımcı
        // ════════════════════════════════════════════════════════════════════

        private Button MakeMenuButton(string icon, string text, int y)
        {
            var btn = new Button
            {
                Text      = $"  {icon}  {text}",
                Font      = AppTheme.BodyFont,
                ForeColor = AppTheme.TextMuted,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(0, y),
                Size      = new Size(SW, 48),
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor    = Cursors.Hand,
            };
            btn.FlatAppearance.BorderSize         = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            return btn;
        }

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

        private Button MakeTitleBtn(string text, int x, Color hoverFore)
        {
            var btn = new Button
            {
                Text      = text,
                Font      = AppTheme.BodyFont,
                ForeColor = AppTheme.TextMuted,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(x, 0),
                Size      = new Size(46, TH),
                Cursor    = Cursors.Hand,
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.ForeColor = hoverFore;
            btn.MouseLeave += (s, e) => btn.ForeColor = AppTheme.TextMuted;
            return btn;
        }
    }
}
