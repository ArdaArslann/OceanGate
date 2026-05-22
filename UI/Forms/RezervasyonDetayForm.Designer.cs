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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this._titleBar   = new System.Windows.Forms.Panel();
            this._lblTitle   = new System.Windows.Forms.Label();
            this._btnKapat   = new System.Windows.Forms.Button();
            this._card       = new System.Windows.Forms.Panel();

            // Talep bölümü
            this._lblTalepBaslik  = new System.Windows.Forms.Label();
            this._lblTip          = new System.Windows.Forms.Label();
            this._cbTip           = new System.Windows.Forms.ComboBox();
            this._lblYeniTarih    = new System.Windows.Forms.Label();
            this._dtpYeni         = new System.Windows.Forms.DateTimePicker();
            this._lblAc           = new System.Windows.Forms.Label();
            this._txtAc           = new System.Windows.Forms.TextBox();
            this._btnGonder       = new System.Windows.Forms.Button();

            // ── Title Bar ────────────────────────────────────────────────────
            this._titleBar.Location  = new System.Drawing.Point(0, 0);
            this._titleBar.Size      = new System.Drawing.Size(700, 50);
            this._titleBar.BackColor = System.Drawing.Color.FromArgb(10, 15, 30);

            this._lblTitle.Text      = "Rezervasyon Detayı";
            this._lblTitle.Location  = new System.Drawing.Point(20, 0);
            this._lblTitle.Size      = new System.Drawing.Size(400, 50);
            this._lblTitle.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblTitle.BackColor = System.Drawing.Color.Transparent;

            this._btnKapat.Text      = "✕";
            this._btnKapat.Location  = new System.Drawing.Point(654, 0);
            this._btnKapat.Size      = new System.Drawing.Size(46, 50);
            this._btnKapat.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._btnKapat.BackColor = System.Drawing.Color.Transparent;
            this._btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnKapat.Font      = new System.Drawing.Font("Segoe UI", 12F);
            this._btnKapat.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnKapat.FlatAppearance.BorderSize = 0;

            this._titleBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lblTitle, this._btnKapat
            });

            // ── Bilgi kartı ───────────────────────────────────────────────────
            this._card.Location  = new System.Drawing.Point(24, 64);
            this._card.Size      = new System.Drawing.Size(652, 320);
            this._card.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);

            // ── Talep bölümü ──────────────────────────────────────────────────
            this._lblTalepBaslik.Text      = "Talep Oluştur";
            this._lblTalepBaslik.Location  = new System.Drawing.Point(24, 400);
            this._lblTalepBaslik.Size      = new System.Drawing.Size(300, 32);
            this._lblTalepBaslik.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblTalepBaslik.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblTalepBaslik.BackColor = System.Drawing.Color.Transparent;

            this._lblTip.Text      = "Talep Türü:";
            this._lblTip.Location  = new System.Drawing.Point(24, 442);
            this._lblTip.Size      = new System.Drawing.Size(120, 28);
            this._lblTip.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblTip.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblTip.BackColor = System.Drawing.Color.Transparent;

            this._cbTip.Location      = new System.Drawing.Point(150, 440);
            this._cbTip.Size          = new System.Drawing.Size(260, 32);
            this._cbTip.BackColor     = System.Drawing.Color.FromArgb(30, 41, 59);
            this._cbTip.ForeColor     = System.Drawing.Color.FromArgb(248, 250, 252);
            this._cbTip.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cbTip.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this._cbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTip.Items.AddRange(new object[] { "İptal ve İade", "Tarih Değişikliği", "Diğer" });
            this._cbTip.SelectedIndex = 0;

            this._lblYeniTarih.Text      = "Yeni Tarih:";
            this._lblYeniTarih.Location  = new System.Drawing.Point(24, 490);
            this._lblYeniTarih.Size      = new System.Drawing.Size(120, 28);
            this._lblYeniTarih.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblYeniTarih.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblYeniTarih.BackColor = System.Drawing.Color.Transparent;

            this._dtpYeni.Location = new System.Drawing.Point(150, 488);
            this._dtpYeni.Size     = new System.Drawing.Size(260, 32);
            this._dtpYeni.MinDate  = System.DateTime.Today.AddDays(1);
            this._dtpYeni.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this._dtpYeni.Visible  = false;

            this._lblAc.Text      = "Açıklama:";
            this._lblAc.Location  = new System.Drawing.Point(24, 486);
            this._lblAc.Size      = new System.Drawing.Size(120, 28);
            this._lblAc.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblAc.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this._lblAc.BackColor = System.Drawing.Color.Transparent;

            this._txtAc.Location    = new System.Drawing.Point(150, 484);
            this._txtAc.Size        = new System.Drawing.Size(526, 48);
            this._txtAc.BackColor   = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtAc.ForeColor   = System.Drawing.Color.FromArgb(248, 250, 252);
            this._txtAc.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this._txtAc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtAc.Multiline   = true;

            this._btnGonder.Text      = "Talep Gönder";
            this._btnGonder.Location  = new System.Drawing.Point(24, 490);
            this._btnGonder.Size      = new System.Drawing.Size(280, 46);
            this._btnGonder.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this._btnGonder.ForeColor = System.Drawing.Color.White;
            this._btnGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGonder.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnGonder.Cursor    = System.Windows.Forms.Cursors.Hand;
            this._btnGonder.FlatAppearance.BorderSize = 0;

            // ── Form ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximizeBox = false;
            this.BackColor      = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize     = new System.Drawing.Size(700, 560);
            this.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor      = System.Drawing.Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox    = false;
            this.Name           = "RezervasyonDetayForm";
            this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text           = "Rezervasyon Detayı";

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._titleBar, this._card,
                this._lblTalepBaslik, this._lblTip, this._cbTip,
                this._lblYeniTarih, this._dtpYeni,
                this._lblAc, this._txtAc, this._btnGonder
            });

            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion

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
