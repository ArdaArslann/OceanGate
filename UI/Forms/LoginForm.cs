using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>
    /// Uygulama giriş noktası formu. Giriş Yap ve Kayıt Ol seçeneklerini sunar.
    /// </summary>
    public class LoginForm : Form
    {
        // Paneller 
        private Panel _leftPanel;
        private Panel _rightPanel;
        private Panel _loginPanel;
        private Panel _registerPanel;

        // Toggle butonları 
        private Button _btnToggleLogin;
        private Button _btnToggleRegister;

        // Giriş alanları 
        private OceanTextBox _txtLoginUser;
        private OceanTextBox _txtLoginPass;
        private OceanButton  _btnGiris;
        private Label        _lblLoginError;

        // Kayıt alanları 
        private OceanTextBox _txtRegAd;
        private OceanTextBox _txtRegSoyad;
        private OceanTextBox _txtRegUser;
        private OceanTextBox _txtRegPass;
        private OceanButton  _btnKayit;
        private Label        _lblRegError;

        private const int W = 1000, H = 620;
        private const int LeftW = 390;

        public LoginForm()
        {
            UIHelper.ApplyFormStyle(this);
            Size           = new Size(W, H);
            StartPosition  = FormStartPosition.CenterScreen;

            BuildUI();
        }

        // Drop shadow 
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
                return cp;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  UI İnşası
        // ════════════════════════════════════════════════════════════════════

        private void BuildUI()
        {
            BuildLeftPanel();
            BuildRightPanel();
        }

        // Sol Panel – Branding 

        private void BuildLeftPanel()
        {
            _leftPanel = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(LeftW, H),
                BackColor = AppTheme.BgSidebar,
            };
            _leftPanel.Paint += LeftPanel_Paint;
            UIHelper.EnableDrag(_leftPanel, this);

            // Dalga ikonu
            var lblWave = UIHelper.MakeLabel("", new Font("Segoe UI", 42f, FontStyle.Regular, GraphicsUnit.Point),
                AppTheme.Accent, 0, 130, LeftW, 70);
            lblWave.TextAlign = ContentAlignment.MiddleCenter;

            // Logo
            var lblLogo = UIHelper.MakeLabel("OCEANGATE", AppTheme.LargeTitle,
                AppTheme.Accent, 0, 210, LeftW, 50);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            // Tagline
            var lblTag = UIHelper.MakeLabel("Derin Okyanusların Kapısı", AppTheme.TaglineFont,
                AppTheme.TextMuted, 0, 268, LeftW, 28);
            lblTag.TextAlign = ContentAlignment.MiddleCenter;

            // Ayırıcı çizgi
            var sep = new Panel
            {
                Location  = new Point(60, 310),
                Size      = new Size(LeftW - 120, 1),
                BackColor = AppTheme.Border,
            };

            // Özellikler
            string[] ozellikler = {
                "🐋  Benzersiz Denizaltı Rotaları",
                "🏨  Su Altı Otel Rezervasyonu",
                "⚡  Anlık Rezervasyon Yönetimi",
                "🔐  Güvenli Giriş Sistemi",
            };
            int oy = 330;
            foreach (var oz in ozellikler)
            {
                var l = UIHelper.MakeLabel(oz, AppTheme.SmallFont, AppTheme.TextMuted,
                    24, oy, LeftW - 48, 24);
                _leftPanel.Controls.Add(l);
                oy += 30;
            }

            _leftPanel.Controls.AddRange(new Control[] { lblWave, lblLogo, lblTag, sep });
            Controls.Add(_leftPanel);
        }

        private void LeftPanel_Paint(object sender, PaintEventArgs e)
        {
            // Sağ kenara ince accent çizgisi
            using (var pen = new Pen(AppTheme.Border, 1))
                e.Graphics.DrawLine(pen, LeftW - 1, 0, LeftW - 1, H);
        }

        // Sağ Panel – Form Alanı 

        private void BuildRightPanel()
        {
            _rightPanel = new Panel
            {
                Location  = new Point(LeftW, 0),
                Size      = new Size(W - LeftW, H),
                BackColor = AppTheme.BgMedium,
            };

            // Kapat butonu
            var btnClose = new Button
            {
                Text      = "X",
                Font      = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = AppTheme.TextMuted,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(32, 32),
                Location  = new Point(W - LeftW - 42, 10),
                Cursor    = Cursors.Hand,
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => Application.Exit();

            // Başlık
            var lblBaslik = UIHelper.MakeLabel("Hesabınıza Giriş Yapın", AppTheme.TitleFont,
                AppTheme.TextLight, 0, 60, W - LeftW, 40);
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            // Toggle buton çerçevesi
            var toggleBg = new Panel
            {
                Location  = new Point(40, 120),
                Size      = new Size(W - LeftW - 80, 44),
                BackColor = AppTheme.BgCard,
            };

            _btnToggleLogin = new Button
            {
                Text      = "GİRİŞ YAP",
                Font      = AppTheme.BodyBold,
                ForeColor = AppTheme.TextLight,
                BackColor = AppTheme.Accent,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size((W - LeftW - 80) / 2, 44),
                Location  = new Point(0, 0),
                Cursor    = Cursors.Hand,
            };
            _btnToggleLogin.FlatAppearance.BorderSize = 0;
            _btnToggleLogin.Click += (s, e) => ShowPanel(true);

            _btnToggleRegister = new Button
            {
                Text      = "KAYIT OL",
                Font      = AppTheme.BodyBold,
                ForeColor = AppTheme.TextMuted,
                BackColor = AppTheme.BgCard,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size((W - LeftW - 80) / 2, 44),
                Location  = new Point((W - LeftW - 80) / 2, 0),
                Cursor    = Cursors.Hand,
            };
            _btnToggleRegister.FlatAppearance.BorderSize = 0;
            _btnToggleRegister.Click += (s, e) => ShowPanel(false);

            toggleBg.Controls.AddRange(new Control[] { _btnToggleLogin, _btnToggleRegister });

            // İçerik panelleri
            BuildLoginPanel();
            BuildRegisterPanel();

            _rightPanel.Controls.AddRange(new Control[]
            {
                btnClose, lblBaslik, toggleBg, _loginPanel, _registerPanel,
            });

            Controls.Add(_rightPanel);
            ShowPanel(true);
        }

        private void BuildLoginPanel()
        {
            int px = 40, pw = W - LeftW - 80;
            _loginPanel = new Panel
            {
                Location  = new Point(0, 175),
                Size      = new Size(W - LeftW, H - 175),
                BackColor = Color.Transparent,
            };

            _txtLoginUser = new OceanTextBox
            {
                PlaceholderText = "Kullanıcı Adı",
                Location        = new Point(px, 20),
                Size            = new Size(pw, 44),
                BackColor       = AppTheme.BgMedium,
            };

            _txtLoginPass = new OceanTextBox
            {
                PlaceholderText      = "Şifre",
                UseSystemPasswordChar = true,
                Location             = new Point(px, 90),
                Size                 = new Size(pw, 44),
                BackColor            = AppTheme.BgMedium,
            };

            _btnGiris = UIHelper.MakeButton("Giriş Yap", px, 160, pw, 48);
            _btnGiris.Click += BtnGiris_Click;

            _lblLoginError = UIHelper.MakeLabel("", AppTheme.SmallFont, AppTheme.Danger,
                px, 225, pw, 24);
            _lblLoginError.TextAlign = ContentAlignment.MiddleCenter;

            // Demo bilgisi
            var lblDemo = UIHelper.MakeLabel("Demo Admin: admin / admin123", AppTheme.SmallFont,
                AppTheme.TextDim, px, 260, pw, 24);
            lblDemo.TextAlign = ContentAlignment.MiddleCenter;

            _loginPanel.Controls.AddRange(new Control[]
            {
                _txtLoginUser, _txtLoginPass, _btnGiris, _lblLoginError, lblDemo,
            });
        }

        private void BuildRegisterPanel()
        {
            int px = 40, pw = W - LeftW - 80;
            _registerPanel = new Panel
            {
                Location  = new Point(0, 175),
                Size      = new Size(W - LeftW, H - 175),
                BackColor = Color.Transparent,
                Visible   = false,
            };

            _txtRegAd = new OceanTextBox
            {
                PlaceholderText = "Ad",
                Location        = new Point(px, 20),
                Size            = new Size((pw - 12) / 2, 44),
                BackColor       = AppTheme.BgMedium,
            };

            _txtRegSoyad = new OceanTextBox
            {
                PlaceholderText = "Soyad",
                Location        = new Point(px + (pw - 12) / 2 + 12, 20),
                Size            = new Size((pw - 12) / 2, 44),
                BackColor       = AppTheme.BgMedium,
            };

            _txtRegUser = new OceanTextBox
            {
                PlaceholderText = "Kullanıcı Adı",
                Location        = new Point(px, 88),
                Size            = new Size(pw, 44),
                BackColor       = AppTheme.BgMedium,
            };

            _txtRegPass = new OceanTextBox
            {
                PlaceholderText       = "Şifre (en az 6 karakter)",
                UseSystemPasswordChar = true,
                Location              = new Point(px, 156),
                Size                  = new Size(pw, 44),
                BackColor             = AppTheme.BgMedium,
            };

            _btnKayit = UIHelper.MakeButton("Hesap Oluştur", px, 226, pw, 48);
            _btnKayit.SetSuccess();
            _btnKayit.Click += BtnKayit_Click;

            _lblRegError = UIHelper.MakeLabel("", AppTheme.SmallFont, AppTheme.Danger,
                px, 290, pw, 24);
            _lblRegError.TextAlign = ContentAlignment.MiddleCenter;

            _registerPanel.Controls.AddRange(new Control[]
            {
                _txtRegAd, _txtRegSoyad, _txtRegUser, _txtRegPass, _btnKayit, _lblRegError,
            });
        }

        private void ShowPanel(bool loginMi)
        {
            _loginPanel.Visible    = loginMi;
            _registerPanel.Visible = !loginMi;

            _btnToggleLogin.BackColor    = loginMi ? AppTheme.Accent    : AppTheme.BgCard;
            _btnToggleLogin.ForeColor    = loginMi ? AppTheme.TextLight  : AppTheme.TextMuted;
            _btnToggleRegister.BackColor = loginMi ? AppTheme.BgCard     : AppTheme.Accent;
            _btnToggleRegister.ForeColor = loginMi ? AppTheme.TextMuted  : AppTheme.TextLight;
        }

        // ════════════════════════════════════════════════════════════════════
        //  Olay İşleyicileri
        // ════════════════════════════════════════════════════════════════════

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            _lblLoginError.Text = "";
            string user = _txtLoginUser.Text.Trim();
            string pass = _txtLoginPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                _lblLoginError.Text = "Kullanıcı adı ve şifre giriniz.";
                return;
            }

            var kullanici = KullaniciDAL.GirisKontrol(user, pass);
            if (kullanici == null)
            {
                _lblLoginError.Text = "Kullanıcı adı veya şifre hatalı!";
                return;
            }

            SessionManager.GirisYap(kullanici);

            if (kullanici.Rol == "admin")
            {
                var admin = new AdminDashboard();
                admin.FormClosed += (s2, e2) => { SessionManager.CikisYap(); Show(); };
                Hide();
                admin.Show();
            }
            else
            {
                var dash = new UserDashboard();
                dash.FormClosed += (s2, e2) => { SessionManager.CikisYap(); Show(); };
                Hide();
                dash.Show();
            }

            // Alanları temizle
            _txtLoginUser.Text = "";
            _txtLoginPass.Text = "";
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            _lblRegError.Text = "";

            string ad   = _txtRegAd.Text.Trim();
            string soyad= _txtRegSoyad.Text.Trim();
            string user = _txtRegUser.Text.Trim();
            string pass = _txtRegPass.Text;

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) ||
                string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                _lblRegError.Text = "Tüm alanları doldurunuz.";
                return;
            }
            if (pass.Length < 6)
            {
                _lblRegError.Text = "Şifre en az 6 karakter olmalıdır.";
                return;
            }
            if (KullaniciDAL.KullaniciAdiVarMi(user))
            {
                _lblRegError.Text = "Bu kullanıcı adı zaten kullanılıyor.";
                return;
            }

            bool basarili = KullaniciDAL.KayitOl(ad, soyad, user, pass);
            if (basarili)
            {
                _lblRegError.ForeColor = AppTheme.Success;
                _lblRegError.Text = "Kayıt başarılı! Giriş yapabilirsiniz.";
                _txtRegAd.Text = _txtRegSoyad.Text = _txtRegUser.Text = _txtRegPass.Text = "";
                ShowPanel(true);
            }
            else
            {
                _lblRegError.Text = "Kayıt sırasında bir hata oluştu.";
            }
        }
    }
}
