using System;
using System.Collections.Generic;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    /// <summary>
    /// OtelOdalar ve RezervasyonOdalar tabloları için veri erişim katmanı.
    /// </summary>
    public static class OtelOdaDAL
    {
        /// <summary>
        /// Tüm aktif otel odalarını getirir.
        /// Halihazırda rezerve edilmiş odalar Dolu olarak işaretlenir.
        /// </summary>
        public static List<OtelOda> TumOdalariGetir()
        {
            var list = new List<OtelOda>();
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT o.Id, o.OdaNo, o.Kapasite,
                           CASE WHEN ro.OtelOdaId IS NOT NULL THEN 1 ELSE 0 END AS Dolu
                    FROM   OtelOdalar o
                    LEFT JOIN RezervasyonOdalar ro ON o.Id = ro.OtelOdaId
                                                   AND ro.RezervasyonId IN (
                                                       SELECT Id FROM Rezervasyonlar
                                                       WHERE Durum NOT IN ('Iptal','Reddedildi')
                                                   )
                    WHERE  o.AktifMi = 1
                    ORDER  BY o.Kapasite, o.OdaNo";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var r   = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new OtelOda
                        {
                            Id       = Convert.ToInt32(r["Id"]),
                            OdaNo    = r["OdaNo"].ToString(),
                            Kapasite = Convert.ToInt32(r["Kapasite"]),
                            Durum    = Convert.ToInt32(r["Dolu"]) == 1 ? OdaDurum.Dolu : OdaDurum.Bos,
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Seçilen odayı rezervasyona bağlar.
        /// </summary>
        public static void OdaKaydet(int rezervasyonId, int otelOdaId)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO RezervasyonOdalar (RezervasyonId, OtelOdaId) VALUES (@rid, @oid)", conn))
                {
                    cmd.Parameters.AddWithValue("@rid", rezervasyonId);
                    cmd.Parameters.AddWithValue("@oid", otelOdaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Rezervasyona bağlı odayı getirir (Özet paneli için).
        /// </summary>
        public static OtelOda RezervasyonunOdasi(int rezervasyonId)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT o.Id, o.OdaNo, o.Kapasite
                    FROM   RezervasyonOdalar ro
                    JOIN   OtelOdalar o ON ro.OtelOdaId = o.Id
                    WHERE  ro.RezervasyonId = @rid";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@rid", rezervasyonId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                            return new OtelOda
                            {
                                Id       = Convert.ToInt32(r["Id"]),
                                OdaNo    = r["OdaNo"].ToString(),
                                Kapasite = Convert.ToInt32(r["Kapasite"]),
                            };
                    }
                }
            }
            return null;
        }
    }
}
