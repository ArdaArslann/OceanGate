using System;
using System.Collections.Generic;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    public static class KoltukDAL
    {
        
        public static void KoltuklariKaydet(int rezervasyonId, int seferId,
            DateTime seferTarihi, List<KoltukAtama> atamalar)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                foreach (var a in atamalar)
                {
                    using (var cmd = new SQLiteCommand(
                        "INSERT INTO RezervasyonKoltuklar " +
                        "(RezervasyonId, SeferId, SeferTarihi, KoltukNo, Cinsiyet) " +
                        "VALUES (@rid, @sid, @st, @kno, @cins)", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid",  rezervasyonId);
                        cmd.Parameters.AddWithValue("@sid",  seferId);
                        cmd.Parameters.AddWithValue("@st",   seferTarihi.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@kno",  a.KoltukNo);
                        cmd.Parameters.AddWithValue("@cins", a.Cinsiyet);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        
        public static List<KoltukAtama> DoluKoltuklariGetir(int seferId, DateTime seferTarihi)
        {
            var list = new List<KoltukAtama>();
            string tarihStr = seferTarihi.ToString("yyyy-MM-dd");

            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                // Iptal edilmiş rezervasyonları dahil etme
                string sql = @"
                    SELECT rk.KoltukNo, rk.Cinsiyet
                    FROM   RezervasyonKoltuklar rk
                    JOIN   Rezervasyonlar r ON rk.RezervasyonId = r.Id
                    WHERE  rk.SeferId = @sid
                      AND  rk.SeferTarihi = @st
                      AND  r.Durum NOT IN ('Iptal', 'Reddedildi')";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", seferId);
                    cmd.Parameters.AddWithValue("@st",  tarihStr);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new KoltukAtama
                            {
                                KoltukNo = Convert.ToInt32(r["KoltukNo"]),
                                Cinsiyet = r["Cinsiyet"].ToString(),
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
