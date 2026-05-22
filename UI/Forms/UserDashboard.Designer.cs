namespace oceangate_r
{
    partial class UserDashboard
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

            this._titleBar    = new System.Windows.Forms.Panel();
            this._sidebar     = new System.Windows.Forms.Panel();
            this._contentArea = new System.Windows.Forms.Panel();
            this._userCard    = new System.Windows.Forms.Panel();

            this._lblLogo         = new System.Windows.Forms.Label();
            this._lblPanelTag     = new System.Windows.Forms.Label();
            this._lblUserName     = new System.Windows.Forms.Label();



            this._lblAvatar       = new System.Windows.Forms.Label();
            this._lblUserFullName = new System.Windows.Forms.Label();

            this._btnMenuAnaSayfa = new System.Windows.Forms.Button();
            this._btnMenuYeniRez  = new System.Windows.Forms.Button();
            this._btnMenuRezlerim = new System.Windows.Forms.Button();
            this._btnCikis        = new System.Windows.Forms.Button();

            // ── Title Bar ────────────────────────────────────────────────────
            this._titleBar.Location  = new System.Drawing.Point(0, 0);
            this._titleBar.Size      = new System.Drawing.Size(1150, 50);
            this._titleBar.BackColor = System.Drawing.Color.FromArgb(10, 15, 30);

            this._lblLogo.Text      = "OCEANGATE";
            this._lblLogo.Location  = new System.Drawing.Point(20, 0);
            this._lblLogo.Size      = new System.Drawing.Size(250, 50);
            this._lblLogo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this._lblLogo.ForeColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this._lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblLogo.BackColor = System.Drawing.Color.Transparent;

            this._lblPanelTag.Text      = "Kullanıcı Paneli";
            this._lblPanelTag.Location  = new System.Drawing.Point(280, 0);
            this._lblPanelTag.Size      = new System.Drawing.Size(300, 50);
            this._lblPanelTag.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblPanelTag.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblPanelTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblPanelTag.BackColor = System.Drawing.Color.Transparent;

            this._lblUserName.Text      = "";
            this._lblUserName.Location  = new System.Drawing.Point(1030, 0);
            this._lblUserName.Size      = new System.Drawing.Size(200, 50);
            this._lblUserName.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblUserName.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._lblUserName.BackColor = System.Drawing.Color.Transparent;





















            this._titleBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lblLogo, this._lblPanelTag, this._lblUserName,

            });

            // ── Sidebar ──────────────────────────────────────────────────────
            this._sidebar.Location  = new System.Drawing.Point(0, 50);
            this._sidebar.Size      = new System.Drawing.Size(230, 550);
            this._sidebar.Anchor    = System.Windows.Forms.AnchorStyles.Top
                                    | System.Windows.Forms.AnchorStyles.Left
                                    | System.Windows.Forms.AnchorStyles.Bottom;
            this._sidebar.BackColor = System.Drawing.Color.FromArgb(10, 15, 30);

            this._userCard.Location  = new System.Drawing.Point(0, 0);
            this._userCard.Size      = new System.Drawing.Size(230, 100);
            this._userCard.BackColor = System.Drawing.Color.FromArgb(15, 28, 52);

            this._lblAvatar.Text      = "👤";
            this._lblAvatar.Location  = new System.Drawing.Point(0, 12);
            this._lblAvatar.Size      = new System.Drawing.Size(230, 48);
            this._lblAvatar.Font      = new System.Drawing.Font("Segoe UI", 22F);
            this._lblAvatar.ForeColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this._lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblAvatar.BackColor = System.Drawing.Color.Transparent;

            this._lblUserFullName.Text      = "";
            this._lblUserFullName.Location  = new System.Drawing.Point(0, 64);
            this._lblUserFullName.Size      = new System.Drawing.Size(230, 24);
            this._lblUserFullName.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblUserFullName.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblUserFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblUserFullName.BackColor = System.Drawing.Color.Transparent;

            this._userCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lblAvatar, this._lblUserFullName
            });

            this._btnMenuAnaSayfa.Text      = "  ⌂  Ana Sayfa";
            this._btnMenuAnaSayfa.Location  = new System.Drawing.Point(0, 120);
            this._btnMenuAnaSayfa.Size      = new System.Drawing.Size(230, 48);
            this._btnMenuAnaSayfa.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._btnMenuAnaSayfa.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuAnaSayfa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuAnaSayfa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnMenuAnaSayfa.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuAnaSayfa.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnMenuAnaSayfa.FlatAppearance.BorderSize = 0;
            this._btnMenuAnaSayfa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 255, 255, 255);

            this._btnMenuYeniRez.Text      = "  ✚  Yeni Rezervasyon";
            this._btnMenuYeniRez.Location  = new System.Drawing.Point(0, 176);
            this._btnMenuYeniRez.Size      = new System.Drawing.Size(230, 48);
            this._btnMenuYeniRez.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._btnMenuYeniRez.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuYeniRez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuYeniRez.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnMenuYeniRez.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuYeniRez.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnMenuYeniRez.FlatAppearance.BorderSize = 0;
            this._btnMenuYeniRez.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 255, 255, 255);

            this._btnMenuRezlerim.Text      = "  ⚓  Rezervasyonlarım";
            this._btnMenuRezlerim.Location  = new System.Drawing.Point(0, 232);
            this._btnMenuRezlerim.Size      = new System.Drawing.Size(230, 48);
            this._btnMenuRezlerim.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._btnMenuRezlerim.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuRezlerim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuRezlerim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnMenuRezlerim.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuRezlerim.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnMenuRezlerim.FlatAppearance.BorderSize = 0;
            this._btnMenuRezlerim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 255, 255, 255);

            this._btnCikis.Text      = "  ✕  Çıkış Yap";
            this._btnCikis.Location  = new System.Drawing.Point(0, 490);
            this._btnCikis.Size      = new System.Drawing.Size(230, 48);
            this._btnCikis.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this._btnCikis.BackColor = System.Drawing.Color.Transparent;
            this._btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCikis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnCikis.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this._btnCikis.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnCikis.FlatAppearance.BorderSize = 0;
            this._btnCikis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 255, 255, 255);

            this._sidebar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._userCard,
                this._btnMenuAnaSayfa, this._btnMenuYeniRez,
                this._btnMenuRezlerim, this._btnCikis
            });

            // ── Content Area ──────────────────────────────────────────────────
            this._contentArea.Location   = new System.Drawing.Point(230, 50);
            this._contentArea.Size       = new System.Drawing.Size(1190, 550);
            this._contentArea.Anchor     = System.Windows.Forms.AnchorStyles.Top
                                         | System.Windows.Forms.AnchorStyles.Left
                                         | System.Windows.Forms.AnchorStyles.Right
                                         | System.Windows.Forms.AnchorStyles.Bottom;
            this._contentArea.BackColor  = System.Drawing.Color.FromArgb(15, 23, 42);
            this._contentArea.AutoScroll = true;

            // ── Form Özellikleri ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximizeBox = false;
            this.BackColor      = System.Drawing.Color.FromArgb(10, 15, 30);
            this.ClientSize     = new System.Drawing.Size(1420, 550);
            this.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor      = System.Drawing.Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name           = "UserDashboard";
            this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text           = "OceanGate – Kullanıcı Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._titleBar, this._sidebar, this._contentArea
            });

            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel _titleBar;
        private System.Windows.Forms.Panel _sidebar;
        private System.Windows.Forms.Panel _contentArea;
        private System.Windows.Forms.Panel _userCard;
        private System.Windows.Forms.Label _lblLogo;
        private System.Windows.Forms.Label _lblPanelTag;
        private System.Windows.Forms.Label _lblUserName;
        private System.Windows.Forms.Label _lblUserFullName;
        private System.Windows.Forms.Label _lblAvatar;


        private System.Windows.Forms.Button _btnMenuAnaSayfa;
        private System.Windows.Forms.Button _btnMenuYeniRez;
        private System.Windows.Forms.Button _btnMenuRezlerim;
        private System.Windows.Forms.Button _btnCikis;
        private System.Windows.Forms.Button _activeMenu;
    }
}
