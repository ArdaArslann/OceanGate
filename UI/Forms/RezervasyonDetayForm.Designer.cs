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
            this._card           = new System.Windows.Forms.Panel();
            this._lblTalepBaslik = new System.Windows.Forms.Label();
            this._lblTip         = new System.Windows.Forms.Label();
            this._cbTip          = new System.Windows.Forms.ComboBox();
            this._lblYeniTarih   = new System.Windows.Forms.Label();
            this._dtpYeni        = new System.Windows.Forms.DateTimePicker();
            this._lblAc          = new System.Windows.Forms.Label();
            this._txtAc          = new System.Windows.Forms.TextBox();
            this._btnGonder      = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // _card – rezervasyon bilgi kartı
            this._card.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._card.Location  = new System.Drawing.Point(14, 10);
            this._card.Name      = "_card";
            this._card.Size      = new System.Drawing.Size(652, 320);
            this._card.TabIndex  = 0;

            // _lblTalepBaslik
            this._lblTalepBaslik.BackColor  = System.Drawing.Color.Transparent;
            this._lblTalepBaslik.Font       = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblTalepBaslik.ForeColor  = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblTalepBaslik.Location   = new System.Drawing.Point(14, 346);
            this._lblTalepBaslik.Name       = "_lblTalepBaslik";
            this._lblTalepBaslik.Size       = new System.Drawing.Size(300, 32);
            this._lblTalepBaslik.TabIndex   = 1;
            this._lblTalepBaslik.Text       = "Talep Oluştur";

            // _lblTip
            this._lblTip.BackColor  = System.Drawing.Color.Transparent;
            this._lblTip.Font       = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblTip.ForeColor  = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblTip.Location   = new System.Drawing.Point(14, 388);
            this._lblTip.Name       = "_lblTip";
            this._lblTip.Size       = new System.Drawing.Size(120, 28);
            this._lblTip.TabIndex   = 2;
            this._lblTip.Text       = "Talep Türü:";

            // _cbTip
            this._cbTip.BackColor     = System.Drawing.Color.FromArgb(30, 41, 59);
            this._cbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTip.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this._cbTip.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cbTip.ForeColor     = System.Drawing.Color.FromArgb(248, 250, 252);
            this._cbTip.Items.AddRange(new object[] { "İptal ve İade", "Tarih Değişikliği", "Diğer" });
            this._cbTip.Location      = new System.Drawing.Point(140, 386);
            this._cbTip.Name          = "_cbTip";
            this._cbTip.Size          = new System.Drawing.Size(260, 29);
            this._cbTip.TabIndex      = 3;

            // _lblAc
            this._lblAc.BackColor  = System.Drawing.Color.Transparent;
            this._lblAc.Font       = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblAc.ForeColor  = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblAc.Location   = new System.Drawing.Point(14, 432);
            this._lblAc.Name       = "_lblAc";
            this._lblAc.Size       = new System.Drawing.Size(120, 28);
            this._lblAc.TabIndex   = 4;
            this._lblAc.Text       = "Açıklama:";

            // _txtAc
            this._txtAc.BackColor   = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtAc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtAc.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtAc.ForeColor   = System.Drawing.Color.FromArgb(248, 250, 252);
            this._txtAc.Location    = new System.Drawing.Point(140, 430);
            this._txtAc.Multiline   = true;
            this._txtAc.Name        = "_txtAc";
            this._txtAc.Size        = new System.Drawing.Size(526, 48);
            this._txtAc.TabIndex    = 5;

            // _lblYeniTarih
            this._lblYeniTarih.BackColor  = System.Drawing.Color.Transparent;
            this._lblYeniTarih.Font       = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblYeniTarih.ForeColor  = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblYeniTarih.Location   = new System.Drawing.Point(14, 493);
            this._lblYeniTarih.Name       = "_lblYeniTarih";
            this._lblYeniTarih.Size       = new System.Drawing.Size(120, 28);
            this._lblYeniTarih.TabIndex   = 6;
            this._lblYeniTarih.Text       = "Yeni Tarih:";

            // _dtpYeni
            this._dtpYeni.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dtpYeni.Location = new System.Drawing.Point(140, 493);
            this._dtpYeni.MinDate  = new System.DateTime(2026, 5, 24, 0, 0, 0, 0);
            this._dtpYeni.Name     = "_dtpYeni";
            this._dtpYeni.Size     = new System.Drawing.Size(260, 29);
            this._dtpYeni.TabIndex = 7;
            this._dtpYeni.Value    = new System.DateTime(2026, 5, 24, 0, 0, 0, 0);
            this._dtpYeni.Visible  = false;

            // _btnGonder
            this._btnGonder.BackColor                = System.Drawing.Color.FromArgb(16, 185, 129);
            this._btnGonder.Cursor                   = System.Windows.Forms.Cursors.Hand;
            this._btnGonder.FlatAppearance.BorderSize = 0;
            this._btnGonder.FlatStyle                = System.Windows.Forms.FlatStyle.Flat;
            this._btnGonder.Font                     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGonder.ForeColor                = System.Drawing.Color.White;
            this._btnGonder.Location                 = new System.Drawing.Point(14, 540);
            this._btnGonder.Name                     = "_btnGonder";
            this._btnGonder.Size                     = new System.Drawing.Size(280, 46);
            this._btnGonder.TabIndex                 = 8;
            this._btnGonder.Text                     = "Talep Gönder";
            this._btnGonder.UseVisualStyleBackColor  = false;

            // Form
            this.AutoScaleMode    = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor        = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize       = new System.Drawing.Size(700, 610);
            this.Controls.Add(this._card);
            this.Controls.Add(this._lblTalepBaslik);
            this.Controls.Add(this._lblTip);
            this.Controls.Add(this._cbTip);
            this.Controls.Add(this._lblYeniTarih);
            this.Controls.Add(this._dtpYeni);
            this.Controls.Add(this._lblAc);
            this.Controls.Add(this._txtAc);
            this.Controls.Add(this._btnGonder);
            this.Font             = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor        = System.Drawing.Color.FromArgb(248, 250, 252);
            this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox      = false;
            this.MinimizeBox      = false;
            this.Name             = "RezervasyonDetayForm";
            this.StartPosition    = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text             = "Rezervasyon Detayı";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel          _card;
        private System.Windows.Forms.Label          _lblTalepBaslik;
        private System.Windows.Forms.Label          _lblTip;
        private System.Windows.Forms.ComboBox       _cbTip;
        private System.Windows.Forms.Label          _lblYeniTarih;
        private System.Windows.Forms.DateTimePicker _dtpYeni;
        private System.Windows.Forms.Label          _lblAc;
        private System.Windows.Forms.TextBox        _txtAc;
        private System.Windows.Forms.Button         _btnGonder;
    }
}
