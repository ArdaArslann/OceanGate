namespace oceangate_r
{
    partial class Rez5OdaForm
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
            this.lblSecimBilgi = new System.Windows.Forms.Label();
            this.otelOdaSecimPanel1 = new oceangate_r.UI.Forms.OtelOdaSecimPanel();
            this.btnIleri = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.panelBaslik.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBaslik
            // 
            this.panelBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelBaslik.Controls.Add(this.lblAdim);
            this.panelBaslik.Controls.Add(this.lblBaslik);
            this.panelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBaslik.Location = new System.Drawing.Point(0, 0);
            this.panelBaslik.Name = "panelBaslik";
            this.panelBaslik.Size = new System.Drawing.Size(1050, 80);
            this.panelBaslik.TabIndex = 0;
            // 
            // lblAdim
            // 
            this.lblAdim.BackColor = System.Drawing.Color.Transparent;
            this.lblAdim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAdim.Location = new System.Drawing.Point(0, 22);
            this.lblAdim.Name = "lblAdim";
            this.lblAdim.Size = new System.Drawing.Size(1030, 36);
            this.lblAdim.TabIndex = 1;
            this.lblAdim.Text = "Adım 5 / 6";
            this.lblAdim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBaslik
            // 
            this.lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblBaslik.Location = new System.Drawing.Point(28, 22);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(400, 36);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Yeni Rezervasyon";
            // 
            // lblSecimBilgi
            // 
            this.lblSecimBilgi.BackColor = System.Drawing.Color.Transparent;
            this.lblSecimBilgi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSecimBilgi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSecimBilgi.Location = new System.Drawing.Point(0, 84);
            this.lblSecimBilgi.Name = "lblSecimBilgi";
            this.lblSecimBilgi.Size = new System.Drawing.Size(1030, 24);
            this.lblSecimBilgi.TabIndex = 2;
            this.lblSecimBilgi.Text = "Kapasitenize uygun odaları seçebilirsiniz.";
            this.lblSecimBilgi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // otelOdaSecimPanel1
            // 
            this.otelOdaSecimPanel1.AutoScroll = true;
            this.otelOdaSecimPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.otelOdaSecimPanel1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.otelOdaSecimPanel1.Location = new System.Drawing.Point(28, 112);
            this.otelOdaSecimPanel1.Name = "otelOdaSecimPanel1";
            this.otelOdaSecimPanel1.Size = new System.Drawing.Size(994, 440);
            this.otelOdaSecimPanel1.TabIndex = 3;
            this.otelOdaSecimPanel1.Load += new System.EventHandler(this.otelOdaSecimPanel1_Load);
            // 
            // btnIleri
            // 
            this.btnIleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnIleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIleri.FlatAppearance.BorderSize = 0;
            this.btnIleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIleri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIleri.ForeColor = System.Drawing.Color.White;
            this.btnIleri.Location = new System.Drawing.Point(858, 570);
            this.btnIleri.Name = "btnIleri";
            this.btnIleri.Size = new System.Drawing.Size(164, 48);
            this.btnIleri.TabIndex = 4;
            this.btnIleri.Text = "Özete Git →";
            this.btnIleri.UseVisualStyleBackColor = false;
            this.btnIleri.Click += new System.EventHandler(this.btnIleri_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGeri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnGeri.Location = new System.Drawing.Point(28, 570);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(164, 48);
            this.btnGeri.TabIndex = 5;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // Rez5OdaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.panelBaslik);
            this.Controls.Add(this.lblSecimBilgi);
            this.Controls.Add(this.otelOdaSecimPanel1);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.btnGeri);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Rez5OdaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OceanGate – Otel Odası Seçimi";
            this.panelBaslik.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel panelBaslik;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblAdim;
        private System.Windows.Forms.Label lblSecimBilgi;
        private oceangate_r.UI.Forms.OtelOdaSecimPanel otelOdaSecimPanel1;
        private System.Windows.Forms.Button btnIleri;
        private System.Windows.Forms.Button btnGeri;
    }
}
