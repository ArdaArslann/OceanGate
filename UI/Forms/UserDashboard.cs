using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>
    /// Kullanıcı ana paneli. Sol menü ile içerik alanı arasında geçiş sağlar.
    /// </summary>
    public class UserDashboard : Form
    {
        private Panel _titleBar;
        private Panel _sidebar;
        private Panel _contentArea;
        private Label _lblUserName;

        // Menü butonları
        private Button _activeMenu;

        private const int W = 1280, H = 780, TH = 50, SW = 230;

        public UserDashboard()
        {
            UIHelper.ApplyFormStyle(this);
            Size = new Size(W, H);
            BuildUI();
            ShowAnaSayfa();
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }

        // ════════════════════════════════════════════════════════════════════
        //  Ana Yapı
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

            var lblTitle = UIHelper.MakeLabel("Kullanıcı Paneli", AppTheme.BodyFont,
                AppTheme.TextMuted, 280, 0, 300, TH);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            _lblUserName = UIHelper.MakeLabel("", AppTheme.BodyBold,
                AppTheme.TextLight, W - 250, 0, 200, TH);
            _lblUserName.TextAlign = ContentAlignment.MiddleRight;
            _lblUserName.Text = SessionManager.AktifKullanici?.TamAd ?? "";

            var btnMin = MakeTitleBtn("-", W - 92, AppTheme.TextMuted);
            btnMin.Click += (s, e) => WindowState = FormWindowState.Minimized;

            var btnClose = MakeTitleBtn("X", W - 46, AppTheme.Danger);
            btnClose.Click += (s, e) => Close();

            // Alt çizgi
            _titleBar.Paint += (s, e) =>
            {
                using (var pen = new Pen(AppTheme.Border, 1))
                    e.Graphics.DrawLine(pen, 0, TH - 1, W, TH - 1);
            };

            _titleBar.Controls.AddRange(new Control[] { lblLogo, lblTitle, _lblUserName, btnMin, btnClose });
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

            // Kullanıcı bilgi kartı
            var userCard = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(SW, 100),
                BackColor = Color.FromArgb(15, 28, 52),
            };

            var lblAvatar = UIHelper.MakeLabel("", new Font("Segoe UI", 28f, FontStyle.Regular, GraphicsUnit.Point),
                AppTheme.Accent, 0, 12, SW, 48);
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;

            string tamAd = SessionManager.AktifKullanici?.TamAd ?? "";
            var lblName = UIHelper.MakeLabel(tamAd, AppTheme.BodyBold, AppTheme.TextLight, 0, 64, SW, 24);
            lblName.TextAlign = ContentAlignment.MiddleCenter;

            userCard.Controls.AddRange(new Control[] { lblAvatar, lblName });
            _sidebar.Controls.Add(userCard);

            // Menü öğeleri
            var menuItems = new (string Icon, string Text, Action Action)[]
            {
                ("⌂", "Ana Sayfa",          ShowAnaSayfa),
                ("✚", "Yeni Rezervasyon",   ShowYeniRezervason),
                ("⚓", "Rezervasyonlarım",   ShowRezervasyonlarim),
            };

            int my = 120;
            foreach (var (icon, text, action) in menuItems)
            {
                var btn = MakeMenuButton(icon, text, my);
                var capturedAction = action;
                btn.Click += (s, e) =>
                {
                    SetActiveMenu(btn);
                    capturedAction();
                };
                _sidebar.Controls.Add(btn);
                my += 56;
            }

            // Çıkış butonu en alta
            var btnCikis = MakeMenuButton("", "Çıkış Yap", H - TH - 60);
            btnCikis.ForeColor = AppTheme.Danger;
            btnCikis.Click += (s, e) => Close();
            _sidebar.Controls.Add(btnCikis);

            // Sağ kenar çizgisi
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
        //  İçerik Sayfaları
        // ════════════════════════════════════════════════════════════════════

        private void ShowAnaSayfa()
        {
            _contentArea.Controls.Clear();
            int cw = W - SW - 40;

            var lblH = UIHelper.MakeLabel("Ana Sayfa", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 24, 400, 36);
            _contentArea.Controls.Add(lblH);

            // Hoş geldin kartı
            var welcomeCard = UIHelper.MakeCard(24, 76, cw, 110, AppTheme.BgCard);
            string welText = $"Hoş geldiniz, {SessionManager.AktifKullanici?.TamAd}!";
            var lblWel = UIHelper.MakeLabel(welText, AppTheme.SubFont,
                AppTheme.TextLight, 20, 18, cw - 40, 32);
            var lblWelSub = UIHelper.MakeLabel(
                "Denizaltı serüveninizi planlamak için hazır mısınız?",
                AppTheme.BodyFont, AppTheme.TextMuted, 20, 56, cw - 40, 28);
            welcomeCard.Controls.AddRange(new Control[] { lblWel, lblWelSub });
            _contentArea.Controls.Add(welcomeCard);

            // İstatistik kartları
            var rezervasyonlar = RezervasyonDAL.KullanicininRezervasyonlari(
                SessionManager.AktifKullanici.Id);

            int aktifRez   = 0, toplamRez = rezervasyonlar.Count;
            double toplamHarcama = 0;
            foreach (var r in rezervasyonlar)
            {
                if (r.Durum == "Onaylandi") aktifRez++;
                if (r.Durum != "Iptal")      toplamHarcama += r.ToplamTutar;
            }

            var statlar = new (string Baslik, string Deger, Color Renk)[]
            {
                ("Toplam Rezervasyon", toplamRez.ToString(),          AppTheme.Accent),
                ("Aktif Rezervasyon",  aktifRez.ToString(),           AppTheme.Success),
                ("Toplam Harcama",     $"{toplamHarcama:N0} TL",      AppTheme.Warning),
            };

            int sx = 24, cardW = (cw - 48) / 3;
            foreach (var (baslik, deger, renk) in statlar)
            {
                var card = UIHelper.MakeCard(sx, 206, cardW, 100);
                var lDeger = UIHelper.MakeLabel(deger, AppTheme.TitleFont, renk, 0, 12, cardW, 40);
                lDeger.TextAlign = ContentAlignment.MiddleCenter;
                var lBaslik = UIHelper.MakeLabel(baslik, AppTheme.SmallFont,
                    AppTheme.TextMuted, 0, 56, cardW, 24);
                lBaslik.TextAlign = ContentAlignment.MiddleCenter;
                card.Controls.AddRange(new Control[] { lDeger, lBaslik });
                _contentArea.Controls.Add(card);
                sx += cardW + 24;
            }

            // Son rezervasyonlar
            var lblSon = UIHelper.MakeLabel("Son Rezervasyonlar", AppTheme.SubFont,
                AppTheme.TextLight, 24, 326, 300, 28);
            _contentArea.Controls.Add(lblSon);

            var dgv = new DataGridView
            {
                Location = new Point(24, 362),
                Size     = new Size(cw, 340),
            };
            UIHelper.StyleGrid(dgv);
            dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "DekontNo",    HeaderText = "Dekont No",    FillWeight = 18 },
                new DataGridViewTextBoxColumn { Name = "Sefer",       HeaderText = "Sefer",        FillWeight = 32 },
                new DataGridViewTextBoxColumn { Name = "Tarih",       HeaderText = "Sefer Tarihi", FillWeight = 18 },
                new DataGridViewTextBoxColumn { Name = "Kisi",        HeaderText = "Kişi",         FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Tutar",       HeaderText = "Tutar",        FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Durum",       HeaderText = "Durum",        FillWeight = 14 }
            );

            foreach (var r in rezervasyonlar)
            {
                int idx = dgv.Rows.Add(r.DekontNo, r.SeferBilgisi, r.SeferTarihiStr,
                    r.KisiSayisi, r.ToplamTutarStr, UIHelper.DurumMetni(r.Durum));
                dgv.Rows[idx].DefaultCellStyle.ForeColor = UIHelper.DurumRengi(r.Durum);
            }
            _contentArea.Controls.Add(dgv);
        }

        private void ShowYeniRezervason()
        {
            _contentArea.Controls.Clear();
            var form = new YeniRezervasyonForm();
            form.RezervasyonTamamlandi += () =>
            {
                SetActiveMenu(null);
                ShowAnaSayfa();
            };
            form.Location = new Point(0, 0);
            form.Size     = new Size(W - SW, H - TH);
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            _contentArea.Controls.Add(form);
            form.Show();
        }

        private void ShowRezervasyonlarim()
        {
            _contentArea.Controls.Clear();
            int cw = W - SW - 40;

            var lblH = UIHelper.MakeLabel("Rezervasyonlarım", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 24, 400, 36);
            _contentArea.Controls.Add(lblH);

            var dgv = new DataGridView
            {
                Location = new Point(24, 72),
                Size     = new Size(cw, H - TH - 140),
            };
            UIHelper.StyleGrid(dgv);
            dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",       HeaderText = "ID",           FillWeight = 6,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "DekontNo", HeaderText = "Dekont No",    FillWeight = 16 },
                new DataGridViewTextBoxColumn { Name = "Sefer",    HeaderText = "Sefer",        FillWeight = 30 },
                new DataGridViewTextBoxColumn { Name = "STarih",   HeaderText = "Sefer Tarihi", FillWeight = 16 },
                new DataGridViewTextBoxColumn { Name = "Kisi",     HeaderText = "Kişi Sayısı",  FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Tutar",    HeaderText = "Tutar",        FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Durum",    HeaderText = "Durum",        FillWeight = 14 }
            );

            var rezervasyonlar = RezervasyonDAL.KullanicininRezervasyonlari(
                SessionManager.AktifKullanici.Id);

            foreach (var r in rezervasyonlar)
            {
                int idx = dgv.Rows.Add(r.Id, r.DekontNo, r.SeferBilgisi, r.SeferTarihiStr,
                    r.KisiSayisi, r.ToplamTutarStr, UIHelper.DurumMetni(r.Durum));
                dgv.Rows[idx].DefaultCellStyle.ForeColor = UIHelper.DurumRengi(r.Durum);
            }

            // Detay/Talep buton satırı
            var btnDetay = UIHelper.MakeButton("Detay / Talep Oluştur", 24, H - TH - 62, 260, 44);
            btnDetay.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count == 0) return;
                int rezId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                var secili = rezervasyonlar.Find(x => x.Id == rezId);
                if (secili == null) return;
                using (var detay = new RezervasyonDetayForm(secili))
                {
                    detay.ShowDialog(this);
                    ShowRezervasyonlarim(); // yenile
                }
            };

            _contentArea.Controls.AddRange(new Control[] { lblH, dgv, btnDetay });
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
                btn.BackColor = Color.FromArgb(20, 14, 165, 233);
                btn.ForeColor = AppTheme.Accent;
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
