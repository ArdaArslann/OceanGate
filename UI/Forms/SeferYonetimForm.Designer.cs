namespace oceangate_r
{
    partial class SeferYonetimForm
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
            this._lblFBolge = new System.Windows.Forms.Label();
            this._cbBolge = new System.Windows.Forms.ComboBox();
            this._lblFSaat = new System.Windows.Forms.Label();
            this._txtSaat = new System.Windows.Forms.TextBox();
            this._lblFKap = new System.Windows.Forms.Label();
            this._nudKapasite = new System.Windows.Forms.NumericUpDown();
            this._lblFSure = new System.Windows.Forms.Label();
            this._nudSure = new System.Windows.Forms.NumericUpDown();
            this._lblFFiyat = new System.Windows.Forms.Label();
            this._txtFiyat = new System.Windows.Forms.TextBox();
            this._chkAktif = new System.Windows.Forms.CheckBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this._formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudKapasite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudSure)).BeginInit();
            this.SuspendLayout();
            
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblHeader.Location = new System.Drawing.Point(24, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(400, 36);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Sefer Yönetimi";
        
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
            this._btnEkle.Text = "+ Yeni Sefer";
            this._btnEkle.UseVisualStyleBackColor = false;
          
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
            this._dgv.Size = new System.Drawing.Size(700, 470);
            this._dgv.TabIndex = 4;
         
            this._formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._formPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._formPanel.Controls.Add(this._lblFormBaslik);
            this._formPanel.Controls.Add(this._lblFBolge);
            this._formPanel.Controls.Add(this._cbBolge);
            this._formPanel.Controls.Add(this._lblFSaat);
            this._formPanel.Controls.Add(this._txtSaat);
            this._formPanel.Controls.Add(this._lblFKap);
            this._formPanel.Controls.Add(this._nudKapasite);
            this._formPanel.Controls.Add(this._lblFSure);
            this._formPanel.Controls.Add(this._nudSure);
            this._formPanel.Controls.Add(this._lblFFiyat);
            this._formPanel.Controls.Add(this._txtFiyat);
            this._formPanel.Controls.Add(this._chkAktif);
            this._formPanel.Controls.Add(this.btnKaydet);
            this._formPanel.Controls.Add(this.btnIptal);
            this._formPanel.Location = new System.Drawing.Point(740, 124);
            this._formPanel.Name = "_formPanel";
            this._formPanel.Size = new System.Drawing.Size(420, 430);
            this._formPanel.TabIndex = 5;
            this._formPanel.Visible = false;
       
            this._lblFormBaslik.BackColor = System.Drawing.Color.Transparent;
            this._lblFormBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblFormBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblFormBaslik.Location = new System.Drawing.Point(16, 14);
            this._lblFormBaslik.Name = "_lblFormBaslik";
            this._lblFormBaslik.Size = new System.Drawing.Size(380, 30);
            this._lblFormBaslik.TabIndex = 0;
            this._lblFormBaslik.Text = "Yeni Sefer";
      
            this._lblFBolge.BackColor = System.Drawing.Color.Transparent;
            this._lblFBolge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFBolge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblFBolge.Location = new System.Drawing.Point(16, 56);
            this._lblFBolge.Name = "_lblFBolge";
            this._lblFBolge.Size = new System.Drawing.Size(200, 22);
            this._lblFBolge.TabIndex = 1;
            this._lblFBolge.Text = "Bölge *";
     
            this._cbBolge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._cbBolge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbBolge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cbBolge.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cbBolge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._cbBolge.Location = new System.Drawing.Point(16, 80);
            this._cbBolge.Name = "_cbBolge";
            this._cbBolge.Size = new System.Drawing.Size(380, 29);
            this._cbBolge.TabIndex = 2;
           
            this._lblFSaat.BackColor = System.Drawing.Color.Transparent;
            this._lblFSaat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFSaat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblFSaat.Location = new System.Drawing.Point(16, 118);
            this._lblFSaat.Name = "_lblFSaat";
            this._lblFSaat.Size = new System.Drawing.Size(220, 22);
            this._lblFSaat.TabIndex = 3;
            this._lblFSaat.Text = "Kalkış Saati (HH:mm) *";
       
            this._txtSaat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._txtSaat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtSaat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtSaat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._txtSaat.Location = new System.Drawing.Point(16, 142);
            this._txtSaat.Name = "_txtSaat";
            this._txtSaat.Size = new System.Drawing.Size(180, 29);
            this._txtSaat.TabIndex = 4;
      
            this._lblFKap.BackColor = System.Drawing.Color.Transparent;
            this._lblFKap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFKap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblFKap.Location = new System.Drawing.Point(16, 180);
            this._lblFKap.Name = "_lblFKap";
            this._lblFKap.Size = new System.Drawing.Size(160, 22);
            this._lblFKap.TabIndex = 5;
            this._lblFKap.Text = "Kapasite (Kişi)";
            this._nudKapasite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._nudKapasite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._nudKapasite.Location = new System.Drawing.Point(16, 204);
            this._nudKapasite.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this._nudKapasite.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudKapasite.Name = "_nudKapasite";
            this._nudKapasite.Size = new System.Drawing.Size(120, 29);
            this._nudKapasite.TabIndex = 6;
            this._nudKapasite.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
    
            this._lblFSure.BackColor = System.Drawing.Color.Transparent;
            this._lblFSure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFSure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblFSure.Location = new System.Drawing.Point(160, 180);
            this._lblFSure.Name = "_lblFSure";
            this._lblFSure.Size = new System.Drawing.Size(140, 22);
            this._lblFSure.TabIndex = 7;
            this._lblFSure.Text = "Süre (Dakika)";
      
            this._nudSure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._nudSure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._nudSure.Location = new System.Drawing.Point(160, 204);
            this._nudSure.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this._nudSure.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this._nudSure.Name = "_nudSure";
            this._nudSure.Size = new System.Drawing.Size(120, 29);
            this._nudSure.TabIndex = 8;
            this._nudSure.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
        
            this._lblFFiyat.BackColor = System.Drawing.Color.Transparent;
            this._lblFFiyat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lblFFiyat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblFFiyat.Location = new System.Drawing.Point(16, 244);
            this._lblFFiyat.Name = "_lblFFiyat";
            this._lblFFiyat.Size = new System.Drawing.Size(200, 22);
            this._lblFFiyat.TabIndex = 9;
            this._lblFFiyat.Text = "Kişi Başı Fiyat (TL) *";
       
            this._txtFiyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._txtFiyat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtFiyat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtFiyat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._txtFiyat.Location = new System.Drawing.Point(16, 268);
            this._txtFiyat.Name = "_txtFiyat";
            this._txtFiyat.Size = new System.Drawing.Size(220, 29);
            this._txtFiyat.TabIndex = 10;
           
            this._chkAktif.Checked = true;
            this._chkAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkAktif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._chkAktif.Location = new System.Drawing.Point(16, 312);
            this._chkAktif.Name = "_chkAktif";
            this._chkAktif.Size = new System.Drawing.Size(120, 28);
            this._chkAktif.TabIndex = 11;
            this._chkAktif.Text = "Aktif";
           
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(16, 350);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(180, 44);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
           
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnIptal.Location = new System.Drawing.Point(208, 350);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(160, 44);
            this.btnIptal.TabIndex = 13;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1180, 560);
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
            this.Name = "SeferYonetimForm";
            this.Text = "Sefer Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this._formPanel.ResumeLayout(false);
            this._formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudKapasite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudSure)).EndInit();
            this.ResumeLayout(false);

        }

        

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView _dgv;
        private oceangate_r.UI.Controls.OceanButton _btnEkle;
        private oceangate_r.UI.Controls.OceanButton _btnGuncelle;
        private oceangate_r.UI.Controls.OceanButton _btnSil;
        private System.Windows.Forms.Panel _formPanel;
        private System.Windows.Forms.Label _lblFormBaslik;
        private System.Windows.Forms.Label _lblFBolge;
        private System.Windows.Forms.ComboBox _cbBolge;
        private System.Windows.Forms.Label _lblFSaat;
        private System.Windows.Forms.TextBox _txtSaat;
        private System.Windows.Forms.Label _lblFKap;
        private System.Windows.Forms.NumericUpDown _nudKapasite;
        private System.Windows.Forms.Label _lblFSure;
        private System.Windows.Forms.NumericUpDown _nudSure;
        private System.Windows.Forms.Label _lblFFiyat;
        private System.Windows.Forms.TextBox _txtFiyat;
        private System.Windows.Forms.CheckBox _chkAktif;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}
