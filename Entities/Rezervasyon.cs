using System;

namespace oceangate_r.Entities
{
    public class Rezervasyon
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }  
        public int SeferId { get; set; }
        public string SeferBilgisi { get; set; }  // JOIN: BolgeAdi + KalkisSaati
        public int KisiSayisi { get; set; }
        public double ToplamTutar { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public DateTime SeferTarihi { get; set; }
        public string Durum { get; set; }
        public string DekontNo { get; set; }

        public string ToplamTutarStr => $"{ToplamTutar:N2} TL";
        public string SeferTarihiStr => SeferTarihi.ToString("dd.MM.yyyy");
        public string RezervasyonTarihiStr => RezervasyonTarihi.ToString("dd.MM.yyyy HH:mm");
    }
}
