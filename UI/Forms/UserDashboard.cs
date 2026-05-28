using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
   
    public partial class UserDashboard : Form
    {
        private const int W = 1280, H = 780, TH = 50, SW = 230;
        private const int ContentH = 730; // H - TH

        public UserDashboard()
        {
            InitializeComponent();
            UIHelper.EnableDrag(_titleBar, this);
            string tamAd = SessionManager.AktifKullanici?.TamAd ?? "";
            _lblUserName.Text     = tamAd;
            _lblUserFullName.Text = tamAd;
            BakiyeGuncelle();

            
            _btnCikis.Click    += (s, e) => Close();

            _btnMenuAnaSayfa.Click += (s, e) => { SetActiveMenu(_btnMenuAnaSayfa); ShowAnaSayfa(); };
            _btnMenuYeniRez.Click  += (s, e) => { SetActiveMenu(_btnMenuYeniRez);  ShowYeniRezervason(); };
            _btnMenuRezlerim.Click += (s, e) => { SetActiveMenu(_btnMenuRezlerim); ShowRezervasyonlarim(); };
            
            _btnBakiyeYukle.Click += (s, e) => {
                using (var frm = new oceangate_r.UI.Forms.BakiyeYukleForm())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BakiyeGuncelle();
                    }
                }
            };

            _titleBar.Paint += (s, e) =>
            {
                using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(30, 41, 59), 1))
                    e.Graphics.DrawLine(pen, 0, 49, 1280, 49);
            };
            _sidebar.Paint += (s, e) =>
            {
                using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(30, 41, 59), 1))
                    e.Graphics.DrawLine(pen, 229, 0, 229, 730);
            };

            SetActiveMenu(_btnMenuAnaSayfa);
            ShowAnaSayfa();
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ClassStyle |= 0x20000; return cp; }
        }

      
        
        public void Yenile() { this.Invoke((System.Windows.Forms.MethodInvoker)delegate { BakiyeGuncelle(); SetActiveMenu(_btnMenuRezlerim); ShowRezervasyonlarim(); this.Refresh(); }); }
        private void BakiyeGuncelle()
        {
            if (SessionManager.AktifKullanici != null)
            {
                double bakiye = KullaniciDAL.BakiyeGetir(SessionManager.AktifKullanici.Id);
                SessionManager.AktifKullanici.Bakiye = bakiye;
                if (_lblBakiye != null)
                {
                    _lblBakiye.Text = $"Bakiye: {bakiye:N2} TL";
                }
            }
        }
        
        private void ShowAnaSayfa()
        {
            _contentArea.Controls.Clear();
            int cw = W - SW - 40;

            var lblH = UIHelper.MakeLabel("Ana Sayfa", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 24, 400, 36);
            _contentArea.Controls.Add(lblH);

            var welcomeCard = UIHelper.MakeCard(24, 76, cw, 110, AppTheme.BgCard);
            string welText = $"Hoş geldiniz, {SessionManager.AktifKullanici?.TamAd}!";
            var lblWel = UIHelper.MakeLabel(welText, AppTheme.SubFont,
                AppTheme.TextLight, 20, 18, cw - 40, 32);
            var lblWelSub = UIHelper.MakeLabel(
                "Denizaltı serüveninizi planlamak için hazır mısınız?",
                AppTheme.BodyFont, AppTheme.TextMuted, 20, 56, cw - 40, 28);
            welcomeCard.Controls.AddRange(new Control[] { lblWel, lblWelSub });
            _contentArea.Controls.Add(welcomeCard);

            var rezervasyonlar = RezervasyonDAL.KullanicininRezervasyonlari(
                SessionManager.AktifKullanici.Id);

            int aktifRez = 0, toplamRez = rezervasyonlar.Count;
            double toplamHarcama = 0;
            foreach (var r in rezervasyonlar)
            {
                if (r.Durum == "Onaylandi") aktifRez++;
                if (r.Durum != "Iptal")      toplamHarcama += r.ToplamTutar;
            }

            var statlar = new (string Baslik, string Deger, Color Renk)[]
            {
                ("Toplam Rezervasyon", toplamRez.ToString(),     AppTheme.Accent),
                ("Aktif Rezervasyon",  aktifRez.ToString(),      AppTheme.Success),
                ("Toplam Harcama",     $"{toplamHarcama:N0} TL", AppTheme.Warning),
            };

            int sx = 24, cardW = (cw - 48) / 3;
            foreach (var (baslik, deger, renk) in statlar)
            {
                var card = UIHelper.MakeCard(sx, 206, cardW, 100);
                var lDeger = UIHelper.MakeLabel(deger, AppTheme.TitleFont, renk, 0, 12, cardW, 40);
                lDeger.TextAlign = ContentAlignment.MiddleCenter;
                var lBaslik = UIHelper.MakeLabel(baslik, AppTheme.SmallFont,
                    AppTheme.TextMuted, 0, 56, cardW, 24);
                lBaslik.TextAlign = ContentAlignment.MiddleCenter;
                card.Controls.AddRange(new Control[] { lDeger, lBaslik });
                _contentArea.Controls.Add(card);
                sx += cardW + 24;
            }

            var lblSon = UIHelper.MakeLabel("Son Rezervasyonlar", AppTheme.SubFont,
                AppTheme.TextLight, 24, 326, 300, 28);
            _contentArea.Controls.Add(lblSon);

            var dgv = new DataGridView
            {
                Location = new Point(24, 362),
                Size     = new Size(cw, 340),
            };
            UIHelper.StyleGrid(dgv);
            dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "DekontNo", HeaderText = "Dekont No",    FillWeight = 18 },
                new DataGridViewTextBoxColumn { Name = "Sefer",    HeaderText = "Sefer",        FillWeight = 32 },
                new DataGridViewTextBoxColumn { Name = "Tarih",    HeaderText = "Sefer Tarihi", FillWeight = 18 },
                new DataGridViewTextBoxColumn { Name = "Kisi",     HeaderText = "Kişi",         FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Tutar",    HeaderText = "Tutar",        FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Durum",    HeaderText = "Durum",        FillWeight = 14 }
            );
            foreach (var r in rezervasyonlar)
            {
                int idx = dgv.Rows.Add(r.DekontNo, r.SeferBilgisi, r.SeferTarihiStr,
                    r.KisiSayisi, r.ToplamTutarStr, UIHelper.DurumMetni(r.Durum));
                dgv.Rows[idx].DefaultCellStyle.ForeColor = UIHelper.DurumRengi(r.Durum);
            }
            _contentArea.Controls.Add(dgv);
        }

        private void _btnMenuYeniRez_Click(object sender, EventArgs e) {}

        private void _btnBakiyeYukle_Click(object sender, EventArgs e)
        {

        }

        private void ShowYeniRezervason()
        {
            var form1 = new Rez1BolgeForm(this);
            form1.FormClosed += (s, e) => { 
                this.Show(); 
                BakiyeGuncelle();
                SetActiveMenu(_btnMenuRezlerim);
                ShowRezervasyonlarim();
            };
            form1.Show();
        }

        private void ShowRezervasyonlarim()
        {
            _contentArea.Controls.Clear();
            int cw = W - SW - 40;

            var lblH = UIHelper.MakeLabel("Rezervasyonlarım", AppTheme.TitleFont,
                AppTheme.TextLight, 24, 24, 400, 36);
            _contentArea.Controls.Add(lblH);

            var dgv = new DataGridView
            {
                Location = new Point(24, 72),
                Size     = new Size(cw, ContentH - 140),
            };
            UIHelper.StyleGrid(dgv);
            dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",       HeaderText = "ID",           FillWeight = 6,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "DekontNo", HeaderText = "Dekont No",    FillWeight = 16 },
                new DataGridViewTextBoxColumn { Name = "Sefer",    HeaderText = "Sefer",        FillWeight = 30 },
                new DataGridViewTextBoxColumn { Name = "STarih",   HeaderText = "Sefer Tarihi", FillWeight = 16 },
                new DataGridViewTextBoxColumn { Name = "Kisi",     HeaderText = "Kişi Sayısı",  FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "Tutar",    HeaderText = "Tutar",        FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Durum",    HeaderText = "Durum",        FillWeight = 14 }
            );

            var rezervasyonlar = RezervasyonDAL.KullanicininRezervasyonlari(
                SessionManager.AktifKullanici.Id);

            foreach (var r in rezervasyonlar)
            {
                int idx = dgv.Rows.Add(r.Id, r.DekontNo, r.SeferBilgisi, r.SeferTarihiStr,
                    r.KisiSayisi, r.ToplamTutarStr, UIHelper.DurumMetni(r.Durum));
                dgv.Rows[idx].DefaultCellStyle.ForeColor = UIHelper.DurumRengi(r.Durum);
            }

            var btnDetay = UIHelper.MakeButton("Detay / Talep Oluştur", 24, ContentH - 60, 280, 44);
            btnDetay.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen detaylarını görmek istediğiniz rezervasyonu tablodan seçiniz.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int rezId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                var secili = rezervasyonlar.Find(x => x.Id == rezId);
                if (secili == null) return;
                using (var detay = new RezervasyonDetayForm(secili))
                {
                    detay.ShowDialog(this);
                    ShowRezervasyonlarim();
                }
            };

            _contentArea.Controls.AddRange(new Control[] { dgv, btnDetay });
        }

    
        private void SetActiveMenu(Button btn)
        {
            if (_activeMenu != null)
            {
                _activeMenu.BackColor = Color.Transparent;
                _activeMenu.ForeColor = AppTheme.TextMuted;
            }
            _activeMenu = btn;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(20, 14, 165, 233);
                btn.ForeColor = AppTheme.Accent;
            }
        }
    }
}
