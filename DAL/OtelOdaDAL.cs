using System;
using System.Collections.Generic;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
  
    public static class OtelOdaDAL
    {
      
        public static List<OtelOda> TumOdalariGetir(int seferId, DateTime seferTarihi)
        {
            var list = new List<OtelOda>();
            string tarihStr = seferTarihi.ToString("yyyy-MM-dd");

            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT o.Id, o.OdaNo, o.Kapasite,
                           CASE WHEN ro.OtelOdaId IS NOT NULL THEN 1 ELSE 0 END AS Dolu
                    FROM   OtelOdalar o
                    LEFT JOIN RezervasyonOdalar ro
                           ON  o.Id           = ro.OtelOdaId
                           AND ro.SeferId      = @seferId
                           AND ro.SeferTarihi  = @seferTarihi
                           AND ro.RezervasyonId IN (
                               SELECT Id FROM Rezervasyonlar
                               WHERE  Durum NOT IN ('Iptal','Reddedildi')
                           )
                    WHERE  o.AktifMi = 1
                    ORDER  BY o.Kapasite, o.OdaNo";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@seferId",     seferId);
                    cmd.Parameters.AddWithValue("@seferTarihi", tarihStr);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new OtelOda
                            {
                                Id       = Convert.ToInt32(r["Id"]),
                                OdaNo    = r["OdaNo"].ToString(),
                                Kapasite = Convert.ToInt32(r["Kapasite"]),
                                Durum    = Convert.ToInt32(r["Dolu"]) == 1
                                           ? OdaDurum.Dolu
                                           : OdaDurum.Bos,
                            });
                        }
                    }
                }
            }
            return list;
        }

       
        public static void OdaKaydet(int rezervasyonId, int otelOdaId,
                                     int seferId, DateTime seferTarihi)
        {
            string tarihStr = seferTarihi.ToString("yyyy-MM-dd");
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                const string sql =
                    "INSERT INTO RezervasyonOdalar " +
                    "(RezervasyonId, OtelOdaId, SeferId, SeferTarihi) " +
                    "VALUES (@rid, @oid, @sid, @starihi)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@rid",     rezervasyonId);
                    cmd.Parameters.AddWithValue("@oid",     otelOdaId);
                    cmd.Parameters.AddWithValue("@sid",     seferId);
                    cmd.Parameters.AddWithValue("@starihi", tarihStr);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<OtelOda> RezervasyonunOdalari(int rezervasyonId)
        {
            var list = new List<OtelOda>();
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                const string sql = @"
                    SELECT o.Id, o.OdaNo, o.Kapasite
                    FROM   RezervasyonOdalar ro
                    JOIN   OtelOdalar o ON ro.OtelOdaId = o.Id
                    WHERE  ro.RezervasyonId = @rid";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@rid", rezervasyonId);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            list.Add(new OtelOda
                            {
                                Id       = Convert.ToInt32(r["Id"]),
                                OdaNo    = r["OdaNo"].ToString(),
                                Kapasite = Convert.ToInt32(r["Kapasite"]),
                            });
                    }
                }
            }
            return list;
        }

      
        public static int ToplamBosKapasite(int seferId, DateTime seferTarihi)
        {
            int toplam = 0;
            foreach (var oda in TumOdalariGetir(seferId, seferTarihi))
                if (oda.Durum == OdaDurum.Bos)
                    toplam += oda.Kapasite;
            return toplam;
        }
    }
}
