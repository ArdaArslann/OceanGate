namespace oceangate_r.Entities
{
    // ── ARCHITECT: Oda durum enum'ı ────────────────────────────────────────────
    public enum OdaDurum
    {
        Bos,    // Henüz alınmamış
        Dolu,   // Başkası tarafından alınmış
        Secili  // Bu oturumda kullanıcı tarafından seçilmiş
    }

    /// <summary>
    /// Otel odasını temsil eden model.
    /// Kapasite: 1, 2, 3 veya 4 kişilik
    /// </summary>
    public class OtelOda
    {
        public int      Id       { get; set; }
        public string   OdaNo    { get; set; }   // "101", "202" vb.
        public int      Kapasite { get; set; }   // 1 | 2 | 3 | 4
        public OdaDurum Durum    { get; set; } = OdaDurum.Bos;
    }
}
