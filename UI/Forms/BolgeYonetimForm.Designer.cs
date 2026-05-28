namespace oceangate_r
{
    partial class BolgeYonetimForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this._btnEkle = new oceangate_r.UI.Controls.OceanButton();
            this._btnGuncelle = new oceangate_r.UI.Controls.OceanButton();
            this._btnSil = new oceangate_r.UI.Controls.OceanButton();
            this._dgv = new System.Windows.Forms.DataGridView();
            this._formPanel = new System.Windows.Forms.Panel();
            this._lblFormBaslik = new System.Windows.Forms.Label();
            this._lblAd = new System.Windows.Forms.Label();
            this._txtAd = new System.Windows.Forms.TextBox();
            this._lblAc = new System.Windows.Forms.Label();
            this._txtAciklama = new System.Windows.Forms.TextBox();
            this._lblDer = new System.Windows.Forms.Label();
            this._nudDerinlik = new System.Windows.Forms.NumericUpDown();
            this._chkAktif = new System.Windows.Forms.CheckBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this._formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDerinlik)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblHeader.Location = new System.Drawing.Point(24, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(400, 36);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "🗺  Bölge Yönetimi";
            // 
            // _btnEkle
            // 
            this._btnEkle.BackColor = System.Drawing.Color.Transparent;
            this._btnEkle.CornerRadius = 6;
            this._btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEkle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._btnEkle.Location = new System.Drawing.Point(24, 70);
            this._btnEkle.Name = "_btnEkle";
            this._btnEkle.Size = new System.Drawing.Size(160, 42);
            this._btnEkle.TabIndex = 1;
            this._btnEkle.Text = "+ Yeni Bölge";
            this._btnEkle.UseVisualStyleBackColor = false;
            // 
            // _btnGuncelle
            // 
            this._btnGuncelle.BackColor = System.Drawing.Color.Transparent;
            this._btnGuncelle.CornerRadius = 6;
            this._btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnGuncelle.Enabled = false;
            this._btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGuncelle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._btnGuncelle.Location = new System.Drawing.Point(196, 70);
            this._btnGuncelle.Name = "_btnGuncelle";
            this._btnGuncelle.Size = new System.Drawing.Size(140, 42);
            this._btnGuncelle.TabIndex = 2;
            this._btnGuncelle.Text = "Güncelle";
            this._btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // _btnSil
            // 
            this._btnSil.BackColor = System.Drawing.Color.Transparent;
            this._btnSil.CornerRadius = 6;
            this._btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSil.Enabled = false;
            this._btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSil.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnSil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._btnSil.Location = new System.Drawing.Point(348, 70);
            this._btnSil.Name = "_btnSil";
            this._btnSil.Size = new System.Drawing.Size(120, 42);
            this._btnSil.TabIndex = 3;
            this._btnSil.Text = "Sil";
            this._btnSil.UseVisualStyleBackColor = false;
            this._btnSil.Click += new System.EventHandler(this._btnSil_Click);
            // 
            // _dgv
            // 
            this._dgv.AllowUserToAddRows = false;
            this._dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dgv.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dgv.Location = new System.Drawing.Point(24, 124);
            this._dgv.Name = "_dgv";
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersVisible = false;
            this._dgv.RowHeadersWidth = 51;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(669, 577);
            this._dgv.TabIndex = 5;
            // 
            // _formPanel
            // 
            this._formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._formPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._formPanel.Controls.Add(this._lblFormBaslik);
            this._formPanel.Controls.Add(this._lblAd);
            this._formPanel.Controls.Add(this._txtAd);
            this._formPanel.Controls.Add(this._lblAc);
            this._formPanel.Controls.Add(this._txtAciklama);
            this._formPanel.Controls.Add(this._lblDer);
            this._formPanel.Controls.Add(this._nudDerinlik);
            this._formPanel.Controls.Add(this._chkAktif);
            this._formPanel.Controls.Add(this.btnKaydet);
            this._formPanel.Controls.Add(this.btnIptal);
            this._formPanel.Location = new System.Drawing.Point(719, 124);
            this._formPanel.Name = "_formPanel";
            this._formPanel.Size = new System.Drawing.Size(400, 400);
            this._formPanel.TabIndex = 6;
            this._formPanel.Visible = false;
            // 
            // _lblFormBaslik
            // 
            this._lblFormBaslik.BackColor = System.Drawing.Color.Transparent;
            this._lblFormBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblFormBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblFormBaslik.Location = new System.Drawing.Point(16, 14);
            this._lblFormBaslik.Name = "_lblFormBaslik";
            this._lblFormBaslik.Size = new System.Drawing.Size(360, 30);
            this._lblFormBaslik.TabIndex = 0;
            this._lblFormBaslik.Text = "Yeni Bölge";
            // 
            // _lblAd
            // 
            this._lblAd.BackColor = System.Drawing.Color.Transparent;
            this._lblAd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblAd.Location = new System.Drawing.Point(16, 56);
            this._lblAd.Name = "_lblAd";
            this._lblAd.Size = new System.Drawing.Size(160, 22);
            this._lblAd.TabIndex = 1;
            this._lblAd.Text = "Bölge Adı *";
            // 
            // _txtAd
            // 
            this._txtAd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._txtAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtAd.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._txtAd.Location = new System.Drawing.Point(16, 80);
            this._txtAd.Name = "_txtAd";
            this._txtAd.Size = new System.Drawing.Size(368, 29);
            this._txtAd.TabIndex = 2;
            // 
            // _lblAc
            // 
            this._lblAc.BackColor = System.Drawing.Color.Transparent;
            this._lblAc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblAc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblAc.Location = new System.Drawing.Point(16, 120);
            this._lblAc.Name = "_lblAc";
            this._lblAc.Size = new System.Drawing.Size(160, 22);
            this._lblAc.TabIndex = 3;
            this._lblAc.Text = "Açıklama";
            // 
            // _txtAciklama
            // 
            this._txtAciklama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._txtAciklama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtAciklama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._txtAciklama.Location = new System.Drawing.Point(16, 144);
            this._txtAciklama.Multiline = true;
            this._txtAciklama.Name = "_txtAciklama";
            this._txtAciklama.Size = new System.Drawing.Size(368, 60);
            this._txtAciklama.TabIndex = 4;
            // 
            // _lblDer
            // 
            this._lblDer.BackColor = System.Drawing.Color.Transparent;
            this._lblDer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblDer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblDer.Location = new System.Drawing.Point(16, 216);
            this._lblDer.Name = "_lblDer";
            this._lblDer.Size = new System.Drawing.Size(160, 22);
            this._lblDer.TabIndex = 5;
            this._lblDer.Text = "Derinlik (m)";
            // 
            // _nudDerinlik
            // 
            this._nudDerinlik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._nudDerinlik.DecimalPlaces = 1;
            this._nudDerinlik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._nudDerinlik.Location = new System.Drawing.Point(16, 240);
            this._nudDerinlik.Maximum = new decimal(new int[] {
            11000,
            0,
            0,
            0});
            this._nudDerinlik.Name = "_nudDerinlik";
            this._nudDerinlik.Size = new System.Drawing.Size(140, 29);
            this._nudDerinlik.TabIndex = 6;
            // 
            // _chkAktif
            // 
            this._chkAktif.Checked = true;
            this._chkAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkAktif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._chkAktif.Location = new System.Drawing.Point(16, 288);
            this._chkAktif.Name = "_chkAktif";
            this._chkAktif.Size = new System.Drawing.Size(120, 28);
            this._chkAktif.TabIndex = 7;
            this._chkAktif.Text = "Aktif";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(16, 330);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(180, 44);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnIptal.Location = new System.Drawing.Point(208, 330);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(160, 44);
            this.btnIptal.TabIndex = 9;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // BolgeYonetimForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1129, 560);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this._btnEkle);
            this.Controls.Add(this._btnGuncelle);
            this.Controls.Add(this._btnSil);
            this.Controls.Add(this._dgv);
            this.Controls.Add(this._formPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BolgeYonetimForm";
            this.Text = "Bölge Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this._formPanel.ResumeLayout(false);
            this._formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDerinlik)).EndInit();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView _dgv;
        private oceangate_r.UI.Controls.OceanButton _btnEkle;
        private oceangate_r.UI.Controls.OceanButton _btnGuncelle;
        private oceangate_r.UI.Controls.OceanButton _btnSil;
        private System.Windows.Forms.Panel _formPanel;
        private System.Windows.Forms.Label _lblFormBaslik;
        private System.Windows.Forms.Label _lblAd;
        private System.Windows.Forms.Label _lblAc;
        private System.Windows.Forms.Label _lblDer;
        private System.Windows.Forms.TextBox _txtAd;
        private System.Windows.Forms.TextBox _txtAciklama;
        private System.Windows.Forms.NumericUpDown _nudDerinlik;
        private System.Windows.Forms.CheckBox _chkAktif;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}
