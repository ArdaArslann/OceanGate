namespace oceangate_r
{
    partial class DekontForm
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
            this._successBar = new System.Windows.Forms.Panel();
            this._lblCheck = new System.Windows.Forms.Label();
            this._lblBaslik = new System.Windows.Forms.Label();
            this._lblSub = new System.Windows.Forms.Label();
            this._card = new System.Windows.Forms.Panel();
            this._cardTitle = new System.Windows.Forms.Label();
            this._separator = new System.Windows.Forms.Panel();
            this._btnYazdir = new System.Windows.Forms.Button();
            this._btnKapat = new System.Windows.Forms.Button();
            this._card.SuspendLayout();
            this.SuspendLayout();
            // 
            // _successBar
            // 
            this._successBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this._successBar.Location = new System.Drawing.Point(0, 0);
            this._successBar.Name = "_successBar";
            this._successBar.Size = new System.Drawing.Size(680, 8);
            this._successBar.TabIndex = 0;
            // 
            // _lblCheck
            // 
            this._lblCheck.BackColor = System.Drawing.Color.Transparent;
            this._lblCheck.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this._lblCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this._lblCheck.Location = new System.Drawing.Point(0, 9);
            this._lblCheck.Name = "_lblCheck";
            this._lblCheck.Size = new System.Drawing.Size(680, 71);
            this._lblCheck.TabIndex = 1;
            this._lblCheck.Text = "✓";
            this._lblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lblCheck.Click += new System.EventHandler(this._lblCheck_Click);
            // 
            // _lblBaslik
            // 
            this._lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this._lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this._lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblBaslik.Location = new System.Drawing.Point(0, 82);
            this._lblBaslik.Name = "_lblBaslik";
            this._lblBaslik.Size = new System.Drawing.Size(680, 36);
            this._lblBaslik.TabIndex = 2;
            this._lblBaslik.Text = "Rezervasyon Başarılı!";
            this._lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblSub
            // 
            this._lblSub.BackColor = System.Drawing.Color.Transparent;
            this._lblSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblSub.Location = new System.Drawing.Point(0, 122);
            this._lblSub.Name = "_lblSub";
            this._lblSub.Size = new System.Drawing.Size(680, 24);
            this._lblSub.TabIndex = 3;
            this._lblSub.Text = "Rezervasyonunuz sisteme kaydedilmiştir.";
            this._lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _card
            // 
            this._card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._card.Controls.Add(this._cardTitle);
            this._card.Controls.Add(this._separator);
            this._card.Location = new System.Drawing.Point(40, 158);
            this._card.Name = "_card";
            this._card.Size = new System.Drawing.Size(600, 300);
            this._card.TabIndex = 4;
            // 
            // _cardTitle
            // 
            this._cardTitle.BackColor = System.Drawing.Color.Transparent;
            this._cardTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._cardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this._cardTitle.Location = new System.Drawing.Point(0, 16);
            this._cardTitle.Name = "_cardTitle";
            this._cardTitle.Size = new System.Drawing.Size(600, 24);
            this._cardTitle.TabIndex = 0;
            this._cardTitle.Text = "REZERVASYON DEKONTU";
            this._cardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _separator
            // 
            this._separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._separator.Location = new System.Drawing.Point(20, 48);
            this._separator.Name = "_separator";
            this._separator.Size = new System.Drawing.Size(560, 1);
            this._separator.TabIndex = 1;
            // 
            // _btnYazdir
            // 
            this._btnYazdir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._btnYazdir.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnYazdir.FlatAppearance.BorderSize = 0;
            this._btnYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnYazdir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._btnYazdir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this._btnYazdir.Location = new System.Drawing.Point(40, 474);
            this._btnYazdir.Name = "_btnYazdir";
            this._btnYazdir.Size = new System.Drawing.Size(190, 46);
            this._btnYazdir.TabIndex = 5;
            this._btnYazdir.Text = "Yazdır";
            this._btnYazdir.UseVisualStyleBackColor = false;
            // 
            // _btnKapat
            // 
            this._btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this._btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnKapat.FlatAppearance.BorderSize = 0;
            this._btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnKapat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnKapat.ForeColor = System.Drawing.Color.White;
            this._btnKapat.Location = new System.Drawing.Point(260, 474);
            this._btnKapat.Name = "_btnKapat";
            this._btnKapat.Size = new System.Drawing.Size(380, 46);
            this._btnKapat.TabIndex = 6;
            this._btnKapat.Text = "Dashboard\'a Dön";
            this._btnKapat.UseVisualStyleBackColor = false;
            // 
            // DekontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(680, 540);
            this.Controls.Add(this._successBar);
            this.Controls.Add(this._lblCheck);
            this.Controls.Add(this._lblBaslik);
            this.Controls.Add(this._lblSub);
            this.Controls.Add(this._card);
            this.Controls.Add(this._btnYazdir);
            this.Controls.Add(this._btnKapat);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DekontForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervasyon Dekontu";
            this._card.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel  _successBar;
        private System.Windows.Forms.Label  _lblCheck;
        private System.Windows.Forms.Label  _lblBaslik;
        private System.Windows.Forms.Label  _lblSub;
        private System.Windows.Forms.Panel  _card;
        private System.Windows.Forms.Label  _cardTitle;
        private System.Windows.Forms.Panel  _separator;
        private System.Windows.Forms.Button _btnYazdir;
        private System.Windows.Forms.Button _btnKapat;
    }
}
