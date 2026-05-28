using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{

    public partial class LoginForm : Form
    {
        private const int W = 1000, H = 620;
        private const int LeftW = 390;

        public LoginForm()
        {
            InitializeComponent();
            UIHelper.EnableDrag(_leftPanel, this);
            UIHelper.EnableDrag(_rightPanel, this);

          

            _btnToggleLogin.Click    += (s, e) => ShowPanel(true);
            _btnToggleRegister.Click += (s, e) => ShowPanel(false);
            _btnGiris.Click          += BtnGiris_Click;
            _btnKayit.Click          += BtnKayit_Click;
            _leftPanel.Paint         += LeftPanel_Paint;

            ShowPanel(true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
                return cp;
            }
        }

        private void ShowPanel(bool loginMi)
        {
            _loginPanel.Visible    = loginMi;
            _registerPanel.Visible = !loginMi;

            _btnToggleLogin.BackColor    = loginMi ? Color.FromArgb(14, 165, 233) : Color.FromArgb(30, 41, 59);
            _btnToggleLogin.ForeColor    = loginMi ? Color.White                   : Color.FromArgb(100, 116, 139);
            _btnToggleRegister.BackColor = loginMi ? Color.FromArgb(30, 41, 59)   : Color.FromArgb(14, 165, 233);
            _btnToggleRegister.ForeColor = loginMi ? Color.FromArgb(100, 116, 139) : Color.White;
        }

        private void LeftPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(30, 41, 59), 1))
                e.Graphics.DrawLine(pen, LeftW - 1, 0, LeftW - 1, H);
        }

   
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            _lblLoginError.Text      = "";
            _lblLoginError.ForeColor = Color.FromArgb(239, 68, 68);

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

            _txtLoginUser.Text = "";
            _txtLoginPass.Text = "";
        }

        private void _btnToggleLogin_Click(object sender, EventArgs e)
        {

        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            _lblRegError.Text      = "";
            _lblRegError.ForeColor = Color.FromArgb(239, 68, 68);

            string ad    = _txtRegAd.Text.Trim();
            string soyad = _txtRegSoyad.Text.Trim();
            string user  = _txtRegUser.Text.Trim();
            string pass  = _txtRegPass.Text;

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
                _lblRegError.ForeColor = Color.FromArgb(16, 185, 129);
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
