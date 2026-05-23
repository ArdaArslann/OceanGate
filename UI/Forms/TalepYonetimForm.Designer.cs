namespace oceangate_r
{
    partial class TalepYonetimForm
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
            this.components = new System.ComponentModel.Container();

            
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHeader.Text      = "Talep Yönetimi";
            this.lblHeader.Location  = new System.Drawing.Point(24, 22);
            this.lblHeader.Size      = new System.Drawing.Size(500, 36);
            this.lblHeader.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);

            this.lblSub = new System.Windows.Forms.Label();
            this.lblSub.Text      = "Kullanıcıların gönderdiği iptal, değişiklik ve iade talepleri";
            this.lblSub.Location  = new System.Drawing.Point(24, 62);
            this.lblSub.Size      = new System.Drawing.Size(700, 24);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSub.Font      = new System.Drawing.Font("Segoe UI", 9.5F);

            
            this._btnTabTumu = new oceangate_r.UI.Controls.OceanButton();
            this._btnTabTumu.Text     = "Tümü";
            this._btnTabTumu.Location = new System.Drawing.Point(24, 100);
            this._btnTabTumu.Size     = new System.Drawing.Size(100, 36);

            this._btnTabBekleyen = new oceangate_r.UI.Controls.OceanButton();
            this._btnTabBekleyen.Text     = "Bekleyenler";
            this._btnTabBekleyen.Location = new System.Drawing.Point(136, 100);
            this._btnTabBekleyen.Size     = new System.Drawing.Size(160, 36);


            
            this._dgv = new System.Windows.Forms.DataGridView();
            this._dgv.Location        = new System.Drawing.Point(24, 150);
            this._dgv.Size            = new System.Drawing.Size(1110, 330);
            this._dgv.Anchor          = System.Windows.Forms.AnchorStyles.Top
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right
                                      | System.Windows.Forms.AnchorStyles.Bottom;
            this._dgv.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._dgv.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this._dgv.RowHeadersVisible = false;
            this._dgv.SelectionMode   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.AllowUserToAddRows = false;
            this._dgv.ReadOnly        = true;
            this._dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this._dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this._dgv.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._dgv.Font            = new System.Drawing.Font("Segoe UI", 9.5F);

             
            this._actionBar = new System.Windows.Forms.Panel();
            this._actionBar.Location  = new System.Drawing.Point(24, 492);
            this._actionBar.Size      = new System.Drawing.Size(1110, 70);
            this._actionBar.Anchor    = System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right;
            this._actionBar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);

            this._btnOnayla = new oceangate_r.UI.Controls.OceanButton();
            this._btnOnayla.Text     = "Onayla";
            this._btnOnayla.Location = new System.Drawing.Point(16, 12);
            this._btnOnayla.Size     = new System.Drawing.Size(200, 46);
            this._btnOnayla.Enabled  = false;

            this._btnReddet = new oceangate_r.UI.Controls.OceanButton();
            this._btnReddet.Text     = "Reddet";
            this._btnReddet.Location = new System.Drawing.Point(228, 12);
            this._btnReddet.Size     = new System.Drawing.Size(200, 46);
            this._btnReddet.Enabled  = false;

            this.lblHint = new System.Windows.Forms.Label();
            this.lblHint.Text      = "Bir talep seçerek işlem yapabilirsiniz.";
            this.lblHint.Location  = new System.Drawing.Point(440, 20);
            this.lblHint.Size      = new System.Drawing.Size(280, 30);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Font      = new System.Drawing.Font("Segoe UI", 9F);

            this._actionBar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this._btnOnayla, this._btnReddet, this.lblHint
            });

            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximizeBox = false;
            this.BackColor      = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize     = new System.Drawing.Size(1160, 580);
            this.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor      = System.Drawing.Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name           = "TalepYonetimForm";
            this.Text           = "Talep Yönetimi";

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblHeader, this.lblSub,
                this._btnTabTumu, this._btnTabBekleyen,
                this._dgv, this._actionBar
            });

            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this.ResumeLayout(false);
        }

       

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.DataGridView _dgv;
        private oceangate_r.UI.Controls.OceanButton _btnOnayla;
        private oceangate_r.UI.Controls.OceanButton _btnReddet;
        private oceangate_r.UI.Controls.OceanButton _btnTabTumu;
        private oceangate_r.UI.Controls.OceanButton _btnTabBekleyen;
        private System.Windows.Forms.Panel _actionBar;
    }
}
