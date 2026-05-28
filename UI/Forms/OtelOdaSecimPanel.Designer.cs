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
            this._lblBaslik = new System.Windows.Forms.Label();
            this._lejantPanel = new System.Windows.Forms.Panel();
            this._lBos = new System.Windows.Forms.Label();
            this._lDolu = new System.Windows.Forms.Label();
            this._lUyumsuz = new System.Windows.Forms.Label();
            this._lSecili = new System.Windows.Forms.Label();
            this._contentPanel = new System.Windows.Forms.Panel();
            this._lejantPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblBaslik
            // 
            this._lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this._lblBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._lblBaslik.Location = new System.Drawing.Point(20, 16);
            this._lblBaslik.Name = "_lblBaslik";
            this._lblBaslik.Size = new System.Drawing.Size(960, 28);
            this._lblBaslik.TabIndex = 0;
            this._lblBaslik.Text = "Otel Odası Seçimi";
            // 
            // _lejantPanel
            // 
            this._lejantPanel.BackColor = System.Drawing.Color.Transparent;
            this._lejantPanel.Controls.Add(this._lBos);
            this._lejantPanel.Controls.Add(this._lDolu);
            this._lejantPanel.Controls.Add(this._lUyumsuz);
            this._lejantPanel.Controls.Add(this._lSecili);
            this._lejantPanel.Location = new System.Drawing.Point(20, 52);
            this._lejantPanel.Name = "_lejantPanel";
            this._lejantPanel.Size = new System.Drawing.Size(960, 24);
            this._lejantPanel.TabIndex = 1;
            // 
            // _lBos
            // 
            this._lBos.BackColor = System.Drawing.Color.Transparent;
            this._lBos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lBos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this._lBos.Location = new System.Drawing.Point(0, 2);
            this._lBos.Name = "_lBos";
            this._lBos.Size = new System.Drawing.Size(120, 20);
            this._lBos.TabIndex = 0;
            this._lBos.Text = "■ Seçilebilir";
            // 
            // _lDolu
            // 
            this._lDolu.BackColor = System.Drawing.Color.Transparent;
            this._lDolu.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lDolu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this._lDolu.Location = new System.Drawing.Point(130, 2);
            this._lDolu.Name = "_lDolu";
            this._lDolu.Size = new System.Drawing.Size(120, 20);
            this._lDolu.TabIndex = 1;
            this._lDolu.Text = "■ Dolu";
            // 
            // _lUyumsuz
            // 
            this._lUyumsuz.BackColor = System.Drawing.Color.Transparent;
            this._lUyumsuz.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lUyumsuz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this._lUyumsuz.Location = new System.Drawing.Point(260, 2);
            this._lUyumsuz.Name = "_lUyumsuz";
            this._lUyumsuz.Size = new System.Drawing.Size(150, 20);
            this._lUyumsuz.TabIndex = 2;
            this._lUyumsuz.Text = "■ Uyumsuz Kapasite";
            // 
            // _lSecili
            // 
            this._lSecili.BackColor = System.Drawing.Color.Transparent;
            this._lSecili.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lSecili.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this._lSecili.Location = new System.Drawing.Point(420, 2);
            this._lSecili.Name = "_lSecili";
            this._lSecili.Size = new System.Drawing.Size(120, 20);
            this._lSecili.TabIndex = 3;
            this._lSecili.Text = "■ Seçildi";
            this._lSecili.Click += new System.EventHandler(this._lSecili_Click);
            // 
            // _contentPanel
            // 
            this._contentPanel.AutoScroll = true;
            this._contentPanel.BackColor = System.Drawing.Color.Transparent;
            this._contentPanel.Location = new System.Drawing.Point(0, 84);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(994, 380);
            this._contentPanel.TabIndex = 2;
            // 
            // OtelOdaSecimPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Controls.Add(this._lblBaslik);
            this.Controls.Add(this._lejantPanel);
            this.Controls.Add(this._contentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "OtelOdaSecimPanel";
            this.Size = new System.Drawing.Size(994, 472);
            this._lejantPanel.ResumeLayout(false);
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
