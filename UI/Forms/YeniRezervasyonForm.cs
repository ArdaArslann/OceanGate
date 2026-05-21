using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;
using oceangate_r.UI;
using oceangate_r.UI.Controls;

namespace oceangate_r
{
    /// <summary>
    /// Yeni rezervasyon oluşturma formu.
    /// Kullanıcı: Bölge → Sefer → Tarih → Kişi sayısı → Onayla adımlarını izler.
    /// </summary>
    public class YeniRezervasyonForm : Form
    {
        public event Action RezervasyonTamamlandi;

        // Adım panelleri
        private Panel _step1Panel;  // Bölge seçimi
        private Panel _step2Panel;  // Sefer seçimi
        private Panel _step3Panel;  // Tarih + kişi
        private Panel _step4Panel;  // Özet + onayla

        private Label _lblStepIndicator;

        // Seçilen değerler
        private Bolge  _seciliBolge;
        private Sefer  _seciliSefer;
        private DateTime _seferTarihi = DateTime.Today.AddDays(7);
        private int _kisiSayisi = 1;

        // Kontroller
        private ListBox  _lbBolgeler;
        private ListBox  _lbSeferler;
        private DateTimePicker _dtp;
        private NumericUpDown  _nudKisi;

        private const int FW = 1050, FH = 730;

        public YeniRezervasyonForm()
        {
            BackColor        = AppTheme.BgDark;
            ForeColor        = AppTheme.TextLight;
            Font             = AppTheme.BodyFont;
            FormBorderStyle  = FormBorderStyle.None;
            Size             = new Size(FW, FH);
            DoubleBuffered   = true;

            BuildUI();
            ShowStep(1);
        }

        private void BuildUI()
        {
            var lblTitle = UIHelper.MakeLabel("Yeni Rezervasyon", AppTheme.TitleFont,
                AppTheme.TextLight, 28, 22, 400, 36);
            Controls.Add(lblTitle);

            // Adım indikatörü
            _lblStepIndicator = UIHelper.MakeLabel("", AppTheme.BodyFont,
                AppTheme.TextMuted, 0, 22, FW, 36);
            _lblStepIndicator.TextAlign = ContentAlignment.MiddleRight;
            Controls.Add(_lblStepIndicator);

            // İlerleme çubuğu
            var progressBg = new Panel
            {
                Location  = new Point(28, 66),
                Size      = new Size(FW - 56, 4),
                BackColor = AppTheme.BgCard,
            };
            Controls.Add(progressBg);

            BuildStep1();
            BuildStep2();
            BuildStep3();
            BuildStep4();
        }

        // Adım 1: Bölge Seçimi 

        private void BuildStep1()
        {
            _step1Panel = new Panel
            {
                Location  = new Point(0, 88),
                Size      = new Size(FW, FH - 88),
                BackColor = Color.Transparent,
            };

            var lbl = UIHelper.MakeLabel("Hangi bölgeye gitmek istersiniz?",
                AppTheme.SubFont, AppTheme.TextLight, 28, 16, 600, 36);
            var sub = UIHelper.MakeLabel("Rotanızı seçerek başlayın",
                AppTheme.BodyFont, AppTheme.TextMuted, 28, 56, 400, 24);

            _lbBolgeler = new ListBox
            {
                Location     = new Point(28, 96),
                Size         = new Size(FW - 56, 420),
                BackColor    = AppTheme.BgMedium,
                ForeColor    = AppTheme.TextLight,
                Font         = AppTheme.BodyFont,
                BorderStyle  = BorderStyle.None,
                DrawMode     = DrawMode.OwnerDrawFixed,
                ItemHeight   = 64,
                SelectionMode= SelectionMode.One,
            };
            _lbBolgeler.DrawItem += BolgeListBox_DrawItem;

            var bolgeler = BolgeDAL.Listele(true);
            foreach (var b in bolgeler) _lbBolgeler.Items.Add(b);

            var btnIleri = UIHelper.MakeButton("İleri →", FW - 200, FH - 148, 164, 48);
            btnIleri.Click += (s, e) =>
            {
                if (_lbBolgeler.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir bölge seçiniz.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _seciliBolge = (Bolge)_lbBolgeler.SelectedItem;
                PopulateSeferler();
                ShowStep(2);
            };

            _step1Panel.Controls.AddRange(new Control[] { lbl, sub, _lbBolgeler, btnIleri });
            Controls.Add(_step1Panel);
        }

        private void BolgeListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var bolge = (Bolge)_lbBolgeler.Items[e.Index];
            bool sel  = (e.State & DrawItemState.Selected) != 0;

            e.Graphics.FillRectangle(
                new SolidBrush(sel ? AppTheme.AccentDark : (e.Index % 2 == 0 ? AppTheme.BgMedium : Color.FromArgb(36, 55, 80))),
                e.Bounds);

            if (sel)
            {
                using (var pen = new Pen(AppTheme.Accent, 2))
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Left, e.Bounds.Bottom);
            }

