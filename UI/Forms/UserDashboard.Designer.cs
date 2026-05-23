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

       

        private void InitializeComponent()
        {
            this._titleBar = new System.Windows.Forms.Panel();
            this._lblLogo = new System.Windows.Forms.Label();
            this._lblPanelTag = new System.Windows.Forms.Label();
            this._lblUserName = new System.Windows.Forms.Label();
            this._sidebar = new System.Windows.Forms.Panel();
            this._userCard = new System.Windows.Forms.Panel();
            this._lblAvatar = new System.Windows.Forms.Label();
            this._lblUserFullName = new System.Windows.Forms.Label();
            this._lblBakiye = new System.Windows.Forms.Label();
            this._btnBakiyeYukle = new System.Windows.Forms.Button();
            this._btnMenuAnaSayfa = new System.Windows.Forms.Button();
            this._btnMenuYeniRez = new System.Windows.Forms.Button();
            this._btnMenuRezlerim = new System.Windows.Forms.Button();
            this._btnCikis = new System.Windows.Forms.Button();
            this._contentArea = new System.Windows.Forms.Panel();
            this._titleBar.SuspendLayout();
            this._sidebar.SuspendLayout();
            this._userCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // _titleBar
            // 
            this._titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this._titleBar.Controls.Add(this._lblLogo);
            this._titleBar.Controls.Add(this._lblPanelTag);
            this._titleBar.Controls.Add(this._lblUserName);
            this._titleBar.Location = new System.Drawing.Point(0, 0);
            this._titleBar.Name = "_titleBar";
            this._titleBar.Size = new System.Drawing.Size(1150, 50);
            this._titleBar.TabIndex = 0;
            // 
            // _lblLogo
            // 
            this._lblLogo.BackColor = System.Drawing.Color.Transparent;
            this._lblLogo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this._lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this._lblLogo.Location = new System.Drawing.Point(20, 0);
            this._lblLogo.Name = "_lblLogo";
            this._lblLogo.Size = new System.Drawing.Size(250, 50);
            this._lblLogo.TabIndex = 0;
            this._lblLogo.Text = "OCEANGATE";
            this._lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblPanelTag
            // 
            this._lblPanelTag.BackColor = System.Drawing.Color.Transparent;
            this._lblPanelTag.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblPanelTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblPanelTag.Location = new System.Drawing.Point(280, 0);
            this._lblPanelTag.Name = "_lblPanelTag";
            this._lblPanelTag.Size = new System.Drawing.Size(300, 50);
            this._lblPanelTag.TabIndex = 1;
            this._lblPanelTag.Text = "Kullanıcı Paneli";
            this._lblPanelTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblUserName
            // 
            this._lblUserName.BackColor = System.Drawing.Color.Transparent;
            this._lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblUserName.Location = new System.Drawing.Point(1030, 0);
            this._lblUserName.Name = "_lblUserName";
            this._lblUserName.Size = new System.Drawing.Size(200, 50);
            this._lblUserName.TabIndex = 2;
            this._lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _sidebar
            // 
            this._sidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this._sidebar.Controls.Add(this._userCard);
            this._sidebar.Controls.Add(this._lblBakiye);
            this._sidebar.Controls.Add(this._btnBakiyeYukle);
            this._sidebar.Controls.Add(this._btnMenuAnaSayfa);
            this._sidebar.Controls.Add(this._btnMenuYeniRez);
            this._sidebar.Controls.Add(this._btnMenuRezlerim);
            this._sidebar.Controls.Add(this._btnCikis);
            this._sidebar.Location = new System.Drawing.Point(0, 50);
            this._sidebar.Name = "_sidebar";
            this._sidebar.Size = new System.Drawing.Size(230, 550);
            this._sidebar.TabIndex = 1;
            // 
            // _userCard
            // 
            this._userCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(28)))), ((int)(((byte)(52)))));
            this._userCard.Controls.Add(this._lblAvatar);
            this._userCard.Controls.Add(this._lblUserFullName);
            this._userCard.Location = new System.Drawing.Point(0, 0);
            this._userCard.Name = "_userCard";
            this._userCard.Size = new System.Drawing.Size(230, 100);
            this._userCard.TabIndex = 0;
            // 
            // _lblAvatar
            // 
            this._lblAvatar.BackColor = System.Drawing.Color.Transparent;
            this._lblAvatar.Font = new System.Drawing.Font("Segoe UI", 22F);
            this._lblAvatar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this._lblAvatar.Location = new System.Drawing.Point(87, 25);
            this._lblAvatar.Name = "_lblAvatar";
            this._lblAvatar.Size = new System.Drawing.Size(61, 48);
            this._lblAvatar.TabIndex = 0;
            this._lblAvatar.Text = "👤";
            // 
            // _lblUserFullName
            // 
            this._lblUserFullName.BackColor = System.Drawing.Color.Transparent;
            this._lblUserFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblUserFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblUserFullName.Location = new System.Drawing.Point(0, 64);
            this._lblUserFullName.Name = "_lblUserFullName";
            this._lblUserFullName.Size = new System.Drawing.Size(230, 24);
            this._lblUserFullName.TabIndex = 1;
            this._lblUserFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblBakiye
            // 
            this._lblBakiye.BackColor = System.Drawing.Color.Transparent;
            this._lblBakiye.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblBakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this._lblBakiye.Location = new System.Drawing.Point(0, 105);
            this._lblBakiye.Name = "_lblBakiye";
            this._lblBakiye.Size = new System.Drawing.Size(230, 25);
            this._lblBakiye.TabIndex = 1;
            this._lblBakiye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnBakiyeYukle
            // 
            this._btnBakiyeYukle.BackColor = System.Drawing.Color.Transparent;
            this._btnBakiyeYukle.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnBakiyeYukle.FlatAppearance.BorderSize = 0;
            this._btnBakiyeYukle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnBakiyeYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBakiyeYukle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnBakiyeYukle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnBakiyeYukle.Location = new System.Drawing.Point(0, 135);
            this._btnBakiyeYukle.Name = "_btnBakiyeYukle";
            this._btnBakiyeYukle.Size = new System.Drawing.Size(230, 48);
            this._btnBakiyeYukle.TabIndex = 2;
            this._btnBakiyeYukle.Text = "+ Bakiye Yükle";
            this._btnBakiyeYukle.UseVisualStyleBackColor = false;
            // 
            // _btnMenuAnaSayfa
            // 
            this._btnMenuAnaSayfa.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuAnaSayfa.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnMenuAnaSayfa.FlatAppearance.BorderSize = 0;
            this._btnMenuAnaSayfa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnMenuAnaSayfa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuAnaSayfa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuAnaSayfa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnMenuAnaSayfa.Location = new System.Drawing.Point(0, 190);
            this._btnMenuAnaSayfa.Name = "_btnMenuAnaSayfa";
            this._btnMenuAnaSayfa.Size = new System.Drawing.Size(230, 48);
            this._btnMenuAnaSayfa.TabIndex = 3;
            this._btnMenuAnaSayfa.Text = "Ana Sayfa";
            this._btnMenuAnaSayfa.UseVisualStyleBackColor = false;
            // 
            // _btnMenuYeniRez
            // 
            this._btnMenuYeniRez.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuYeniRez.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnMenuYeniRez.FlatAppearance.BorderSize = 0;
            this._btnMenuYeniRez.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnMenuYeniRez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuYeniRez.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuYeniRez.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnMenuYeniRez.Location = new System.Drawing.Point(0, 246);
            this._btnMenuYeniRez.Name = "_btnMenuYeniRez";
            this._btnMenuYeniRez.Size = new System.Drawing.Size(230, 48);
            this._btnMenuYeniRez.TabIndex = 4;
            this._btnMenuYeniRez.Text = "Yeni Rezervasyon";
            this._btnMenuYeniRez.UseVisualStyleBackColor = false;
            this._btnMenuYeniRez.Click += new System.EventHandler(this._btnMenuYeniRez_Click);
            // 
            // _btnMenuRezlerim
            // 
            this._btnMenuRezlerim.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuRezlerim.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnMenuRezlerim.FlatAppearance.BorderSize = 0;
            this._btnMenuRezlerim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnMenuRezlerim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuRezlerim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuRezlerim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnMenuRezlerim.Location = new System.Drawing.Point(0, 302);
            this._btnMenuRezlerim.Name = "_btnMenuRezlerim";
            this._btnMenuRezlerim.Size = new System.Drawing.Size(230, 48);
            this._btnMenuRezlerim.TabIndex = 5;
            this._btnMenuRezlerim.Text = "Rezervasyonlarım";
            this._btnMenuRezlerim.UseVisualStyleBackColor = false;
            // 
            // _btnCikis
            // 
            this._btnCikis.BackColor = System.Drawing.Color.Transparent;
            this._btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCikis.FlatAppearance.BorderSize = 0;
            this._btnCikis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCikis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnCikis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this._btnCikis.Location = new System.Drawing.Point(0, 490);
            this._btnCikis.Name = "_btnCikis";
            this._btnCikis.Size = new System.Drawing.Size(230, 48);
            this._btnCikis.TabIndex = 6;
            this._btnCikis.Text = "Çıkış Yap";
            this._btnCikis.UseVisualStyleBackColor = false;
            // 
            // _contentArea
            // 
            this._contentArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._contentArea.AutoScroll = true;
            this._contentArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this._contentArea.Location = new System.Drawing.Point(230, 50);
            this._contentArea.Name = "_contentArea";
            this._contentArea.Size = new System.Drawing.Size(1190, 550);
            this._contentArea.TabIndex = 2;
            // 
            // UserDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1280, 780);
            this.Controls.Add(this._titleBar);
            this.Controls.Add(this._sidebar);
            this.Controls.Add(this._contentArea);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OceanGate – Kullanıcı Paneli";
            this._titleBar.ResumeLayout(false);
            this._sidebar.ResumeLayout(false);
            this._userCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel _titleBar;
        private System.Windows.Forms.Panel _sidebar;
        private System.Windows.Forms.Panel _contentArea;
        private System.Windows.Forms.Panel _userCard;
        private System.Windows.Forms.Label _lblLogo;
        private System.Windows.Forms.Label _lblPanelTag;
        private System.Windows.Forms.Label _lblUserName;
        private System.Windows.Forms.Label _lblUserFullName;
        private System.Windows.Forms.Label _lblAvatar;


        private System.Windows.Forms.Label _lblBakiye;
        private System.Windows.Forms.Button _btnBakiyeYukle;
        private System.Windows.Forms.Button _btnMenuAnaSayfa;
        private System.Windows.Forms.Button _btnMenuYeniRez;
        private System.Windows.Forms.Button _btnMenuRezlerim;
        private System.Windows.Forms.Button _btnCikis;
        private System.Windows.Forms.Button _activeMenu;
    }
}

