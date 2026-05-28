using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using oceangate_r.DAL;
using oceangate_r.Entities;

namespace oceangate_r.UI.Forms
{

    public partial class OtelOdaSecimPanel : System.Windows.Forms.UserControl
    {
        private static readonly Color RenkBos        = Color.FromArgb(51,  65,  85);
        private static readonly Color RenkBosAktif   = Color.FromArgb(30,  100, 160);
        private static readonly Color RenkDolu       = Color.FromArgb(80,  80,  80);
        private static readonly Color RenkSecili     = Color.FromArgb(16,  185, 129);
        private static readonly Color RenkKilitli    = Color.FromArgb(25,  32,  44);  // seçilemez (taşar)
        private static readonly Color RenkKilitliTxt = Color.FromArgb(50,  58,  70);

        private List<OtelOda> _odalar       = new List<OtelOda>();
        private List<OtelOda> _seciliOdalar = new List<OtelOda>();
        private int           _kisiSayisi   = 1;
        private int           _seferId      = 0;
        private DateTime      _seferTarihi  = DateTime.Today;

        private readonly List<(Button Btn, OtelOda Oda)> _tumBtnler = new List<(Button, OtelOda)>();

        private Label _lblDurum;

        public event Action<List<OtelOda>> SecimDegisti;
        public List<OtelOda> SeciliOdalar => _seciliOdalar;

        public OtelOdaSecimPanel()
        {
            InitializeComponent();
        }

        public void Baslat(int kisiSayisi, int seferId, DateTime seferTarihi)
        {
            _kisiSayisi  = kisiSayisi;
            _seferId     = seferId;
            _seferTarihi = seferTarihi;
            _seciliOdalar.Clear();
            _tumBtnler.Clear();

            Controls.Clear();
            _odalar = OtelOdaDAL.TumOdalariGetir(_seferId, _seferTarihi);

            BuildUI();
            GuncelleKisitlamalar();  
        }

