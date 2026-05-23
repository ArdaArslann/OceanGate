using System;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>Admin – Kullanıcı talep yönetim formu (Onayla / Reddet).</summary>
    public partial class TalepYonetimForm : Form
    {
        private int _seciliId = -1;

        public TalepYonetimForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            UIHelper.StyleGrid(_dgv);
            _dgv.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id",        HeaderText = "ID",           FillWeight = 5,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "RezId",     HeaderText = "Rez.ID",       FillWeight = 5,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "Dekont",    HeaderText = "Dekont No",    FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Kullanici", HeaderText = "Kullanıcı",    FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Tip",       HeaderText = "Talep Türü",   FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Aciklama",  HeaderText = "Açıklama",     FillWeight = 24 },
                new DataGridViewTextBoxColumn { Name = "Tarih",     HeaderText = "Talep Tarihi", FillWeight = 14 },
                new DataGridViewTextBoxColumn { Name = "Durum",     HeaderText = "Durum",        FillWeight = 14 }
            );
            _dgv.SelectionChanged += DgvSelectionChanged;
            _btnTabTumu.SetColors(AppTheme.Accent, AppTheme.AccentHover, AppTheme.AccentDark);
            _btnTabBekleyen.SetMuted();

            _btnOnayla.SetSuccess();
            _btnReddet.SetDanger();
            _btnTabTumu.Click     += (s, e) => SetTab(false);
            _btnTabBekleyen.Click += (s, e) => SetTab(true);

            _btnOnayla.Click      += BtnOnayla_Click;
            _btnReddet.Click      += BtnReddet_Click;
            Resize += (s, e) => DoLayout();
            DoLayout();
            YukleVeriler();
        }

        private void DoLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;

            // Sabit üst bölüm: 150px (başlık + sekmeler + boşluk)
            // Sabit alt bölüm: 86px (aksiyon çubuğu 70px + 16px boşluk)
            // Geri kalan: tablo
            int usedH = 150 + 86;
            int gridH = Math.Max(h - usedH, 80);

            _dgv.Location    = new Point(24, 150);
            _dgv.Size        = new Size(w - 48, gridH);
            _actionBar.Location = new Point(24, 150 + gridH + 8);
            _actionBar.Size     = new Size(w - 48, 70);
        }

        private void SetTab(bool sadeceBekleyen)
        {
            if (sadeceBekleyen)
            {
                _btnTabBekleyen.SetColors(AppTheme.Accent, AppTheme.AccentHover, AppTheme.AccentDark);
                _btnTabTumu.SetMuted();
            }
            else
            {
                _btnTabTumu.SetColors(AppTheme.Accent, AppTheme.AccentHover, AppTheme.AccentDark);
                _btnTabBekleyen.SetMuted();
            }
            YukleVeriler(sadeceBekleyen);
        }

        private void YukleVeriler(bool sadeceBekleyen = false)
        {
            _dgv.SelectionChanged -= DgvSelectionChanged; // Eklerken eventi tetikleme
            _dgv.Rows.Clear();
            var list = sadeceBekleyen ? TalepDAL.Bekleyenler() : TalepDAL.Tumunu();

            foreach (var t in list)
            {
                string tipGoster;
                switch (t.TalepTipi)
                {
                    case "Iptal":      tipGoster = "İptal ve İade"; break;
                    case "Degisiklik": tipGoster = "Tarih Değişikliği"; break;
                    default:           tipGoster = t.TalepTipi; break;
                }

                int idx = _dgv.Rows.Add(
                    t.Id, t.RezervasyonId, t.DekontNo, t.KullaniciAdi,
                    tipGoster, t.Aciklama, t.TalepTarihiStr,
                    t.Durum == "Bekliyor"   ? "Bekliyor" :
                    t.Durum == "Onaylandi"  ? "Onaylandı" : "Reddedildi");

                Color renk = t.Durum == "Bekliyor"  ? AppTheme.Warning :
                             t.Durum == "Onaylandi" ? AppTheme.Success : AppTheme.Danger;
                _dgv.Rows[idx].DefaultCellStyle.ForeColor = renk;
            }

            _dgv.ClearSelection(); // Seçimi temizle
            _seciliId = -1;
            _btnOnayla.Enabled = false;
            _btnReddet.Enabled = false;
            _dgv.SelectionChanged += DgvSelectionChanged; // Eventi tekrar bağla
        }

        private void DgvSelectionChanged(object sender, EventArgs e)
        {
            if (_dgv.SelectedRows.Count == 0) return;
            _seciliId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
            string durum = _dgv.SelectedRows[0].Cells["Durum"].Value?.ToString() ?? "";
            bool bekliyor = durum.Contains("Bekliyor");
            _btnOnayla.Enabled = bekliyor;
            _btnReddet.Enabled = bekliyor;
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (_seciliId < 0) return;
            TalepDAL.DurumGuncelle(_seciliId, "Onaylandi");

            string tip   = _dgv.SelectedRows[0].Cells["Tip"].Value?.ToString() ?? "";
            int    rezId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["RezId"].Value);
            
            if (tip.Contains("İptal") || tip.Contains("İade") || tip.Contains("Iptal") || tip.Contains("İptal"))
            {
                var rez = RezervasyonDAL.Getir(rezId);
                if (rez != null && rez.Durum != "Iptal")
                {
                    RezervasyonDAL.DurumGuncelle(rezId, "Iptal");
                    KullaniciDAL.BakiyeYukle(rez.KullaniciId, rez.ToplamTutar);
                }
            }
            else
            {
                RezervasyonDAL.DurumGuncelle(rezId, "Onaylandi");
            }

            MessageBox.Show("Talep onaylandı.", "Başarılı",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            YukleVeriler(false);
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (_seciliId < 0) return;
            TalepDAL.DurumGuncelle(_seciliId, "Reddedildi");

            string tip   = _dgv.SelectedRows[0].Cells["Tip"].Value?.ToString() ?? "";
            int    rezId = Convert.ToInt32(_dgv.SelectedRows[0].Cells["RezId"].Value);
            // Talep reddedildiğinde, talep türü ne olursa olsun rezervasyon mevcut onaylı statüsüne döner
            RezervasyonDAL.DurumGuncelle(rezId, "Onaylandi");

            MessageBox.Show("Talep reddedildi.", "Reddedildi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            YukleVeriler(false);
        }
    }
}

