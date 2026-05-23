using System;

namespace oceangate_r.Entities
{
    public class Talep
    {
        public int Id { get; set; }
        public int RezervasyonId { get; set; }
        public string DekontNo { get; set; }      
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }  
        public string TalepTipi { get; set; }     
        public string Aciklama { get; set; }
        public DateTime TalepTarihi { get; set; }
        public string Durum { get; set; }       
        public string YeniSeferTarihi { get; set; }

        public string TalepTarihiStr => TalepTarihi.ToString("dd.MM.yyyy HH:mm");
    }
}
