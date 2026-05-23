namespace oceangate_r
{
    partial class Rez1BolgeForm
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
            this.listBoxBolgeler = new System.Windows.Forms.ListBox();
            this.btnIleri = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.panelBaslik.SuspendLayout();
            this.SuspendLayout();
            
            this.panelBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelBaslik.Controls.Add(this.lblAdim);
            this.panelBaslik.Controls.Add(this.lblBaslik);
            this.panelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBaslik.Location = new System.Drawing.Point(0, 0);
            this.panelBaslik.Name = "panelBaslik";
            this.panelBaslik.Size = new System.Drawing.Size(1050, 80);
            this.panelBaslik.TabIndex = 0;
           
            this.lblAdim.BackColor = System.Drawing.Color.Transparent;
            this.lblAdim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAdim.Location = new System.Drawing.Point(0, 22);
            this.lblAdim.Name = "lblAdim";
            this.lblAdim.Size = new System.Drawing.Size(1030, 36);
            this.lblAdim.TabIndex = 1;
            this.lblAdim.Text = "Adım 1 / 6";
            this.lblAdim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            this.lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblBaslik.Location = new System.Drawing.Point(28, 22);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(400, 36);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Yeni Rezervasyon";
           
            this.lblAltBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblAltBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAltBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblAltBaslik.Location = new System.Drawing.Point(28, 96);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(600, 36);
            this.lblAltBaslik.TabIndex = 1;
            this.lblAltBaslik.Text = "Hangi bölgeye gitmek istersiniz?";
            
            this.listBoxBolgeler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.listBoxBolgeler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxBolgeler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxBolgeler.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listBoxBolgeler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.listBoxBolgeler.ItemHeight = 64;
            this.listBoxBolgeler.Location = new System.Drawing.Point(28, 148);
            this.listBoxBolgeler.Name = "listBoxBolgeler";
            this.listBoxBolgeler.Size = new System.Drawing.Size(994, 384);
            this.listBoxBolgeler.TabIndex = 2;
            this.listBoxBolgeler.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxBolgeler_DrawItem);
           
            this.btnIleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnIleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIleri.FlatAppearance.BorderSize = 0;
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
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIptal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnIptal.Location = new System.Drawing.Point(28, 570);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(164, 48);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "✕  İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
         
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1050, 630);
            this.Controls.Add(this.panelBaslik);
            this.Controls.Add(this.lblAltBaslik);
            this.Controls.Add(this.listBoxBolgeler);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.btnIptal);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Rez1BolgeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OceanGate – Bölge Seçimi";
            this.panelBaslik.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelBaslik;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblAdim;
        private System.Windows.Forms.Label lblAltBaslik;
        private System.Windows.Forms.ListBox listBoxBolgeler;
        private System.Windows.Forms.Button btnIleri;
        private System.Windows.Forms.Button btnIptal;
    }
}
