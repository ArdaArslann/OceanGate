namespace oceangate_r
{
    partial class RezervasyonDetayForm
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
            this._lblTitle = new System.Windows.Forms.Label();
            this._btnKapat = new System.Windows.Forms.Button();
            this._card = new System.Windows.Forms.Panel();
            this._lblTalepBaslik = new System.Windows.Forms.Label();
            this._lblTip = new System.Windows.Forms.Label();
            this._cbTip = new System.Windows.Forms.ComboBox();
            this._lblYeniTarih = new System.Windows.Forms.Label();
            this._dtpYeni = new System.Windows.Forms.DateTimePicker();
            this._lblAc = new System.Windows.Forms.Label();
            this._txtAc = new System.Windows.Forms.TextBox();
            this._btnGonder = new System.Windows.Forms.Button();
            this._titleBar.SuspendLayout();
            this.SuspendLayout();
     
            this._titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this._titleBar.Controls.Add(this._lblTitle);
            this._titleBar.Controls.Add(this._btnKapat);
            this._titleBar.Location = new System.Drawing.Point(0, 0);
            this._titleBar.Name = "_titleBar";
            this._titleBar.Size = new System.Drawing.Size(700, 50);
            this._titleBar.TabIndex = 0;
       
            this._lblTitle.BackColor = System.Drawing.Color.Transparent;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblTitle.Location = new System.Drawing.Point(20, 0);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(400, 50);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Rezervasyon Detayı";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        
            this._btnKapat.BackColor = System.Drawing.Color.Transparent;
            this._btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnKapat.FlatAppearance.BorderSize = 0;
            this._btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnKapat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._btnKapat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._btnKapat.Location = new System.Drawing.Point(654, 0);
            this._btnKapat.Name = "_btnKapat";
            this._btnKapat.Size = new System.Drawing.Size(46, 50);
            this._btnKapat.TabIndex = 1;
            this._btnKapat.Text = "✕";
            this._btnKapat.UseVisualStyleBackColor = false;
         
            this._card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._card.Location = new System.Drawing.Point(24, 64);
            this._card.Name = "_card";
            this._card.Size = new System.Drawing.Size(652, 320);
            this._card.TabIndex = 1;
        
            this._lblTalepBaslik.BackColor = System.Drawing.Color.Transparent;
            this._lblTalepBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblTalepBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblTalepBaslik.Location = new System.Drawing.Point(24, 400);
            this._lblTalepBaslik.Name = "_lblTalepBaslik";
            this._lblTalepBaslik.Size = new System.Drawing.Size(300, 32);
            this._lblTalepBaslik.TabIndex = 2;
            this._lblTalepBaslik.Text = "Talep Oluştur";
    
            this._lblTip.BackColor = System.Drawing.Color.Transparent;
            this._lblTip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblTip.Location = new System.Drawing.Point(24, 442);
            this._lblTip.Name = "_lblTip";
            this._lblTip.Size = new System.Drawing.Size(120, 28);
            this._lblTip.TabIndex = 3;
            this._lblTip.Text = "Talep Türü:";
     
            this._cbTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._cbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cbTip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cbTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._cbTip.Items.AddRange(new object[] {
            "İptal ve İade",
            "Tarih Değişikliği",
            "Diğer"});
            this._cbTip.Location = new System.Drawing.Point(150, 440);
            this._cbTip.Name = "_cbTip";
            this._cbTip.Size = new System.Drawing.Size(260, 29);
            this._cbTip.TabIndex = 4;
      
            this._lblYeniTarih.BackColor = System.Drawing.Color.Transparent;
            this._lblYeniTarih.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblYeniTarih.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblYeniTarih.Location = new System.Drawing.Point(24, 547);
            this._lblYeniTarih.Name = "_lblYeniTarih";
            this._lblYeniTarih.Size = new System.Drawing.Size(120, 28);
            this._lblYeniTarih.TabIndex = 5;
            this._lblYeniTarih.Text = "Yeni Tarih:";
        
            this._dtpYeni.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dtpYeni.Location = new System.Drawing.Point(150, 547);
            this._dtpYeni.MinDate = new System.DateTime(2026, 5, 24, 0, 0, 0, 0);
            this._dtpYeni.Name = "_dtpYeni";
            this._dtpYeni.Size = new System.Drawing.Size(260, 29);
            this._dtpYeni.TabIndex = 6;
            this._dtpYeni.Value = new System.DateTime(2026, 5, 24, 0, 0, 0, 0);
            this._dtpYeni.Visible = false;
       
            this._lblAc.BackColor = System.Drawing.Color.Transparent;
            this._lblAc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblAc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this._lblAc.Location = new System.Drawing.Point(24, 486);
            this._lblAc.Name = "_lblAc";
            this._lblAc.Size = new System.Drawing.Size(120, 28);
            this._lblAc.TabIndex = 7;
            this._lblAc.Text = "Açıklama:";
            
            this._txtAc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._txtAc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtAc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtAc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._txtAc.Location = new System.Drawing.Point(150, 484);
            this._txtAc.Multiline = true;
            this._txtAc.Name = "_txtAc";
            this._txtAc.Size = new System.Drawing.Size(526, 48);
            this._txtAc.TabIndex = 8;
           
            this._btnGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this._btnGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnGonder.FlatAppearance.BorderSize = 0;
            this._btnGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGonder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGonder.ForeColor = System.Drawing.Color.White;
            this._btnGonder.Location = new System.Drawing.Point(24, 592);
            this._btnGonder.Name = "_btnGonder";
            this._btnGonder.Size = new System.Drawing.Size(280, 46);
            this._btnGonder.TabIndex = 9;
            this._btnGonder.Text = "Talep Gönder";
            this._btnGonder.UseVisualStyleBackColor = false;
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(783, 704);
            this.Controls.Add(this._titleBar);
            this.Controls.Add(this._card);
            this.Controls.Add(this._lblTalepBaslik);
            this.Controls.Add(this._lblTip);
            this.Controls.Add(this._cbTip);
            this.Controls.Add(this._lblYeniTarih);
            this.Controls.Add(this._dtpYeni);
            this.Controls.Add(this._lblAc);
            this.Controls.Add(this._txtAc);
            this.Controls.Add(this._btnGonder);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RezervasyonDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "d";
            this._titleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        private System.Windows.Forms.Panel       _titleBar;
        private System.Windows.Forms.Label       _lblTitle;
        private System.Windows.Forms.Button      _btnKapat;
        private System.Windows.Forms.Panel       _card;
        private System.Windows.Forms.Label       _lblTalepBaslik;
        private System.Windows.Forms.Label       _lblTip;
        private System.Windows.Forms.ComboBox    _cbTip;
        private System.Windows.Forms.Label       _lblYeniTarih;
        private System.Windows.Forms.DateTimePicker _dtpYeni;
        private System.Windows.Forms.Label       _lblAc;
        private System.Windows.Forms.TextBox     _txtAc;
        private System.Windows.Forms.Button      _btnGonder;
    }
}