        private void BuildUI()
        {
            int y = 8;

            _lblDurum = new Label
            {
                Text      = "",
                Location  = new Point(20, y),
                Size      = new Size(Width - 40, 24),
                ForeColor = AppTheme.Accent,
                Font      = AppTheme.BodyBold,
                BackColor = Color.Transparent,
            };
            Controls.Add(_lblDurum);
            y += 30;

            BuildLejant(y);
            y += 30;

            foreach (int kap in new[] { 1, 2, 3, 4 })
            {
                var grup = _odalar.Where(o => o.Kapasite == kap).ToList();
                if (grup.Count == 0) continue;

                var lblGrup = new Label
                {
                    Text      = $"{kap} Kişilik Odalar",
                    Location  = new Point(20, y),
                    Size      = new Size(220, 22),
                    ForeColor = AppTheme.TextMuted,
                    Font      = AppTheme.BodyBold,
                    BackColor = Color.Transparent,
                    Tag       = $"grup{kap}",  // Enabled güncellemesi için Tag
                };
                Controls.Add(lblGrup);
                y += 26;

                var flow = new FlowLayoutPanel
                {
                    Location      = new Point(20, y),
                    Size          = new Size(Width - 44, 72),
                    BackColor     = Color.Transparent,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents  = true,
                    AutoSize      = false,
                };

                foreach (var oda in grup)
                {
                    var btn = new Button
                    {
                        Text      = $"Oda {oda.OdaNo}\n{oda.Kapasite} Kişilik",
                        Size      = new Size(90, 60),
                        FlatStyle = FlatStyle.Flat,
                        Font      = AppTheme.SmallFont,
                        Cursor    = Cursors.Hand,
                        Tag       = oda,
                        Margin    = new Padding(0, 0, 8, 8),
                    };
                    btn.FlatAppearance.BorderSize = 0;

                    if (oda.Durum == OdaDurum.Dolu)
                    {
                        btn.BackColor = RenkDolu;
                        btn.ForeColor = AppTheme.TextDim;
                        btn.Enabled   = false;
                        btn.Cursor    = Cursors.Default;
                    }
                    else
                    {
                        btn.BackColor = RenkBos;
                        btn.ForeColor = AppTheme.TextLight;
                        btn.FlatAppearance.MouseOverBackColor = RenkBosAktif;

                        var localOda = oda;
                        var localBtn = btn;

                        btn.Click += (s, e) =>
                        {
                            if (_seciliOdalar.Any(o => o.Id == localOda.Id))
                            {
                                _seciliOdalar.RemoveAll(o => o.Id == localOda.Id);
                                localBtn.BackColor = RenkBos;
                                localBtn.FlatAppearance.MouseOverBackColor = RenkBosAktif;
                            }
                            else
                            {
                                _seciliOdalar.Add(localOda);
                                localBtn.BackColor = RenkSecili;
                                localBtn.FlatAppearance.MouseOverBackColor = RenkSecili;
                            }

                            GuncelleKisitlamalar();
                            SecimDegisti?.Invoke(_seciliOdalar);
                        };

                        _tumBtnler.Add((btn, oda));
                    }

                    flow.Controls.Add(btn);
                }

                Controls.Add(flow);
                y += 82;
            }
        }

    
        private void GuncelleKisitlamalar()
        {
            int toplamSecili = _seciliOdalar.Sum(o => o.Kapasite);
            int kalan        = _kisiSayisi - toplamSecili;

        
            // Kalan kişi için kapasiteli <= boş oda
            bool uygunBosOdaVar = _tumBtnler.Any(x =>
                !_seciliOdalar.Any(s => s.Id == x.Oda.Id) &&   
                x.Oda.Kapasite <= kalan);                       

            int acilacakMinKap = int.MaxValue;
            if (kalan > 0 && !uygunBosOdaVar)
            {
                foreach (var (b, o) in _tumBtnler)
                    if (!_seciliOdalar.Any(s => s.Id == o.Id) && o.Kapasite < acilacakMinKap)
                        acilacakMinKap = o.Kapasite;
            }

            if (kalan == 0)
                _lblDurum.Text = $"✓  Tüm yolcular için oda seçildi! ({_kisiSayisi}/{_kisiSayisi} kişi)";
            else if (!uygunBosOdaVar && acilacakMinKap < int.MaxValue)
                _lblDurum.Text = $"Kalan: {kalan} kişi  —  Tam kapasiteli oda kalmadı, en küçük mevcut oda ({acilacakMinKap}K) seçebilirsiniz";
            else
                _lblDurum.Text = $"Seçildi: {toplamSecili}/{_kisiSayisi} kişilik  —  Kalan: {kalan} kişi için oda seçiniz";
            _lblDurum.ForeColor = kalan == 0 ? AppTheme.Success
                                : (!uygunBosOdaVar && acilacakMinKap < int.MaxValue) ? AppTheme.Warning
                                : AppTheme.Accent;

            foreach (var (btn, oda) in _tumBtnler)
            {
                bool secilidirZaten = _seciliOdalar.Any(o => o.Id == oda.Id);

                if (secilidirZaten)
                {
                    // Seçili odalar kendi seçimini iptal edebilmeli → her zaman aktif
                    btn.Enabled   = true;
                    btn.BackColor = RenkSecili;
                    btn.FlatAppearance.MouseOverBackColor = RenkSecili;
                    btn.ForeColor = AppTheme.TextLight;
                    btn.Cursor    = Cursors.Hand;
                }
                else if (kalan == 0)
                {
                    // Tamamlandı — yeni seçim yasak
                    btn.Enabled   = false;
                    btn.BackColor = RenkKilitli;
                    btn.ForeColor = RenkKilitliTxt;
                    btn.Cursor    = Cursors.Default;
                    btn.FlatAppearance.MouseOverBackColor = RenkKilitli;
                }
                else if (uygunBosOdaVar)
                {
                    // Normal senaryo: kapasitesi ≤ kalan olan odalar açık
                    if (oda.Kapasite <= kalan)
                    {
                        btn.Enabled   = true;
                        btn.BackColor = RenkBos;
                        btn.ForeColor = AppTheme.TextLight;
                        btn.Cursor    = Cursors.Hand;
                        btn.FlatAppearance.MouseOverBackColor = RenkBosAktif;
                    }
                    else
                    {
                        btn.Enabled   = false;
                        btn.BackColor = RenkKilitli;
                        btn.ForeColor = RenkKilitliTxt;
                        btn.Cursor    = Cursors.Default;
                        btn.FlatAppearance.MouseOverBackColor = RenkKilitli;
                    }
                }
                else
                {
                    
                    if (oda.Kapasite == acilacakMinKap)
                    {
                        btn.Enabled   = true;
                        btn.BackColor = RenkBos;
                        btn.ForeColor = AppTheme.TextLight;
                        btn.Cursor    = Cursors.Hand;
                        btn.FlatAppearance.MouseOverBackColor = RenkBosAktif;
                    }
                    else
                    {
                        btn.Enabled   = false;
                        btn.BackColor = RenkKilitli;
                        btn.ForeColor = RenkKilitliTxt;
                        btn.Cursor    = Cursors.Default;
                        btn.FlatAppearance.MouseOverBackColor = RenkKilitli;
                    }
                }
            }

            foreach (Control c in Controls)
            {
                if (c is Label lbl && lbl.Tag is string tag && tag.StartsWith("grup"))
                {
                    if (int.TryParse(tag.Replace("grup", ""), out int grupKap))
                    {
                        bool secilecek;
                        if (uygunBosOdaVar)
                            secilecek = kalan > 0 && grupKap <= kalan;
                        else
                            secilecek = kalan > 0 && grupKap == acilacakMinKap;
                        lbl.ForeColor = secilecek ? AppTheme.Warning : AppTheme.TextDim;
                    }
                }
            }
        }

        private void BuildLejant(int y)
        {
            var durumlar = new (Color Renk, string Ad)[]
            {
                (RenkBos,     "Seçilebilir"),
                (RenkDolu,    "Rezerve (Dolu)"),
                (RenkSecili,  "Seçildi"),
                (RenkKilitli, "Sığmaz / Tamamlandı"),
            };

            int ix = 20;
            foreach (var (renk, ad) in durumlar)
            {
                var kutu = new Panel
                {
                    Location  = new Point(ix, y + 3),
                    Size      = new Size(14, 14),
                    BackColor = renk,
                };
                var lbl = new Label
                {
                    Text      = ad,
                    Location  = new Point(ix + 18, y),
                    Size      = new Size(120, 20),
                    ForeColor = AppTheme.TextMuted,
                    Font      = AppTheme.SmallFont,
                    BackColor = Color.Transparent,
                };
                Controls.Add(kutu);
                Controls.Add(lbl);
                ix += 138;
            }
        }

        private void _lSecili_Click(object sender, EventArgs e)
        {

        }
    }
}
