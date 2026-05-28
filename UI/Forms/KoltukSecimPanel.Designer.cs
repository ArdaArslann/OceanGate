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
            this._lejantPanel = new System.Windows.Forms.Panel();
            this._lBos = new System.Windows.Forms.Label();
            this._lKadin = new System.Windows.Forms.Label();
            this._lErkek = new System.Windows.Forms.Label();
            this._lSecili = new System.Windows.Forms.Label();
            this._lHover = new System.Windows.Forms.Label();
            this._koltukGrid = new System.Windows.Forms.Panel();
            this._lejantPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lejantPanel
            // 
            this._lejantPanel.BackColor = System.Drawing.Color.Transparent;
            this._lejantPanel.Controls.Add(this._lBos);
            this._lejantPanel.Controls.Add(this._lKadin);
            this._lejantPanel.Controls.Add(this._lErkek);
            this._lejantPanel.Controls.Add(this._lSecili);
            this._lejantPanel.Controls.Add(this._lHover);
            this._lejantPanel.Location = new System.Drawing.Point(20, 8);
            this._lejantPanel.Name = "_lejantPanel";
            this._lejantPanel.Size = new System.Drawing.Size(960, 28);
            this._lejantPanel.TabIndex = 0;
            // 
            // _lBos
            // 
            this._lBos.BackColor = System.Drawing.Color.Transparent;
            this._lBos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lBos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._lBos.Location = new System.Drawing.Point(0, 4);
            this._lBos.Name = "_lBos";
            this._lBos.Size = new System.Drawing.Size(72, 20);
            this._lBos.TabIndex = 0;
            this._lBos.Text = "■ Boş";
            // 
            // _lKadin
            // 
            this._lKadin.BackColor = System.Drawing.Color.Transparent;
            this._lKadin.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lKadin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            this._lKadin.Location = new System.Drawing.Point(80, 4);
            this._lKadin.Name = "_lKadin";
            this._lKadin.Size = new System.Drawing.Size(72, 20);
            this._lKadin.TabIndex = 1;
            this._lKadin.Text = "■ Kadın";
            // 
            // _lErkek
            // 
            this._lErkek.BackColor = System.Drawing.Color.Transparent;
            this._lErkek.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lErkek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this._lErkek.Location = new System.Drawing.Point(160, 4);
            this._lErkek.Name = "_lErkek";
            this._lErkek.Size = new System.Drawing.Size(72, 20);
            this._lErkek.TabIndex = 2;
            this._lErkek.Text = "■ Erkek";
            // 
            // _lSecili
            // 
            this._lSecili.BackColor = System.Drawing.Color.Transparent;
            this._lSecili.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lSecili.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this._lSecili.Location = new System.Drawing.Point(240, 4);
            this._lSecili.Name = "_lSecili";
            this._lSecili.Size = new System.Drawing.Size(72, 20);
            this._lSecili.TabIndex = 3;
            this._lSecili.Text = "■ Seçili";
            // 
            // _lHover
            // 
            this._lHover.BackColor = System.Drawing.Color.Transparent;
            this._lHover.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lHover.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this._lHover.Location = new System.Drawing.Point(320, 4);
            this._lHover.Name = "_lHover";
            this._lHover.Size = new System.Drawing.Size(90, 20);
            this._lHover.TabIndex = 4;
            this._lHover.Text = "■ Seçiliyor";
            this._lHover.Click += new System.EventHandler(this._lHover_Click);
            // 
            // _koltukGrid
            // 
            this._koltukGrid.AutoScroll = true;
            this._koltukGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(33)))), ((int)(((byte)(55)))));
            this._koltukGrid.Location = new System.Drawing.Point(20, 44);
            this._koltukGrid.Name = "_koltukGrid";
            this._koltukGrid.Size = new System.Drawing.Size(960, 370);
            this._koltukGrid.TabIndex = 1;
            // 
            // KoltukSecimPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Controls.Add(this._lejantPanel);
            this.Controls.Add(this._koltukGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "KoltukSecimPanel";
            this.Size = new System.Drawing.Size(994, 432);
            this._lejantPanel.ResumeLayout(false);
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
