namespace oceangate_r
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this._leftPanel      = new System.Windows.Forms.Panel();
            this._rightPanel     = new System.Windows.Forms.Panel();
            this._loginPanel     = new System.Windows.Forms.Panel();
            this._registerPanel  = new System.Windows.Forms.Panel();
            this._toggleBg       = new System.Windows.Forms.Panel();
            this._lblSep         = new System.Windows.Forms.Panel();

            this._lblWave    = new System.Windows.Forms.Label();
            this._lblLogo    = new System.Windows.Forms.Label();
            this._lblTagline = new System.Windows.Forms.Label();
            this._lblFeat1   = new System.Windows.Forms.Label();
            this._lblFeat2   = new System.Windows.Forms.Label();
            this._lblFeat3   = new System.Windows.Forms.Label();
            this._lblFeat4   = new System.Windows.Forms.Label();

            this._lblBaslik          = new System.Windows.Forms.Label();
            this._btnToggleLogin     = new System.Windows.Forms.Button();
            this._btnToggleRegister  = new System.Windows.Forms.Button();


            this._txtLoginUser  = new oceangate_r.UI.Controls.OceanTextBox();
            this._txtLoginPass  = new oceangate_r.UI.Controls.OceanTextBox();
            this._btnGiris      = new oceangate_r.UI.Controls.OceanButton();
            this._lblLoginError = new System.Windows.Forms.Label();
            this._lblDemo       = new System.Windows.Forms.Label();

            this._txtRegAd    = new oceangate_r.UI.Controls.OceanTextBox();
            this._txtRegSoyad = new oceangate_r.UI.Controls.OceanTextBox();
            this._txtRegUser  = new oceangate_r.UI.Controls.OceanTextBox();
            this._txtRegPass  = new oceangate_r.UI.Controls.OceanTextBox();
            this._btnKayit    = new oceangate_r.UI.Controls.OceanButton();
            this._lblRegError = new System.Windows.Forms.Label();

            // ── SOL PANEL ────────────────────────────────────────────────────
            this._leftPanel.Location  = new System.Drawing.Point(0, 0);
            this._leftPanel.Size      = new System.Drawing.Size(390, 505);
            this._leftPanel.BackColor = System.Drawing.Color.FromArgb(10, 15, 30);

            this._lblWave.Text      = "🌊";
            this._lblWave.Location  = new System.Drawing.Point(0, 130);
            this._lblWave.Size      = new System.Drawing.Size(390, 70);
            this._lblWave.Font      = new System.Drawing.Font("Segoe UI", 38F);
            this._lblWave.ForeColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this._lblWave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblWave.BackColor = System.Drawing.Color.Transparent;

            this._lblLogo.Text      = "OCEANGATE";
            this._lblLogo.Location  = new System.Drawing.Point(0, 210);
            this._lblLogo.Size      = new System.Drawing.Size(390, 50);
            this._lblLogo.Font      = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this._lblLogo.ForeColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this._lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblLogo.BackColor = System.Drawing.Color.Transparent;

            this._lblTagline.Text      = "Derin Okyanusların Kapısı";
            this._lblTagline.Location  = new System.Drawing.Point(0, 268);
            this._lblTagline.Size      = new System.Drawing.Size(390, 28);
            this._lblTagline.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this._lblTagline.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblTagline.BackColor = System.Drawing.Color.Transparent;

            this._lblSep.Location  = new System.Drawing.Point(60, 310);
            this._lblSep.Size      = new System.Drawing.Size(270, 1);
            this._lblSep.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);

            this._lblFeat1.Text      = "🐋  Benzersiz Denizaltı Rotaları";
            this._lblFeat1.Location  = new System.Drawing.Point(24, 330);
            this._lblFeat1.Size      = new System.Drawing.Size(342, 24);
            this._lblFeat1.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFeat1.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblFeat1.BackColor = System.Drawing.Color.Transparent;

            this._lblFeat2.Text      = "🏨  Su Altı Otel Rezervasyonu";
            this._lblFeat2.Location  = new System.Drawing.Point(24, 362);
            this._lblFeat2.Size      = new System.Drawing.Size(342, 24);
            this._lblFeat2.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFeat2.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblFeat2.BackColor = System.Drawing.Color.Transparent;

            this._lblFeat3.Text      = "⚡  Anlık Rezervasyon Yönetimi";
            this._lblFeat3.Location  = new System.Drawing.Point(24, 394);
            this._lblFeat3.Size      = new System.Drawing.Size(342, 24);
            this._lblFeat3.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFeat3.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblFeat3.BackColor = System.Drawing.Color.Transparent;

            this._lblFeat4.Text      = "🔐  Güvenli Giriş Sistemi";
            this._lblFeat4.Location  = new System.Drawing.Point(24, 426);
            this._lblFeat4.Size      = new System.Drawing.Size(342, 24);
            this._lblFeat4.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFeat4.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblFeat4.BackColor = System.Drawing.Color.Transparent;

            this._leftPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lblWave, this._lblLogo, this._lblTagline, this._lblSep,
                this._lblFeat1, this._lblFeat2, this._lblFeat3, this._lblFeat4
            });

            // ── SAĞ PANEL ────────────────────────────────────────────────────
            this._rightPanel.Location  = new System.Drawing.Point(390, 0);
            this._rightPanel.Size      = new System.Drawing.Size(610, 505);
            this._rightPanel.BackColor = System.Drawing.Color.FromArgb(22, 33, 55);

            this._lblBaslik.Text      = "Hesabınıza Giriş Yapın";
            this._lblBaslik.Location  = new System.Drawing.Point(0, 60);
            this._lblBaslik.Size      = new System.Drawing.Size(610, 40);
            this._lblBaslik.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this._lblBaslik.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblBaslik.BackColor = System.Drawing.Color.Transparent;

            this._toggleBg.Location  = new System.Drawing.Point(40, 120);
            this._toggleBg.Size      = new System.Drawing.Size(530, 44);
            this._toggleBg.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);

            this._btnToggleLogin.Text      = "GİRİŞ YAP";
            this._btnToggleLogin.Location  = new System.Drawing.Point(0, 0);
            this._btnToggleLogin.Size      = new System.Drawing.Size(265, 44);
            this._btnToggleLogin.BackColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this._btnToggleLogin.ForeColor = System.Drawing.Color.White;
            this._btnToggleLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnToggleLogin.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnToggleLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnToggleLogin.FlatAppearance.BorderSize = 0;

            this._btnToggleRegister.Text      = "KAYIT OL";
            this._btnToggleRegister.Location  = new System.Drawing.Point(265, 0);
            this._btnToggleRegister.Size      = new System.Drawing.Size(265, 44);
            this._btnToggleRegister.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._btnToggleRegister.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._btnToggleRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnToggleRegister.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnToggleRegister.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnToggleRegister.FlatAppearance.BorderSize = 0;

            this._toggleBg.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._btnToggleLogin, this._btnToggleRegister
            });

            // ── GİRİŞ PANELİ ─────────────────────────────────────────────────
            this._loginPanel.Location  = new System.Drawing.Point(0, 175);
            this._loginPanel.Size      = new System.Drawing.Size(610, 330);
            this._loginPanel.BackColor = System.Drawing.Color.Transparent;

            this._txtLoginUser.Location        = new System.Drawing.Point(40, 20);
            this._txtLoginUser.Size            = new System.Drawing.Size(530, 44);
            this._txtLoginUser.BackColor       = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtLoginUser.PlaceholderText = "Kullanıcı Adı";

            this._txtLoginPass.Location             = new System.Drawing.Point(40, 90);
            this._txtLoginPass.Size                 = new System.Drawing.Size(530, 44);
            this._txtLoginPass.BackColor            = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtLoginPass.PlaceholderText      = "Şifre";
            this._txtLoginPass.UseSystemPasswordChar = true;

            this._btnGiris.Text     = "Giriş Yap";
            this._btnGiris.Location = new System.Drawing.Point(40, 160);
            this._btnGiris.Size     = new System.Drawing.Size(530, 48);

            this._lblLoginError.Text      = "";
            this._lblLoginError.Location  = new System.Drawing.Point(40, 225);
            this._lblLoginError.Size      = new System.Drawing.Size(530, 24);
            this._lblLoginError.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this._lblLoginError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this._lblLoginError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblLoginError.BackColor = System.Drawing.Color.Transparent;

            this._lblDemo.Text      = "Demo Admin: admin / admin123";
            this._lblDemo.Location  = new System.Drawing.Point(40, 260);
            this._lblDemo.Size      = new System.Drawing.Size(530, 24);
            this._lblDemo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this._lblDemo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this._lblDemo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblDemo.BackColor = System.Drawing.Color.Transparent;

            this._loginPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._txtLoginUser, this._txtLoginPass, this._btnGiris,
                this._lblLoginError, this._lblDemo
            });

            // ── KAYIT PANELİ ──────────────────────────────────────────────────
            this._registerPanel.Location  = new System.Drawing.Point(0, 175);
            this._registerPanel.Size      = new System.Drawing.Size(610, 330);
            this._registerPanel.BackColor = System.Drawing.Color.Transparent;
            this._registerPanel.Visible   = false;

            this._txtRegAd.Location        = new System.Drawing.Point(40, 20);
            this._txtRegAd.Size            = new System.Drawing.Size(255, 44);
            this._txtRegAd.BackColor       = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtRegAd.PlaceholderText = "Ad";

            this._txtRegSoyad.Location        = new System.Drawing.Point(315, 20);
            this._txtRegSoyad.Size            = new System.Drawing.Size(255, 44);
            this._txtRegSoyad.BackColor       = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtRegSoyad.PlaceholderText = "Soyad";

            this._txtRegUser.Location        = new System.Drawing.Point(40, 88);
            this._txtRegUser.Size            = new System.Drawing.Size(530, 44);
            this._txtRegUser.BackColor       = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtRegUser.PlaceholderText = "Kullanıcı Adı";

            this._txtRegPass.Location             = new System.Drawing.Point(40, 156);
            this._txtRegPass.Size                 = new System.Drawing.Size(530, 44);
            this._txtRegPass.BackColor            = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtRegPass.PlaceholderText      = "Şifre (en az 6 karakter)";
            this._txtRegPass.UseSystemPasswordChar = true;

            this._btnKayit.Text     = "Hesap Oluştur";
            this._btnKayit.Location = new System.Drawing.Point(40, 226);
            this._btnKayit.Size     = new System.Drawing.Size(530, 48);

            this._lblRegError.Text      = "";
            this._lblRegError.Location  = new System.Drawing.Point(40, 288);
            this._lblRegError.Size      = new System.Drawing.Size(530, 24);
            this._lblRegError.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this._lblRegError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this._lblRegError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblRegError.BackColor = System.Drawing.Color.Transparent;

            this._registerPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._txtRegAd, this._txtRegSoyad, this._txtRegUser,
                this._txtRegPass, this._btnKayit, this._lblRegError
            });

            this._rightPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lblBaslik, this._toggleBg,
                this._loginPanel, this._registerPanel
            });

            // ── Form Özellikleri ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximizeBox = false;
            this.BackColor      = System.Drawing.Color.FromArgb(22, 33, 55);
            this.ClientSize     = new System.Drawing.Size(1000, 505);
            this.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor      = System.Drawing.Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name           = "LoginForm";
            this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text           = "OceanGate – Giriş";

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._leftPanel, this._rightPanel
            });

            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel _leftPanel;
        private System.Windows.Forms.Panel _rightPanel;
        private System.Windows.Forms.Panel _loginPanel;
        private System.Windows.Forms.Panel _registerPanel;
        private System.Windows.Forms.Panel _toggleBg;
        private System.Windows.Forms.Panel _lblSep;
        private System.Windows.Forms.Label _lblWave;
        private System.Windows.Forms.Label _lblLogo;
        private System.Windows.Forms.Label _lblTagline;
        private System.Windows.Forms.Label _lblFeat1;
        private System.Windows.Forms.Label _lblFeat2;
        private System.Windows.Forms.Label _lblFeat3;
        private System.Windows.Forms.Label _lblFeat4;
        private System.Windows.Forms.Label _lblBaslik;
        private System.Windows.Forms.Button _btnToggleLogin;
        private System.Windows.Forms.Button _btnToggleRegister;

        private oceangate_r.UI.Controls.OceanTextBox _txtLoginUser;
        private oceangate_r.UI.Controls.OceanTextBox _txtLoginPass;
        private oceangate_r.UI.Controls.OceanButton  _btnGiris;
        private System.Windows.Forms.Label _lblLoginError;
        private System.Windows.Forms.Label _lblDemo;
        private oceangate_r.UI.Controls.OceanTextBox _txtRegAd;
        private oceangate_r.UI.Controls.OceanTextBox _txtRegSoyad;
        private oceangate_r.UI.Controls.OceanTextBox _txtRegUser;
        private oceangate_r.UI.Controls.OceanTextBox _txtRegPass;
        private oceangate_r.UI.Controls.OceanButton  _btnKayit;
        private System.Windows.Forms.Label _lblRegError;
    }
}