            // İkon + Ad
            e.Graphics.DrawString("", new Font("Segoe UI", 18f, FontStyle.Regular, GraphicsUnit.Point),
                new SolidBrush(AppTheme.Accent), new Point(e.Bounds.Left + 16, e.Bounds.Top + 12));
            e.Graphics.DrawString(bolge.Ad, AppTheme.BodyBold,
                new SolidBrush(AppTheme.TextLight), new Point(e.Bounds.Left + 56, e.Bounds.Top + 8));
            e.Graphics.DrawString($"Derinlik: {bolge.Derinlik} m  –  {bolge.Aciklama}", AppTheme.SmallFont,
                new SolidBrush(AppTheme.TextMuted), new Point(e.Bounds.Left + 56, e.Bounds.Top + 34));
        }

        // Adım 2: Sefer Seçimi 

        private void BuildStep2()
        {
            _step2Panel = new Panel
            {
                Location  = new Point(0, 88),
                Size      = new Size(FW, FH - 88),
                BackColor = Color.Transparent,
                Visible   = false,
            };

            var lbl = UIHelper.MakeLabel("Hangi sefere katılmak istersiniz?",
                AppTheme.SubFont, AppTheme.TextLight, 28, 16, 600, 36);

            _lbSeferler = new ListBox
            {
                Location    = new Point(28, 70),
                Size        = new Size(FW - 56, 440),
                BackColor   = AppTheme.BgMedium,
                ForeColor   = AppTheme.TextLight,
                Font        = AppTheme.BodyFont,
                BorderStyle = BorderStyle.None,
                DrawMode    = DrawMode.OwnerDrawFixed,
                ItemHeight  = 72,
            };
            _lbSeferler.DrawItem += SeferListBox_DrawItem;

            var btnGeri = UIHelper.MakeButton("← Geri", 28, FH - 148, 164, 48);
            btnGeri.SetMuted();
            btnGeri.Click += (s, e) => ShowStep(1);

            var btnIleri = UIHelper.MakeButton("İleri →", FW - 200, FH - 148, 164, 48);
            btnIleri.Click += (s, e) =>
            {
                if (_lbSeferler.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir sefer seçiniz.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _seciliSefer = (Sefer)_lbSeferler.SelectedItem;
                ShowStep(3);
            };

            _step2Panel.Controls.AddRange(new Control[] { lbl, _lbSeferler, btnGeri, btnIleri });
            Controls.Add(_step2Panel);
        }

        private void PopulateSeferler()
        {
            _lbSeferler.Items.Clear();
            var seferler = SeferDAL.BolgeninSefer(_seciliBolge.Id);
            foreach (var s in seferler) _lbSeferler.Items.Add(s);
        }

        private void SeferListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var sefer = (Sefer)_lbSeferler.Items[e.Index];
            bool sel  = (e.State & DrawItemState.Selected) != 0;

            e.Graphics.FillRectangle(
                new SolidBrush(sel ? AppTheme.AccentDark : (e.Index % 2 == 0 ? AppTheme.BgMedium : Color.FromArgb(36, 55, 80))),
                e.Bounds);

            if (sel)
            {
                using (var pen = new Pen(AppTheme.Accent, 2))
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Left, e.Bounds.Bottom);
            }

