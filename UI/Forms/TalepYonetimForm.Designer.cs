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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this._btnTabTumu = new oceangate_r.UI.Controls.OceanButton();
            this._btnTabBekleyen = new oceangate_r.UI.Controls.OceanButton();
            this._dgv = new System.Windows.Forms.DataGridView();
            this._actionBar = new System.Windows.Forms.Panel();
            this._btnOnayla = new oceangate_r.UI.Controls.OceanButton();
            this._btnReddet = new oceangate_r.UI.Controls.OceanButton();
            this.lblHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this._actionBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblHeader.Location = new System.Drawing.Point(24, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(500, 36);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Talep Yönetimi";
            // 
            // lblSub
            // 
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSub.Location = new System.Drawing.Point(24, 62);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(700, 24);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Kullanıcıların gönderdiği iptal, değişiklik ve iade talepleri";
            // 
            // _btnTabTumu
            // 
            this._btnTabTumu.BackColor = System.Drawing.Color.Transparent;
            this._btnTabTumu.CornerRadius = 6;
            this._btnTabTumu.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnTabTumu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnTabTumu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnTabTumu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._btnTabTumu.Location = new System.Drawing.Point(24, 100);
            this._btnTabTumu.Name = "_btnTabTumu";
            this._btnTabTumu.Size = new System.Drawing.Size(100, 36);
            this._btnTabTumu.TabIndex = 2;
            this._btnTabTumu.Text = "Tümü";
            this._btnTabTumu.UseVisualStyleBackColor = false;
            // 
            // _btnTabBekleyen
            // 
            this._btnTabBekleyen.BackColor = System.Drawing.Color.Transparent;
            this._btnTabBekleyen.CornerRadius = 6;
            this._btnTabBekleyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnTabBekleyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnTabBekleyen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnTabBekleyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._btnTabBekleyen.Location = new System.Drawing.Point(136, 100);
            this._btnTabBekleyen.Name = "_btnTabBekleyen";
            this._btnTabBekleyen.Size = new System.Drawing.Size(160, 36);
            this._btnTabBekleyen.TabIndex = 3;
            this._btnTabBekleyen.Text = "Bekleyenler";
            this._btnTabBekleyen.UseVisualStyleBackColor = false;
            // 
            // _dgv
            // 
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
            this._dgv.Location = new System.Drawing.Point(24, 150);
            this._dgv.Name = "_dgv";
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersVisible = false;
            this._dgv.RowHeadersWidth = 51;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(1110, 330);
            this._dgv.TabIndex = 4;
            // 
            // _actionBar
            // 
            this._actionBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._actionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._actionBar.Controls.Add(this._btnOnayla);
            this._actionBar.Controls.Add(this._btnReddet);
            this._actionBar.Controls.Add(this.lblHint);
            this._actionBar.Location = new System.Drawing.Point(24, 492);
            this._actionBar.Name = "_actionBar";
            this._actionBar.Size = new System.Drawing.Size(1110, 70);
            this._actionBar.TabIndex = 5;
            // 
            // _btnOnayla
            // 
            this._btnOnayla.BackColor = System.Drawing.Color.Transparent;
            this._btnOnayla.CornerRadius = 6;
            this._btnOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnOnayla.Enabled = false;
            this._btnOnayla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOnayla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnOnayla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._btnOnayla.Location = new System.Drawing.Point(16, 12);
            this._btnOnayla.Name = "_btnOnayla";
            this._btnOnayla.Size = new System.Drawing.Size(200, 46);
            this._btnOnayla.TabIndex = 0;
            this._btnOnayla.Text = "Onayla";
            this._btnOnayla.UseVisualStyleBackColor = false;
            this._btnOnayla.Click += new System.EventHandler(this._btnOnayla_Click);
            // 
            // _btnReddet
            // 
            this._btnReddet.BackColor = System.Drawing.Color.Transparent;
            this._btnReddet.CornerRadius = 6;
            this._btnReddet.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnReddet.Enabled = false;
            this._btnReddet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnReddet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnReddet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this._btnReddet.Location = new System.Drawing.Point(228, 12);
            this._btnReddet.Name = "_btnReddet";
            this._btnReddet.Size = new System.Drawing.Size(200, 46);
            this._btnReddet.TabIndex = 1;
            this._btnReddet.Text = "Reddet";
            this._btnReddet.UseVisualStyleBackColor = false;
            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHint.Location = new System.Drawing.Point(440, 20);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(280, 30);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "Bir talep seçerek işlem yapabilirsiniz.";
            // 
            // TalepYonetimForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1160, 580);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this._btnTabTumu);
            this.Controls.Add(this._btnTabBekleyen);
            this.Controls.Add(this._dgv);
            this.Controls.Add(this._actionBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TalepYonetimForm";
            this.Text = "Talep Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this._actionBar.ResumeLayout(false);
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
