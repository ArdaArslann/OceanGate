namespace oceangate_r
{
    partial class AdminDashboard
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
            this._lblAdminTag = new System.Windows.Forms.Label();
            this._sidebar = new System.Windows.Forms.Panel();
            this._userCard = new System.Windows.Forms.Panel();
            this._lblAvatar = new System.Windows.Forms.Label();
            this._lblRole = new System.Windows.Forms.Label();
            this._btnMenuGenel = new System.Windows.Forms.Button();
            this._btnMenuBolge = new System.Windows.Forms.Button();
            this._btnMenuSefer = new System.Windows.Forms.Button();
            this._btnMenuTalep = new System.Windows.Forms.Button();
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
            this._titleBar.Controls.Add(this._lblAdminTag);
            this._titleBar.Location = new System.Drawing.Point(0, 0);
            this._titleBar.Name = "_titleBar";
            this._titleBar.Size = new System.Drawing.Size(1360, 50);
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
            // _lblAdminTag
            // 
            this._lblAdminTag.BackColor = System.Drawing.Color.Transparent;
            this._lblAdminTag.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblAdminTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this._lblAdminTag.Location = new System.Drawing.Point(280, 0);
            this._lblAdminTag.Name = "_lblAdminTag";
            this._lblAdminTag.Size = new System.Drawing.Size(200, 50);
            this._lblAdminTag.TabIndex = 1;
            this._lblAdminTag.Text = "Admin Paneli";
            this._lblAdminTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _sidebar
            // 
            this._sidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this._sidebar.Controls.Add(this._userCard);
            this._sidebar.Controls.Add(this._btnMenuGenel);
            this._sidebar.Controls.Add(this._btnMenuBolge);
            this._sidebar.Controls.Add(this._btnMenuSefer);
            this._sidebar.Controls.Add(this._btnMenuTalep);
            this._sidebar.Controls.Add(this._btnCikis);
            this._sidebar.Location = new System.Drawing.Point(0, 50);
            this._sidebar.Name = "_sidebar";
            this._sidebar.Size = new System.Drawing.Size(240, 550);
            this._sidebar.TabIndex = 1;
            // 
            // _userCard
            // 
            this._userCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(28)))), ((int)(((byte)(52)))));
            this._userCard.Controls.Add(this._lblAvatar);
            this._userCard.Controls.Add(this._lblRole);
            this._userCard.Location = new System.Drawing.Point(0, 0);
            this._userCard.Name = "_userCard";
            this._userCard.Size = new System.Drawing.Size(240, 100);
            this._userCard.TabIndex = 0;
            // 
            // _lblAvatar
            // 
            this._lblAvatar.BackColor = System.Drawing.Color.Transparent;
            this._lblAvatar.Font = new System.Drawing.Font("Segoe UI", 22F);
            this._lblAvatar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this._lblAvatar.Location = new System.Drawing.Point(94, 13);
            this._lblAvatar.Name = "_lblAvatar";
            this._lblAvatar.Size = new System.Drawing.Size(240, 48);
            this._lblAvatar.TabIndex = 0;
            this._lblAvatar.Text = "👤";
            this._lblAvatar.Click += new System.EventHandler(this._lblAvatar_Click);
            // 
            // _lblRole
            // 
            this._lblRole.BackColor = System.Drawing.Color.Transparent;
            this._lblRole.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this._lblRole.Location = new System.Drawing.Point(94, 65);
            this._lblRole.Name = "_lblRole";
            this._lblRole.Size = new System.Drawing.Size(240, 24);
            this._lblRole.TabIndex = 1;
            this._lblRole.Text = "YÖNETİCİ";
            this._lblRole.Click += new System.EventHandler(this._lblRole_Click);
            // 
            // _btnMenuGenel
            // 
            this._btnMenuGenel.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuGenel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnMenuGenel.FlatAppearance.BorderSize = 0;
            this._btnMenuGenel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnMenuGenel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuGenel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuGenel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnMenuGenel.Location = new System.Drawing.Point(0, 116);
            this._btnMenuGenel.Name = "_btnMenuGenel";
            this._btnMenuGenel.Size = new System.Drawing.Size(240, 48);
            this._btnMenuGenel.TabIndex = 1;
            this._btnMenuGenel.UseVisualStyleBackColor = false;
            // 
            // _btnMenuBolge
            // 
            this._btnMenuBolge.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuBolge.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnMenuBolge.FlatAppearance.BorderSize = 0;
            this._btnMenuBolge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnMenuBolge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuBolge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuBolge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnMenuBolge.Location = new System.Drawing.Point(0, 172);
            this._btnMenuBolge.Name = "_btnMenuBolge";
            this._btnMenuBolge.Size = new System.Drawing.Size(240, 48);
            this._btnMenuBolge.TabIndex = 2;
            this._btnMenuBolge.UseVisualStyleBackColor = false;
            // 
            // _btnMenuSefer
            // 
            this._btnMenuSefer.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuSefer.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnMenuSefer.FlatAppearance.BorderSize = 0;
            this._btnMenuSefer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnMenuSefer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuSefer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuSefer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnMenuSefer.Location = new System.Drawing.Point(0, 228);
            this._btnMenuSefer.Name = "_btnMenuSefer";
            this._btnMenuSefer.Size = new System.Drawing.Size(240, 48);
            this._btnMenuSefer.TabIndex = 3;
            this._btnMenuSefer.UseVisualStyleBackColor = false;
            // 
            // _btnMenuTalep
            // 
            this._btnMenuTalep.BackColor = System.Drawing.Color.Transparent;
            this._btnMenuTalep.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnMenuTalep.FlatAppearance.BorderSize = 0;
            this._btnMenuTalep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnMenuTalep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMenuTalep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnMenuTalep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnMenuTalep.Location = new System.Drawing.Point(0, 284);
            this._btnMenuTalep.Name = "_btnMenuTalep";
            this._btnMenuTalep.Size = new System.Drawing.Size(240, 48);
            this._btnMenuTalep.TabIndex = 5;
            this._btnMenuTalep.UseVisualStyleBackColor = false;
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
            this._btnCikis.Location = new System.Drawing.Point(0, 499);
            this._btnCikis.Name = "_btnCikis";
            this._btnCikis.Size = new System.Drawing.Size(240, 48);
            this._btnCikis.TabIndex = 6;
            this._btnCikis.UseVisualStyleBackColor = false;
            // 
            // _contentArea
            // 
            this._contentArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._contentArea.AutoScroll = true;
            this._contentArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this._contentArea.Location = new System.Drawing.Point(240, 50);
            this._contentArea.Name = "_contentArea";
            this._contentArea.Size = new System.Drawing.Size(1390, 550);
            this._contentArea.TabIndex = 2;
            // 
            // AdminDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1630, 650);
            this.Controls.Add(this._titleBar);
            this.Controls.Add(this._sidebar);
            this.Controls.Add(this._contentArea);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OceanGate – Admin Paneli";
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
        private System.Windows.Forms.Label _lblAdminTag;


        private System.Windows.Forms.Label _lblAvatar;
        private System.Windows.Forms.Label _lblRole;
        private System.Windows.Forms.Button _btnMenuGenel;
        private System.Windows.Forms.Button _btnMenuBolge;
        private System.Windows.Forms.Button _btnMenuSefer;
        private System.Windows.Forms.Button _btnMenuTalep;
        private System.Windows.Forms.Button _btnCikis;
        private System.Windows.Forms.Button _activeMenu;
    }
}

