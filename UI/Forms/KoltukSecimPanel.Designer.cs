namespace oceangate_r.UI.Forms
{
    partial class KoltukSecimPanel
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

            this._lejantPanel = new System.Windows.Forms.Panel();
            this._koltukGrid  = new System.Windows.Forms.Panel();
            this._lBos        = new System.Windows.Forms.Label();
            this._lKadin      = new System.Windows.Forms.Label();
            this._lErkek      = new System.Windows.Forms.Label();
            this._lSecili     = new System.Windows.Forms.Label();
            this._lHover      = new System.Windows.Forms.Label();

            // ── Lejant ───────────────────────────────────────────────────────
            this._lejantPanel.Location  = new System.Drawing.Point(20, 8);
            this._lejantPanel.Size      = new System.Drawing.Size(960, 28);
            this._lejantPanel.BackColor = System.Drawing.Color.Transparent;

            this._lBos.Text      = "■ Boş";
            this._lBos.Location  = new System.Drawing.Point(0, 4);
            this._lBos.Size      = new System.Drawing.Size(72, 20);
            this._lBos.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this._lBos.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lBos.BackColor = System.Drawing.Color.Transparent;

            this._lKadin.Text      = "■ Kadın";
            this._lKadin.Location  = new System.Drawing.Point(80, 4);
            this._lKadin.Size      = new System.Drawing.Size(72, 20);
            this._lKadin.ForeColor = System.Drawing.Color.FromArgb(236, 72, 153);
            this._lKadin.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lKadin.BackColor = System.Drawing.Color.Transparent;

            this._lErkek.Text      = "■ Erkek";
            this._lErkek.Location  = new System.Drawing.Point(160, 4);
            this._lErkek.Size      = new System.Drawing.Size(72, 20);
            this._lErkek.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this._lErkek.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lErkek.BackColor = System.Drawing.Color.Transparent;

            this._lSecili.Text      = "■ Seçili";
            this._lSecili.Location  = new System.Drawing.Point(240, 4);
            this._lSecili.Size      = new System.Drawing.Size(72, 20);
            this._lSecili.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this._lSecili.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lSecili.BackColor = System.Drawing.Color.Transparent;

            this._lHover.Text      = "■ Seçiliyor";
            this._lHover.Location  = new System.Drawing.Point(320, 4);
            this._lHover.Size      = new System.Drawing.Size(90, 20);
            this._lHover.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this._lHover.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lHover.BackColor = System.Drawing.Color.Transparent;

            this._lejantPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lBos, this._lKadin, this._lErkek, this._lSecili, this._lHover
            });

            // ── Koltuk Grid ──────────────────────────────────────────────────
            this._koltukGrid.Location   = new System.Drawing.Point(20, 44);
            this._koltukGrid.Size       = new System.Drawing.Size(960, 370);
            this._koltukGrid.BackColor  = System.Drawing.Color.FromArgb(22, 33, 55);
            this._koltukGrid.AutoScroll = true;

            // ── UserControl Özellikleri ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            
            this.BackColor      = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name           = "KoltukSecimPanel";
            this.Size           = new System.Drawing.Size(994, 432);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._lejantPanel, this._koltukGrid
            });

            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel _lejantPanel;
        private System.Windows.Forms.Panel _koltukGrid;
        private System.Windows.Forms.Label _lBos;
        private System.Windows.Forms.Label _lKadin;
        private System.Windows.Forms.Label _lErkek;
        private System.Windows.Forms.Label _lSecili;
        private System.Windows.Forms.Label _lHover;
    }
}
