using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;

namespace oceangate_r.UI.Forms
{
    /// <summary>
    /// Denizaltı Koltuk Seçim Paneli – 1+1 yatay düzen.
    ///
    /// Görsel düzen (soldan sağa):
    ///   Üst sıra : koltuk 1, 3, 5, 7 … (tek numaralar)
    ///   ─── KORİDOR ───────────────────────────────────────
    ///   Alt sıra : koltuk 2, 4, 6, 8 … (çift numaralar)
    ///
    /// Koltuklar soldan sağa sütun sütun ilerler.
    /// </summary>
    public class KoltukSecimPanel : Panel
    {
        // ── Renk Paleti ──────────────────────────────────────────────────────
        private static readonly Color RenkBos       = Color.FromArgb(51,  65,  85);
        private static readonly Color RenkDoluKadin = Color.FromArgb(236, 72,  153);
        private static readonly Color RenkDoluErkek = Color.FromArgb(59,  130, 246);
        private static readonly Color RenkSecili    = Color.FromArgb(16,  185, 129);
        private static readonly Color RenkHover     = Color.FromArgb(245, 158, 11);

        // ── Durum Listesi ────────────────────────────────────────────────────
        private readonly List<Koltuk> _koltuklar   = new List<Koltuk>();
        private readonly List<Button> _koltukBtnlr = new List<Button>();
        private readonly List<int> _buOturumSecilen = new List<int>();

        // ── Dışarıya bildirim ──────────────────────────────────────────
        public event Action<List<Koltuk>> SecimDegisti;

        // ── Seçili koltukları dışarıya ver (UI için) ─────────────────────────
        public List<Koltuk> SeciliKoltuklar =>
            _koltuklar.Where(k => k.Durum == KoltukDurum.DoluKadin ||
                                  k.Durum == KoltukDurum.DoluErkek).ToList();

        // ── KoltukAtama listesi (kayıt için) ──────────────────────────────────
        public List<KoltukAtama> SeciliAtamalar =>
            _koltuklar
                .Where(k => k.Durum == KoltukDurum.DoluKadin || k.Durum == KoltukDurum.DoluErkek)
                .Select(k => new KoltukAtama
                {
                    KoltukNo = k.No,
                    Cinsiyet = k.Durum == KoltukDurum.DoluKadin ? "Kadin" : "Erkek"
                }).ToList();

        // ── Boyut sabitleri ──────────────────────────────────────────────────
        private const int BtnW      = 46;   // koltuk genişliği
        private const int BtnH      = 42;   // koltuk yüksekliği
        private const int HGap      = 10;   // koltuklar arası yatay boşluk
        private const int VGap      = 10;   // sıra arası dikey boşluk
        private const int KoridorH  = 30;   // koridor yüksekliği
        private const int LejantH   = 32;   // lejant alanı yüksekliği
        private const int PadX      = 20;
        private const int PadY      = 16;

        public KoltukSecimPanel()
        {
            BackColor  = AppTheme.BgDark;
            AutoScroll = true;
            // DoubleBuffered'ı reflection ile aç (protected)
            typeof(Panel)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(this, true, null);
        }

        // ── Başlat ───────────────────────────────────────────────────────────
        public void Baslat(int kapasite, List<Koltuk> mevcutDurumlar = null)
        {
            Controls.Clear();
            _koltuklar.Clear();
            _koltukBtnlr.Clear();

            kapasite = Math.Max(1, Math.Min(kapasite, 60));

            for (int i = 1; i <= kapasite; i++)
            {
                var k = new Koltuk { No = i, Durum = KoltukDurum.Bos };
                // Mevcut dolu koltuklar varsa uygula
                if (mevcutDurumlar != null)
                {
                    var m = mevcutDurumlar.Find(x => x.No == i);
                    if (m != null) k.Durum = m.Durum;
                }
                _koltuklar.Add(k);
            }

            BuildLejant();
            BuildKoltuklar(kapasite);
        }

        // ── Lejant ───────────────────────────────────────────────────────────
        private void BuildLejant()
        {
            var lblLejant = new Label
            {
                Text      = "Koltuk Durumu:",
                Location  = new Point(PadX, PadY),
                Size      = new Size(130, 22),
                ForeColor = AppTheme.TextMuted,
                Font      = AppTheme.SmallBold,
                BackColor = Color.Transparent,
            };
            Controls.Add(lblLejant);

            var durumlar = new (Color Renk, string Ad)[]
            {
                (RenkBos,       "Bos"),
                (RenkDoluKadin, "Dolu – Bayan"),
                (RenkDoluErkek, "Dolu – Bay"),
                (RenkSecili,    "Secildi"),
            };

            int ix = PadX + 136;
            foreach (var (renk, ad) in durumlar)
            {
                var kutu = new Panel
                {
                    Location  = new Point(ix, PadY + 2),
                    Size      = new Size(18, 18),
                    BackColor = renk,
                };
                var lbl = new Label
                {
                    Text      = ad,
                    Location  = new Point(ix + 22, PadY),
                    Size      = new Size(96, 22),
                    ForeColor = AppTheme.TextMuted,
                    Font      = AppTheme.SmallFont,
                    BackColor = Color.Transparent,
                };
                Controls.Add(kutu);
                Controls.Add(lbl);
                ix += 122;
            }
        }

