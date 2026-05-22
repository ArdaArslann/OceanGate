namespace oceangate_r.UI.Forms
{
    partial class CinsiyetSecimForm
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

            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblBaslik.Text      = "Koltuk için cinsiyet seçin:";
            this.lblBaslik.Location  = new System.Drawing.Point(16, 16);
            this.lblBaslik.Size      = new System.Drawing.Size(260, 24);
            this.lblBaslik.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);

            this._rdKadin = new System.Windows.Forms.RadioButton();
            this._rdKadin.Text      = "Kadın";
            this._rdKadin.Location  = new System.Drawing.Point(24, 52);
            this._rdKadin.Size      = new System.Drawing.Size(100, 28);
            this._rdKadin.ForeColor = System.Drawing.Color.FromArgb(249, 168, 212);
            this._rdKadin.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this._rdKadin.Checked   = true;

            this._rdErkek = new System.Windows.Forms.RadioButton();
            this._rdErkek.Text      = "Erkek";
            this._rdErkek.Location  = new System.Drawing.Point(140, 52);
            this._rdErkek.Size      = new System.Drawing.Size(100, 28);
            this._rdErkek.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253);
            this._rdErkek.Font      = new System.Drawing.Font("Segoe UI", 9.5F);

            this._btnTamam = new System.Windows.Forms.Button();
            this._btnTamam.Text      = "Tamam";
            this._btnTamam.Location  = new System.Drawing.Point(80, 100);
            this._btnTamam.Size      = new System.Drawing.Size(90, 34);
            this._btnTamam.BackColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this._btnTamam.ForeColor = System.Drawing.Color.White;
            this._btnTamam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnTamam.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnTamam.Cursor    = System.Windows.Forms.Cursors.Hand;

            this._btnIptal = new System.Windows.Forms.Button();
            this._btnIptal.Text      = "İptal";
            this._btnIptal.Location  = new System.Drawing.Point(182, 100);
            this._btnIptal.Size      = new System.Drawing.Size(76, 34);
            this._btnIptal.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this._btnIptal.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this._btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnIptal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this._btnIptal.Cursor    = System.Windows.Forms.Cursors.Hand;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximizeBox = false;
            this.BackColor      = System.Drawing.Color.FromArgb(51, 65, 85);
            this.ClientSize     = new System.Drawing.Size(300, 150);
            this.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor      = System.Drawing.Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox    = false;
            this.MinimizeBox    = false;
            this.Name           = "CinsiyetSecimForm";
            this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text           = "Cinsiyet Seçimi";

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblBaslik, this._rdKadin, this._rdErkek,
                this._btnTamam, this._btnIptal
            });

            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.RadioButton _rdKadin;
        private System.Windows.Forms.RadioButton _rdErkek;
        private System.Windows.Forms.Button _btnTamam;
        private System.Windows.Forms.Button _btnIptal;
    }
}
