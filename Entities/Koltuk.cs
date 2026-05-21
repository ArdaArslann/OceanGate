namespace oceangate_r.Entities
{
    // ── ARCHITECT: Koltuk durum enum'ı ─────────────────────────────────────
    // Her koltuk dört farklı durumda olabilir.
    // Bu enum, renk mantığı ve tıklama kısıtlamaları için temel referanstır.
    public enum KoltukDurum
    {
        Bos,        // Henüz kimse oturmamış
        DoluKadin,  // Kadın yolcu tarafından dolu
        DoluErkek,  // Erkek yolcu tarafından dolu
        Secili      // Mevcut kullanıcı tarafından seçilmiş
    }

    /// <summary>
    /// Denizaltı içindeki tek bir koltuğu temsil eden model.
    /// </summary>
    public class Koltuk
    {
        public int No    { get; set; }   // Görünen koltuk numarası (1-based)
        public KoltukDurum Durum { get; set; } = KoltukDurum.Bos;
    }
}