        // ── Koltuk Düzeni – 1+1 yatay ────────────────────────────────────────
        //
        //  Üst sıra : koltuk 1, 3, 5, 7 … (indeks=0,2,4…  → No=1,3,5…)
        //  Koridor
        //  Alt sıra : koltuk 2, 4, 6, 8 … (indeks=1,3,5…  → No=2,4,6…)
        //
        private void BuildKoltuklar(int kapasite)
        {
            // Koltukları iki gruba ayır
            var ustSira = _koltuklar.Where(k => k.No % 2 == 1).ToList();  // 1,3,5,7…
            var altSira = _koltuklar.Where(k => k.No % 2 == 0).ToList();  // 2,4,6,8…

            int startY   = PadY + LejantH + 8;
            int ustSiraY = startY;
            int altSiraY = startY + BtnH + VGap + KoridorH;

            // Koridor etiketi
            int koridorY = startY + BtnH + VGap / 2 + 2;
            var lblKoridor = new Label
            {
                Text      = "─── KORİDOR ───────────────────────────────────────────────────────",
                Location  = new Point(PadX, koridorY),
                Size      = new Size(Width - PadX * 2, KoridorH - 4),
                ForeColor = Color.FromArgb(51, 65, 85),
                Font      = AppTheme.SmallFont,
                BackColor = Color.Transparent,
            };
            Controls.Add(lblKoridor);

            // Üst sıra
            for (int col = 0; col < ustSira.Count; col++)
            {
                int bx = PadX + col * (BtnW + HGap);
                AnaKoltukBtn(ustSira[col], bx, ustSiraY);
            }

            // Alt sıra
            for (int col = 0; col < altSira.Count; col++)
            {
                int bx = PadX + col * (BtnW + HGap);
                AnaKoltukBtn(altSira[col], bx, altSiraY);
            }
        }

        // ── Tekil Koltuk Butonu ───────────────────────────────────────────────
        private void AnaKoltukBtn(Koltuk koltuk, int x, int y)
        {
            var btn = new Button
            {
                Text      = koltuk.No.ToString(),
                Location  = new Point(x, y),
                Size      = new Size(BtnW, BtnH),
                BackColor = DurumRengi(koltuk.Durum),
                ForeColor = AppTheme.TextLight,
                FlatStyle = FlatStyle.Flat,
                Font      = AppTheme.SmallBold,
                Cursor    = koltuk.Durum == KoltukDurum.Bos ? Cursors.Hand : Cursors.Default,
                Tag       = koltuk,
            };
            btn.FlatAppearance.BorderSize         = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;

            btn.MouseEnter += (s, e) =>
            {
                var b = (Button)s; var k = (Koltuk)b.Tag;
                if (k.Durum == KoltukDurum.Bos) b.BackColor = RenkHover;
            };
            btn.MouseLeave += (s, e) =>
            {
                var b = (Button)s; var k = (Koltuk)b.Tag;
                b.BackColor = DurumRengi(k.Durum);
            };
            btn.Click += KoltukBtn_Click;

            _koltukBtnlr.Add(btn);
            Controls.Add(btn);
        }

        // ── Tıklama Handler ───────────────────────────────────────────────────
        private void KoltukBtn_Click(object sender, EventArgs e)
        {
            var btn    = (Button)sender;
            var koltuk = (Koltuk)btn.Tag;

            // Veritabanından gelen dolu koltuk → tıklanamaz
            if ((koltuk.Durum == KoltukDurum.DoluKadin || koltuk.Durum == KoltukDurum.DoluErkek)
                && !_buOturumSecilen.Contains(koltuk.No))
                return;

            // Bu oturumda seçilmiş → seçimi kaldır
            if ((koltuk.Durum == KoltukDurum.DoluKadin || koltuk.Durum == KoltukDurum.DoluErkek)
                && _buOturumSecilen.Contains(koltuk.No))
            {
                _buOturumSecilen.Remove(koltuk.No);
                koltuk.Durum  = KoltukDurum.Bos;
                btn.BackColor = RenkBos;
                btn.Cursor    = Cursors.Hand;
                SecimDegisti?.Invoke(SeciliKoltuklar);
                return;
            }

            // Boş koltuk → cinsiyet seçimi
            using (var dialog = new CinsiyetSecimForm(koltuk.No))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK || dialog.SecilenCinsiyet == null)
                    return;

                // Cinsiyete göre gerçek durumu ata
                koltuk.Durum  = dialog.SecilenCinsiyet.Value; // DoluKadin veya DoluErkek
                _buOturumSecilen.Add(koltuk.No);
                btn.BackColor = DurumRengi(koltuk.Durum);
                btn.Cursor    = Cursors.Default;
            }

            SecimDegisti?.Invoke(SeciliKoltuklar);
        }

        // ── Durum → Renk ──────────────────────────────────────────────────────
        public static Color DurumRengi(KoltukDurum durum)
        {
            switch (durum)
            {
                case KoltukDurum.DoluKadin: return RenkDoluKadin;
                case KoltukDurum.DoluErkek: return RenkDoluErkek;
                case KoltukDurum.Secili:    return RenkSecili;
                default:                    return RenkBos;
            }
        }

        public void SecimleriTemizle()
        {
            foreach (var no in _buOturumSecilen)
            {
                var k = _koltuklar.Find(x => x.No == no);
                if (k != null) k.Durum = KoltukDurum.Bos;
            }
            _buOturumSecilen.Clear();
            foreach (var btn in _koltukBtnlr)
            {
                var k = (Koltuk)btn.Tag;
                btn.BackColor = DurumRengi(k.Durum);
                btn.Cursor    = k.Durum == KoltukDurum.Bos ? Cursors.Hand : Cursors.Default;
            }
            SecimDegisti?.Invoke(SeciliKoltuklar);
        }
    }
}
