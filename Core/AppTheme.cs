using System.Drawing;

namespace oceangate_r
{
    /// <summary>
    /// Uygulamanın tüm renk, font ve stil sabitlerini barındıran merkezi tema sınıfı.
    /// </summary>
    public static class AppTheme
    {
        // ── Arka Plan Renkleri ──────────────────────────────────────────────
        public static readonly Color BgDark     = ColorTranslator.FromHtml("#0F172A");
        public static readonly Color BgSidebar  = ColorTranslator.FromHtml("#0C1526");
        public static readonly Color BgMedium   = ColorTranslator.FromHtml("#1E293B");
        public static readonly Color BgCard     = ColorTranslator.FromHtml("#334155");
        public static readonly Color BgCardHov  = ColorTranslator.FromHtml("#3D5068");

        // ── Vurgu Renkleri ──────────────────────────────────────────────────
        public static readonly Color Accent      = ColorTranslator.FromHtml("#0EA5E9");
        public static readonly Color AccentHover = ColorTranslator.FromHtml("#38BDF8");
        public static readonly Color AccentDark  = ColorTranslator.FromHtml("#0284C7");

        // ── Metin Renkleri ──────────────────────────────────────────────────
        public static readonly Color TextLight  = ColorTranslator.FromHtml("#F8FAFC");
        public static readonly Color TextMuted  = ColorTranslator.FromHtml("#94A3B8");
        public static readonly Color TextDim    = ColorTranslator.FromHtml("#64748B");

        // ── Durum Renkleri ──────────────────────────────────────────────────
        public static readonly Color Success    = ColorTranslator.FromHtml("#10B981");
        public static readonly Color Danger     = ColorTranslator.FromHtml("#EF4444");
        public static readonly Color Warning    = ColorTranslator.FromHtml("#F59E0B");
        public static readonly Color Info       = ColorTranslator.FromHtml("#6366F1");

        // ── Ayırıcı ─────────────────────────────────────────────────────────
        public static readonly Color Border     = ColorTranslator.FromHtml("#1E3A5F");

        // ── Fontlar ──────────────────────────────────────────────────────────
        public static readonly Font LargeTitle = new Font("Segoe UI", 22f, FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font TitleFont  = new Font("Segoe UI", 14f, FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font SubFont    = new Font("Segoe UI", 12f, FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font MedBold    = new Font("Segoe UI", 11f, FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font BodyFont   = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font BodyBold   = new Font("Segoe UI", 10f, FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font SmallFont  = new Font("Segoe UI",  9f, FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font SmallBold  = new Font("Segoe UI",  9f, FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font TaglineFont= new Font("Segoe UI", 11f, FontStyle.Italic,  GraphicsUnit.Point);
    }
}
