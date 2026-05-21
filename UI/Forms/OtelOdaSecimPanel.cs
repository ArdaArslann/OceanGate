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
    /// CODER PHASE – Otel Odası Seçim Paneli.
    ///
    /// ARCHITECT KARARLARI:
    ///   - kisiSayisi dışarıdan gelir; yalnızca kapasitesi == kisiSayisi olan odalar aktif.
    ///   - Odalar FlowLayoutPanel ile dinamik oluşturulur (gruplar halinde: 1K, 2K, 3K, 4K).
    ///   - Dolu odalar kilitli (disabled + gri), uyumsuz kapasite soluk gösterilir.
    ///   - Seçim değiştiğinde SecimDegisti event'i tetiklenir.
    ///
    /// REVIEWER KONTROLLERI:
    ///   ✓ Harici kütüphane yok.
    ///   ✓ Kapasite uyumsuzluğu: Enabled=false + soluk renk.
    ///   ✓ Dolu odalar tamamen kilitli (farklı renk ve Enabled=false).
    ///   ✓ Tekli seçim: Önceki seçimi temizler.
    ///   ✓ "Oda İstemiyorum" seçeneği mevcut.
    /// </summary>
    public class OtelOdaSecimPanel : Panel
    {
        // ── Renkler ──────────────────────────────────────────────────────────
        private static readonly Color RenkBos          = Color.FromArgb(51,  65,  85);
        private static readonly Color RenkBosAktif     = Color.FromArgb(30,  100, 160); // hover rengi
        private static readonly Color RenkDolu         = Color.FromArgb(80,  80,  80);
        private static readonly Color RenkSecili       = Color.FromArgb(16,  185, 129);
        private static readonly Color RenkUyumsuz      = Color.FromArgb(35,  45,  60);
        private static readonly Color RenkUyumsuzText  = Color.FromArgb(70,  80,  95);

        // ── State ─────────────────────────────────────────────────────────────
        private List<OtelOda> _odalar = new List<OtelOda>();
        private OtelOda       _seciliOda = null;   // null = oda istemiyorum
        private int           _kisiSayisi = 1;
        private bool          _odaIstemiyor = false;

        // ── Event ─────────────────────────────────────────────────────────────
        public event Action<OtelOda> SecimDegisti;   // null = oda istemiyorum

        public OtelOda    SeciliOda       => _seciliOda;
        public bool       OdaIstemiyorum  => _odaIstemiyor;

        public OtelOdaSecimPanel()
        {
            BackColor  = AppTheme.BgDark;
            AutoScroll = true;
            typeof(Panel)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(this, true, null);
        }

        // ── Başlat ───────────────────────────────────────────────────────────
        public void Baslat(int kisiSayisi)
        {
            _kisiSayisi   = kisiSayisi;
            _seciliOda    = null;
            _odaIstemiyor = false;

            Controls.Clear();
            _odalar = OtelOdaDAL.TumOdalariGetir();

            BuildUI();
        }

        // ── UI İnşası ─────────────────────────────────────────────────────────
        private void BuildUI()
        {
            int y = 16;

            // Başlık
            var lblBaslik = new Label
            {
                Text      = $"Otel Odası Seçimi  ({_kisiSayisi} kişilik odalar aktif)",
                Location  = new Point(20, y),
                Size      = new Size(Width - 40, 28),
                ForeColor = AppTheme.TextLight,
                Font      = AppTheme.SubFont,
                BackColor = Color.Transparent,
            };
            Controls.Add(lblBaslik);
            y += 36;

            // Lejant
            BuildLejant(y);
            y += 32;

            // "Oda İstemiyorum" butonu
            var btnAtla = new Button
            {
                Text      = "Oda rezervasyonu istemiyorum",
                Location  = new Point(20, y),
                Size      = new Size(260, 36),
                BackColor = AppTheme.BgCard,
                ForeColor = AppTheme.TextMuted,
                FlatStyle = FlatStyle.Flat,
                Font      = AppTheme.BodyFont,
                Cursor    = Cursors.Hand,
                Tag       = "atla",
            };
            btnAtla.FlatAppearance.BorderSize = 0;
            btnAtla.Click += (s, e) =>
            {
                _seciliOda    = null;
                _odaIstemiyor = true;
                SecimDegisti?.Invoke(null);
                // Seçili butonu vurgula
                foreach (Control c in Controls)
                    if (c is Button b && b.Tag?.ToString() == "atla")
                        b.BackColor = AppTheme.BgCardHov;
                    else if (c is Button b2 && b2.Tag is OtelOda)
                        b2.BackColor = RenkBos;
            };
            Controls.Add(btnAtla);
            y += 52;

            // Kapasiteye göre grupla ve göster
            var gruplar = new[] { 1, 2, 3, 4 };
            foreach (int kap in gruplar)
            {
                var odaGrubu = _odalar.Where(o => o.Kapasite == kap).ToList();
                if (odaGrubu.Count == 0) continue;

                bool gruplaAktif = (kap == _kisiSayisi);

                // Grup başlığı
                var lblGrup = new Label
                {
                    Text      = $"{kap} Kişilik Odalar",
                    Location  = new Point(20, y),
                    Size      = new Size(200, 22),
                    ForeColor = gruplaAktif ? AppTheme.Accent : AppTheme.TextDim,
                    Font      = AppTheme.BodyBold,
                    BackColor = Color.Transparent,
                };
                Controls.Add(lblGrup);
                y += 28;

                // Odaları FlowLayoutPanel içinde göster
                var flow = new FlowLayoutPanel
                {
                    Location        = new Point(20, y),
                    Size            = new Size(Width - 44, 76),
                    BackColor       = Color.Transparent,
                    FlowDirection   = FlowDirection.LeftToRight,
                    WrapContents    = true,
                    AutoSize        = false,
                };

                foreach (var oda in odaGrubu)
                {
                    bool aktif = gruplaAktif && oda.Durum == OdaDurum.Bos;
                    var btn   = BuildOdaBtn(oda, aktif);
                    flow.Controls.Add(btn);
                }
                Controls.Add(flow);
                y += 86;
            }
        }

        private void BuildLejant(int y)
        {
            var durumlar = new (Color Renk, string Ad)[]
            {
                (RenkBos,       "Seçilebilir"),
                (RenkDolu,      "Dolu"),
                (RenkUyumsuz,   "Uyumsuz Kapasite"),
                (RenkSecili,    "Seçildi"),
            };

            int ix = 20;
            foreach (var (renk, ad) in durumlar)
            {
                var kutu = new Panel { Location = new Point(ix, y + 2), Size = new Size(16, 16), BackColor = renk };
                var lbl  = new Label
                {
                    Text = ad, Location = new Point(ix + 20, y), Size = new Size(108, 22),
                    ForeColor = AppTheme.TextMuted, Font = AppTheme.SmallFont, BackColor = Color.Transparent,
                };
                Controls.Add(kutu);
                Controls.Add(lbl);
                ix += 130;
            }
        }

        private Button BuildOdaBtn(OtelOda oda, bool aktif)
        {
            Color bgRenk;
            Color fgRenk = AppTheme.TextLight;

            if (!aktif && oda.Durum == OdaDurum.Dolu)
            {
                bgRenk = RenkDolu;
                fgRenk = AppTheme.TextDim;
            }
            else if (!aktif)
            {
                bgRenk = RenkUyumsuz;
                fgRenk = RenkUyumsuzText;
            }
            else
            {
                bgRenk = RenkBos;
            }

            var btn = new Button
            {
                Text      = $"Oda {oda.OdaNo}\n{oda.Kapasite} Kişilik",
                Size      = new Size(90, 60),
                BackColor = bgRenk,
                ForeColor = fgRenk,
                FlatStyle = FlatStyle.Flat,
                Font      = AppTheme.SmallFont,
                Enabled   = aktif,
                Cursor    = aktif ? Cursors.Hand : Cursors.Default,
                Tag       = oda,
                Margin    = new Padding(0, 0, 8, 8),
            };
            btn.FlatAppearance.BorderSize         = 0;
            btn.FlatAppearance.MouseOverBackColor = aktif ? RenkBosAktif : bgRenk;

            if (aktif)
            {
                btn.Click += (s, e) =>
                {
                    // Önceki seçimi temizle
                    foreach (Control c in Parent?.Controls ?? new Control.ControlCollection(null))
                        if (c is FlowLayoutPanel fp)
                            foreach (Control fc in fp.Controls)
                                if (fc is Button fb && fb.Tag is OtelOda)
                                    fb.BackColor = RenkBos;

                    // Kendi panelindeki tüm butonları temizle
                    TumOdaBtnRenkSifirla();

                    _seciliOda    = oda;
                    _odaIstemiyor = false;
                    btn.BackColor = RenkSecili;
                    SecimDegisti?.Invoke(oda);
                };
            }

            return btn;
        }

        private void TumOdaBtnRenkSifirla()
        {
            foreach (Control c in Controls)
            {
                if (c is FlowLayoutPanel fp)
                {
                    foreach (Control fc in fp.Controls)
                    {
                        if (fc is Button fb && fb.Tag is OtelOda o && fb.Enabled)
                            fb.BackColor = RenkBos;
                    }
                }
                // "atla" butonu
                if (c is Button b && b.Tag?.ToString() == "atla")
                    b.BackColor = AppTheme.BgCard;
            }
        }
    }
}
