namespace oceangate_r.UI.Forms
{
    partial class CinsiyetSecimForm
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
            this.lblBaslik = new System.Windows.Forms.Label();
            this._rdKadin = new System.Windows.Forms.RadioButton();
            this._rdErkek = new System.Windows.Forms.RadioButton();
            this._btnTamam = new System.Windows.Forms.Button();
            this._btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
          
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblBaslik.Location = new System.Drawing.Point(16, 16);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(260, 24);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Koltuk için cinsiyet seçin:";
      
            this._rdKadin.Checked = true;
            this._rdKadin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._rdKadin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(212)))));
            this._rdKadin.Location = new System.Drawing.Point(24, 52);
            this._rdKadin.Name = "_rdKadin";
            this._rdKadin.Size = new System.Drawing.Size(100, 28);
            this._rdKadin.TabIndex = 1;
            this._rdKadin.TabStop = true;
            this._rdKadin.Text = "Kadın";
           
            this._rdErkek.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._rdErkek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(253)))));
            this._rdErkek.Location = new System.Drawing.Point(140, 52);
            this._rdErkek.Name = "_rdErkek";
            this._rdErkek.Size = new System.Drawing.Size(100, 28);
            this._rdErkek.TabIndex = 2;
            this._rdErkek.Text = "Erkek";
         
            this._btnTamam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this._btnTamam.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnTamam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnTamam.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnTamam.ForeColor = System.Drawing.Color.White;
            this._btnTamam.Location = new System.Drawing.Point(80, 100);
            this._btnTamam.Name = "_btnTamam";
            this._btnTamam.Size = new System.Drawing.Size(90, 34);
            this._btnTamam.TabIndex = 3;
            this._btnTamam.Text = "Tamam";
            this._btnTamam.UseVisualStyleBackColor = false;
            this._btnTamam.Click += new System.EventHandler(this._btnTamam_Click);
          
            this._btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnIptal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._btnIptal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this._btnIptal.Location = new System.Drawing.Point(182, 100);
            this._btnIptal.Name = "_btnIptal";
            this._btnIptal.Size = new System.Drawing.Size(76, 34);
            this._btnIptal.TabIndex = 4;
            this._btnIptal.Text = "İptal";
            this._btnIptal.UseVisualStyleBackColor = false;
       
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this._rdKadin);
            this.Controls.Add(this._rdErkek);
            this.Controls.Add(this._btnTamam);
            this.Controls.Add(this._btnIptal);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CinsiyetSecimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cinsiyet Seçimi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.RadioButton _rdKadin;
        private System.Windows.Forms.RadioButton _rdErkek;
        private System.Windows.Forms.Button _btnTamam;
        private System.Windows.Forms.Button _btnIptal;
    }
}
