namespace oceangate_r.DAL
{
    /// <summary>
    /// Tek bir koltuk atamasını temsil eder.
    /// Cinsiyet: "Kadin" veya "Erkek"
    /// </summary>
    public class KoltukAtama
    {
        public int    KoltukNo { get; set; }
        public string Cinsiyet { get; set; }   // "Kadin" | "Erkek"
    }
}
