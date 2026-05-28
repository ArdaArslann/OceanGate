namespace oceangate_r.UI.Forms
{
    partial class BakiyeYukleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this._txtAdSoyad = new System.Windows.Forms.TextBox();
            this.lblKartNo = new System.Windows.Forms.Label();
            this._txtKartNo = new System.Windows.Forms.TextBox();
            this.lblSKT = new System.Windows.Forms.Label();
            this._txtSKT = new System.Windows.Forms.TextBox();
            this.lblCVC = new System.Windows.Forms.Label();
            this._txtCVC = new System.Windows.Forms.TextBox();
            this.lblMiktar = new System.Windows.Forms.Label();
            this._txtMiktar = new System.Windows.Forms.TextBox();
            this.btnYatir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.ForeColor = System.Drawing.Color.White;
            this.lblAdSoyad.Location = new System.Drawing.Point(30, 20);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(149, 21);
            this.lblAdSoyad.TabIndex = 10;
            this.lblAdSoyad.Text = "Kart Üzerindeki İsim";
            // 
            // _txtAdSoyad
            // 
            this._txtAdSoyad.Location = new System.Drawing.Point(33, 40);
            this._txtAdSoyad.Name = "_txtAdSoyad";
            this._txtAdSoyad.Size = new System.Drawing.Size(330, 29);
            this._txtAdSoyad.TabIndex = 9;
            // 
            // lblKartNo
            // 
            this.lblKartNo.AutoSize = true;
            this.lblKartNo.ForeColor = System.Drawing.Color.White;
            this.lblKartNo.Location = new System.Drawing.Point(30, 80);
            this.lblKartNo.Name = "lblKartNo";
            this.lblKartNo.Size = new System.Drawing.Size(154, 21);
            this.lblKartNo.TabIndex = 8;
            this.lblKartNo.Text = "Kredi Kartı Numarası";
            // 
            // _txtKartNo
            // 
            this._txtKartNo.Location = new System.Drawing.Point(33, 100);
            this._txtKartNo.MaxLength = 16;
            this._txtKartNo.Name = "_txtKartNo";
            this._txtKartNo.Size = new System.Drawing.Size(330, 29);
            this._txtKartNo.TabIndex = 7;
            // 
            // lblSKT
            // 
            this.lblSKT.AutoSize = true;
            this.lblSKT.ForeColor = System.Drawing.Color.White;
            this.lblSKT.Location = new System.Drawing.Point(30, 140);
            this.lblSKT.Name = "lblSKT";
            this.lblSKT.Size = new System.Drawing.Size(94, 21);
            this.lblSKT.TabIndex = 6;
            this.lblSKT.Text = "SKT (AA/YY)";
            // 
            // _txtSKT
            // 
            this._txtSKT.Location = new System.Drawing.Point(33, 160);
            this._txtSKT.MaxLength = 5;
            this._txtSKT.Name = "_txtSKT";
            this._txtSKT.Size = new System.Drawing.Size(150, 29);
            this._txtSKT.TabIndex = 5;
            // 
            // lblCVC
            // 
            this.lblCVC.AutoSize = true;
            this.lblCVC.ForeColor = System.Drawing.Color.White;
            this.lblCVC.Location = new System.Drawing.Point(210, 140);
            this.lblCVC.Name = "lblCVC";
            this.lblCVC.Size = new System.Drawing.Size(40, 21);
            this.lblCVC.TabIndex = 4;
            this.lblCVC.Text = "CVC";
            // 
            // _txtCVC
            // 
            this._txtCVC.Location = new System.Drawing.Point(213, 160);
            this._txtCVC.MaxLength = 3;
            this._txtCVC.Name = "_txtCVC";
            this._txtCVC.Size = new System.Drawing.Size(150, 29);
            this._txtCVC.TabIndex = 3;
            this._txtCVC.TextChanged += new System.EventHandler(this._txtCVC_TextChanged);
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.ForeColor = System.Drawing.Color.White;
            this.lblMiktar.Location = new System.Drawing.Point(30, 200);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(158, 21);
            this.lblMiktar.TabIndex = 2;
            this.lblMiktar.Text = "Yüklenecek Tutar (TL)";
            // 
            // _txtMiktar
            // 
            this._txtMiktar.Location = new System.Drawing.Point(33, 220);
            this._txtMiktar.Name = "_txtMiktar";
            this._txtMiktar.Size = new System.Drawing.Size(330, 29);
            this._txtMiktar.TabIndex = 1;
            // 
            // btnYatir
            // 
            this.btnYatir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnYatir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYatir.FlatAppearance.BorderSize = 0;
            this.btnYatir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYatir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYatir.ForeColor = System.Drawing.Color.White;
            this.btnYatir.Location = new System.Drawing.Point(33, 270);
            this.btnYatir.Name = "btnYatir";
            this.btnYatir.Size = new System.Drawing.Size(330, 45);
            this.btnYatir.TabIndex = 0;
            this.btnYatir.Text = "Para Yatır";
            this.btnYatir.UseVisualStyleBackColor = false;
            this.btnYatir.Click += new System.EventHandler(this.btnYatir_Click);
            // 
            // BakiyeYukleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.btnYatir);
            this.Controls.Add(this._txtMiktar);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this._txtCVC);
            this.Controls.Add(this.lblCVC);
            this.Controls.Add(this._txtSKT);
            this.Controls.Add(this.lblSKT);
            this.Controls.Add(this._txtKartNo);
            this.Controls.Add(this.lblKartNo);
            this.Controls.Add(this._txtAdSoyad);
            this.Controls.Add(this.lblAdSoyad);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BakiyeYukleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bakiye Yükle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblAdSoyad;
        private System.Windows.Forms.TextBox _txtAdSoyad;
        private System.Windows.Forms.Label lblKartNo;
        private System.Windows.Forms.TextBox _txtKartNo;
        private System.Windows.Forms.Label lblSKT;
        private System.Windows.Forms.TextBox _txtSKT;
        private System.Windows.Forms.Label lblCVC;
        private System.Windows.Forms.TextBox _txtCVC;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.TextBox _txtMiktar;
        private System.Windows.Forms.Button btnYatir;
    }
}
