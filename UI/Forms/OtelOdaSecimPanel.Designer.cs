namespace oceangate_r.UI.Forms
{
    partial class OtelOdaSecimPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this._lblBaslik    = new System.Windows.Forms.Label();
            this._lejantPanel  = new System.Windows.Forms.Panel();
            this._contentPanel = new System.Windows.Forms.Panel();
            this._lBos         = new System.Windows.Forms.Label();
            this._lDolu        = new System.Windows.Forms.Label();
            this._lUyumsuz     = new System.Windows.Forms.Label();
            this._lSecili      = new System.Windows.Forms.Label();

            // ── Başlık ───────────────────────────────────────────────────────
            this._lblBaslik.Text      = "Otel Odası Seçimi";
            this._lblBaslik.Location  = new System.Drawing.Point(20, 16);
            this._lblBaslik.Size      = new System.Drawing.Size(960, 28);
            this._lblBaslik.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblBaslik.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._lblBaslik.BackColor = System.Drawing.Color.Transparent;

            // ── Lejant ───────────────────────────────────────────────────────
            this._lejantPanel.Location  = new System.Drawing.Point(20, 52);
            this._lejantPanel.Size      = new System.Drawing.Size(960, 24);
            this._lejantPanel.BackColor = System.Drawing.Color.Transparent;

            this._lBos.Text      = "■ Seçilebilir";
            this._lBos.Location  = new System.Drawing.Point(0, 2);
            this._lBos.Size      = new System.Drawing.Size(120, 20);
            this._lBos.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this._lBos.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lBos.BackColor = System.Drawing.Color.Transparent;

            this._lDolu.Text      = "■ Dolu";
            this._lDolu.Location  = new System.Drawing.Point(130, 2);
            this._lDolu.Size      = new System.Drawing.Size(120, 20);
            this._lDolu.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this._lDolu.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lDolu.BackColor = System.Drawing.Color.Transparent;

            this._lUyumsuz.Text      = "■ Uyumsuz Kapasite";
            this._lUyumsuz.Location  = new System.Drawing.Point(260, 2);
            this._lUyumsuz.Size      = new System.Drawing.Size(150, 20);
            this._lUyumsuz.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);
            this._lUyumsuz.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lUyumsuz.BackColor = System.Drawing.Color.Transparent;

            this._lSecili.Text      = "■ Seçildi";
            this._lSecili.Location  = new System.Drawing.Point(420, 2);
            this._lSecili.Size      = new System.Drawing.Size(120, 20);
            this._lSecili.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this._lSecili.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lSecili.BackColor = System.Drawing.Color.Transparent;

            this._lejantPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lBos, this._lDolu, this._lUyumsuz, this._lSecili
            });

            // ── İçerik Alanı ─────────────────────────────────────────────────
            this._contentPanel.Location   = new System.Drawing.Point(0, 84);
            this._contentPanel.Size       = new System.Drawing.Size(994, 380);
            this._contentPanel.BackColor  = System.Drawing.Color.Transparent;
            this._contentPanel.AutoScroll = true;

            // ── UserControl Özellikleri ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            
            this.BackColor      = System.Drawing.Color.FromArgb(15, 23, 42);
            this.AutoScroll     = true;
            this.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name           = "OtelOdaSecimPanel";
            this.Size           = new System.Drawing.Size(994, 472);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lblBaslik, this._lejantPanel, this._contentPanel
            });

            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label _lblBaslik;
        private System.Windows.Forms.Panel _lejantPanel;
        private System.Windows.Forms.Panel _contentPanel;
        private System.Windows.Forms.Label _lBos;
        private System.Windows.Forms.Label _lDolu;
        private System.Windows.Forms.Label _lUyumsuz;
        private System.Windows.Forms.Label _lSecili;
    }
}