            e.Graphics.DrawString($"{sefer.KalkisSaati}", AppTheme.MedBold,
                new SolidBrush(AppTheme.Accent), new Point(e.Bounds.Left + 16, e.Bounds.Top + 8));
            e.Graphics.DrawString($"Süre: {sefer.SureMetni}   |   Kapasite: {sefer.KapasiteSayisi} kişi", AppTheme.SmallFont,
                new SolidBrush(AppTheme.TextMuted), new Point(e.Bounds.Left + 16, e.Bounds.Top + 34));
            e.Graphics.DrawString($"{sefer.FiyatKisiBasiTL:N0} TL / kişi", AppTheme.SubFont,
                new SolidBrush(AppTheme.Success), new RectangleF(e.Bounds.Right - 220, e.Bounds.Top + 16, 200, 40));
        }

        // Adım 3: Tarih + Kişi Sayısı 

        private void BuildStep3()
        {
            _step3Panel = new Panel
            {
                Location  = new Point(0, 88),
                Size      = new Size(FW, FH - 88),
                BackColor = Color.Transparent,
                Visible   = false,
            };

            var lbl = UIHelper.MakeLabel("Tarih ve Kişi Sayısı",
                AppTheme.SubFont, AppTheme.TextLight, 28, 16, 400, 36);

            // Tarih seçici
            var lblTarih = UIHelper.MakeLabel("Sefer Tarihi", AppTheme.BodyBold,
                AppTheme.TextMuted, 28, 74, 200, 24);

            _dtp = new DateTimePicker
            {
                Location       = new Point(28, 104),
                Size           = new Size(340, 36),
                MinDate        = DateTime.Today.AddDays(1),
                Value          = _seferTarihi,
                Format         = DateTimePickerFormat.Long,
                CalendarMonthBackground = AppTheme.BgCard,
                ForeColor      = AppTheme.TextLight,
                Font           = AppTheme.BodyFont,
            };

            // Kişi sayısı
            var lblKisi = UIHelper.MakeLabel("Kişi Sayısı", AppTheme.BodyBold,
                AppTheme.TextMuted, 28, 162, 200, 24);

            _nudKisi = new NumericUpDown
            {
                Location   = new Point(28, 192),
                Size       = new Size(120, 36),
                Minimum    = 1,
                Maximum    = 20,
                Value      = 1,
                Font       = AppTheme.SubFont,
                BackColor  = AppTheme.BgCard,
                ForeColor  = AppTheme.TextLight,
                BorderStyle= BorderStyle.FixedSingle,
            };

            var btnGeri = UIHelper.MakeButton("← Geri", 28, FH - 148, 164, 48);
            btnGeri.SetMuted();
            btnGeri.Click += (s, e) => ShowStep(2);

            var btnIleri = UIHelper.MakeButton("Özete Git →", FW - 200, FH - 148, 164, 48);
            btnIleri.Click += (s, e) =>
            {
                _seferTarihi = _dtp.Value.Date;
                _kisiSayisi  = (int)_nudKisi.Value;
                UpdateStep4Summary();
                ShowStep(4);
            };

            _step3Panel.Controls.AddRange(new Control[]
            {
                lbl, lblTarih, _dtp, lblKisi, _nudKisi, btnGeri, btnIleri,
            });
            Controls.Add(_step3Panel);
        }

        // Adım 4: Özet + Onayla 

        private Panel   _summaryCard;
        private Label[] _summaryLabels = new Label[10];

        private void BuildStep4()
        {
            _step4Panel = new Panel
            {
                Location  = new Point(0, 88),
                Size      = new Size(FW, FH - 88),
                BackColor = Color.Transparent,
                Visible   = false,
            };

            var lbl = UIHelper.MakeLabel("Rezervasyon Özeti",
                AppTheme.SubFont, AppTheme.TextLight, 28, 16, 400, 36);

            _summaryCard = UIHelper.MakeCard(28, 66, 640, 380, AppTheme.BgCard);

            string[] keys = { "Bölge:", "Sefer:", "Kalkış Saati:", "Süre:", "Sefer Tarihi:",
                               "Kişi Sayısı:", "Birim Fiyat:", "Toplam Tutar:" };
            int ky = 20;
            for (int i = 0; i < keys.Length; i++)
            {
                var lKey = UIHelper.MakeLabel(keys[i], AppTheme.BodyFont, AppTheme.TextMuted,
                    20, ky, 180, 28);
                _summaryCard.Controls.Add(lKey);
                _summaryLabels[i] = UIHelper.MakeLabel("—", AppTheme.BodyBold, AppTheme.TextLight,
                    210, ky, 400, 28);
                _summaryCard.Controls.Add(_summaryLabels[i]);
                ky += 40;
            }
            // Son satır: Toplam büyük yazı
            _summaryLabels[7].Font      = AppTheme.TitleFont;
            _summaryLabels[7].ForeColor = AppTheme.Accent;

            var btnGeri = UIHelper.MakeButton("← Geri", 28, FH - 148, 164, 48);
            btnGeri.SetMuted();
            btnGeri.Click += (s, e) => ShowStep(3);

            var btnOnayla = UIHelper.MakeButton("Rezervasyonu Onayla", FW - 320, FH - 148, 284, 48);
            btnOnayla.SetSuccess();
            btnOnayla.Click += BtnOnayla_Click;

            _step4Panel.Controls.AddRange(new Control[]
            {
                lbl, _summaryCard, btnGeri, btnOnayla,
            });
            Controls.Add(_step4Panel);
        }

        private void UpdateStep4Summary()
        {
            if (_seciliBolge == null || _seciliSefer == null) return;
            double toplam = _seciliSefer.FiyatKisiBasiTL * _kisiSayisi;

            _summaryLabels[0].Text = _seciliBolge.Ad;
            _summaryLabels[1].Text = _seciliBolge.Ad;
            _summaryLabels[2].Text = _seciliSefer.KalkisSaati;
            _summaryLabels[3].Text = _seciliSefer.SureMetni;
            _summaryLabels[4].Text = _seferTarihi.ToString("dd MMMM yyyy dddd",
                new System.Globalization.CultureInfo("tr-TR"));
            _summaryLabels[5].Text = $"{_kisiSayisi} kişi";
            _summaryLabels[6].Text = $"{_seciliSefer.FiyatKisiBasiTL:N0} TL / kişi";
            _summaryLabels[7].Text = $"{toplam:N0} TL";
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            double toplam = _seciliSefer.FiyatKisiBasiTL * _kisiSayisi;
            string dekontNo = DatabaseManager.YeniDekontNo();

            var rez = new Rezervasyon
            {
                KullaniciId       = SessionManager.AktifKullanici.Id,
                SeferId           = _seciliSefer.Id,
                KisiSayisi        = _kisiSayisi,
                ToplamTutar       = toplam,
                RezervasyonTarihi = DateTime.Now,
                SeferTarihi       = _seferTarihi,
                Durum             = "Onaylandi",
                DekontNo          = dekontNo,
                SeferBilgisi      = $"{_seciliBolge.Ad} – {_seciliSefer.KalkisSaati}",
                KullaniciAdi      = SessionManager.AktifKullanici.KullaniciAdi,
            };

            RezervasyonDAL.Ekle(rez);

            // Dekont göster (uygulama KAPANMAZ)
            using (var dekont = new DekontForm(rez))
                dekont.ShowDialog(this);

            // Tamamlandı eventi
            RezervasyonTamamlandi?.Invoke();
        }

        // Adım geçişi 

        private void ShowStep(int step)
        {
            _step1Panel.Visible = step == 1;
            _step2Panel.Visible = step == 2;
            _step3Panel.Visible = step == 3;
            _step4Panel.Visible = step == 4;
            _lblStepIndicator.Text = $"Adım {step} / 4   ";
        }
    }
}
