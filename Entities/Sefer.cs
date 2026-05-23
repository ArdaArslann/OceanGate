namespace oceangate_r.Entities
{
    public class Sefer
    {
        public int Id { get; set; }
        public int BolgeId { get; set; }
        public string BolgeAdi { get; set; }     
        public string KalkisSaati { get; set; }
        public int KapasiteSayisi { get; set; }
        public int SureDakika { get; set; }
        public double FiyatKisiBasiTL { get; set; }
        public bool AktifMi { get; set; }

        public string SureMetni
        {
            get
            {
                int saat = SureDakika / 60;
                int dk   = SureDakika % 60;
                return saat > 0 ? $"{saat}s {dk}dk" : $"{dk}dk";
            }
        }

        public override string ToString() => $"{BolgeAdi} – {KalkisSaati}";
    }
}
