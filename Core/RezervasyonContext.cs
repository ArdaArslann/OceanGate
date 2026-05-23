using oceangate_r.DAL;
using oceangate_r.Entities;
using System;
using System.Collections.Generic;

namespace oceangate_r.Core
{
 
    public static class RezervasyonContext
    {
        //Adım 1-3: Temel Seçimler
        public static Bolge    SeciliBolge  { get; set; }
        public static Sefer    SeciliSefer  { get; set; }
        public static DateTime SeferTarihi  { get; set; } = DateTime.Today.AddDays(7);

        // Adım 4: Koltuk Seçimi
        public static int              KisiSayisi     { get; set; } = 0;
        public static List<KoltukAtama> KoltukAtamalar { get; set; } = new List<KoltukAtama>();

        //Adım 5: Otel Odası
        public static List<OtelOda> SeciliOdalar { get; set; } = new List<OtelOda>();

        public static void Sifirla()
        {
            SeciliBolge    = null;
            SeciliSefer    = null;
            SeferTarihi    = DateTime.Today.AddDays(7);
            KisiSayisi     = 0;
            KoltukAtamalar = new List<KoltukAtama>();
            SeciliOdalar   = new List<OtelOda>();
        }
    }
}
