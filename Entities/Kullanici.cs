using System;

namespace oceangate_r.Entities
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
        public DateTime KayitTarihi { get; set; }

        public double Bakiye { get; set; } = 0;

        public string TamAd => $"{Ad} {Soyad}";
    }
}
