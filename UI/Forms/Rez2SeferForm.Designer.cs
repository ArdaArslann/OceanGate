namespace oceangate_r
{
    partial class Rez2SeferForm
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
            this.panelBaslik = new System.Windows.Forms.Panel();
            this.lblAdim = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblAltBaslik = new System.Windows.Forms.Label();
            this.listBoxSeferler = new System.Windows.Forms.ListBox();
            this.btnIleri = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.panelBaslik.SuspendLayout();
            this.SuspendLayout();
            
            this.panelBaslik.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panelBaslik.Controls.Add(this.lblAdim);
            this.panelBaslik.Controls.Add(this.lblBaslik);
            this.panelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBaslik.Location = new System.Drawing.Point(0, 0);
            this.panelBaslik.Name = "panelBaslik";
            this.panelBaslik.Size = new System.Drawing.Size(1050, 80);
            this.panelBaslik.TabIndex = 0;
       
            this.lblAdim.AutoSize = false;
            this.lblAdim.BackColor = System.Drawing.Color.Transparent;
            this.lblAdim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdim.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAdim.Location = new System.Drawing.Point(0, 22);
            this.lblAdim.Name = "lblAdim";
            this.lblAdim.Size = new System.Drawing.Size(1030, 36);
            this.lblAdim.TabIndex = 1;
            this.lblAdim.Text = "Adım 2 / 6";
            this.lblAdim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         
            this.lblBaslik.AutoSize = false;
            this.lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblBaslik.Location = new System.Drawing.Point(28, 22);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(400, 36);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Yeni Rezervasyon";
           
            this.lblAltBaslik.AutoSize = false;
            this.lblAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblAltBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAltBaslik.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblAltBaslik.Location = new System.Drawing.Point(28, 96);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(600, 36);
            this.lblAltBaslik.TabIndex = 1;
            this.lblAltBaslik.Text = "Hangi sefere katılmak istersiniz?";
       
            this.listBoxSeferler.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.listBoxSeferler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSeferler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxSeferler.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listBoxSeferler.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.listBoxSeferler.ItemHeight = 72;
            this.listBoxSeferler.Location = new System.Drawing.Point(28, 148);
            this.listBoxSeferler.Size = new System.Drawing.Size(994, 400);
            this.listBoxSeferler.TabIndex = 2;
            this.listBoxSeferler.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxSeferler_DrawItem);
            
            this.btnIleri.BackColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this.btnIleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIleri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIleri.ForeColor = System.Drawing.Color.White;
            this.btnIleri.Location = new System.Drawing.Point(858, 570);
            this.btnIleri.Name = "btnIleri";
            this.btnIleri.Size = new System.Drawing.Size(164, 48);
            this.btnIleri.TabIndex = 3;
            this.btnIleri.Text = "İleri →";
            this.btnIleri.UseVisualStyleBackColor = false;
            this.btnIleri.Click += new System.EventHandler(this.btnIleri_Click);
            this.btnIleri.FlatAppearance.BorderSize = 0;
        
            this.btnGeri.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGeri.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnGeri.Location = new System.Drawing.Point(28, 570);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(164, 48);
            this.btnGeri.TabIndex = 4;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            this.btnGeri.FlatAppearance.BorderSize = 0;
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.panelBaslik);
            this.Controls.Add(this.lblAltBaslik);
            this.Controls.Add(this.listBoxSeferler);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.btnGeri);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Rez2SeferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OceanGate – Sefer Seçimi";
            this.panelBaslik.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelBaslik;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblAdim;
        private System.Windows.Forms.Label lblAltBaslik;
        private System.Windows.Forms.ListBox listBoxSeferler;
        private System.Windows.Forms.Button btnIleri;
        private System.Windows.Forms.Button btnGeri;
    }
}
