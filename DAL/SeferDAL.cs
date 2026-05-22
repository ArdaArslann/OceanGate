using System;
using System.Collections.Generic;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    public static class SeferDAL
    {
        private const string SelectJoin =
            "SELECT s.*, b.Ad AS BolgeAdi FROM Seferler s " +
            "JOIN Bolgeler b ON s.BolgeId = b.Id";

        public static List<Sefer> Listele(bool sadecAktif = false)
        {
            var list = new List<Sefer>();
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                string sql = SelectJoin +
                    (sadecAktif ? " WHERE s.AktifMi=1 AND b.AktifMi=1" : "") +
                    " ORDER BY b.Ad, s.KalkisSaati";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(Read(r));
            }
            return list;
        }

        public static List<Sefer> BolgeninSefer(int bolgeId)
        {
            var list = new List<Sefer>();
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    SelectJoin + " WHERE s.BolgeId=@id AND s.AktifMi=1 ORDER BY s.KalkisSaati", conn))
                {
                    cmd.Parameters.AddWithValue("@id", bolgeId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Read(r));
                }
            }
            return list;
        }

        public static void Ekle(Sefer s)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Seferler (BolgeId,KalkisSaati,KapasiteSayisi,SureDakika,FiyatKisiBasiTL,AktifMi) " +
                    "VALUES (@bid,@saat,@kap,@sure,@fiyat,@aktif)", conn))
                {
                    cmd.Parameters.AddWithValue("@bid",   s.BolgeId);
                    cmd.Parameters.AddWithValue("@saat",  s.KalkisSaati);
                    cmd.Parameters.AddWithValue("@kap",   s.KapasiteSayisi);
                    cmd.Parameters.AddWithValue("@sure",  s.SureDakika);
                    cmd.Parameters.AddWithValue("@fiyat", s.FiyatKisiBasiTL);
                    cmd.Parameters.AddWithValue("@aktif", s.AktifMi ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Guncelle(Sefer s)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Seferler SET BolgeId=@bid,KalkisSaati=@saat,KapasiteSayisi=@kap," +
                    "SureDakika=@sure,FiyatKisiBasiTL=@fiyat,AktifMi=@aktif WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@bid",   s.BolgeId);
                    cmd.Parameters.AddWithValue("@saat",  s.KalkisSaati);
                    cmd.Parameters.AddWithValue("@kap",   s.KapasiteSayisi);
                    cmd.Parameters.AddWithValue("@sure",  s.SureDakika);
                    cmd.Parameters.AddWithValue("@fiyat", s.FiyatKisiBasiTL);
                    cmd.Parameters.AddWithValue("@aktif", s.AktifMi ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id",    s.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void FiyatGuncelle(int id, double yeniFiyat)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Seferler SET FiyatKisiBasiTL=@f WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@f",  yeniFiyat);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Sil(int id)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var tr = conn.BeginTransaction())
                {
                    try
                    {
                        var cmds = new[]
                        {
                            "DELETE FROM Talepler WHERE RezervasyonId IN (SELECT Id FROM Rezervasyonlar WHERE SeferId=@id)",
                            "DELETE FROM RezervasyonKoltuklar WHERE SeferId=@id",
                            "DELETE FROM RezervasyonOdalar WHERE SeferId=@id",
                            "DELETE FROM Rezervasyonlar WHERE SeferId=@id",
                            "DELETE FROM Seferler WHERE Id=@id"
                        };
                        foreach (var sql in cmds)
                        {
                            using (var cmd = new SQLiteCommand(sql, conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
        }

        private static Sefer Read(SQLiteDataReader r) => new Sefer
        {
            Id              = Convert.ToInt32(r["Id"]),
            BolgeId         = Convert.ToInt32(r["BolgeId"]),
            BolgeAdi        = r["BolgeAdi"].ToString(),
            KalkisSaati     = r["KalkisSaati"].ToString(),
            KapasiteSayisi  = Convert.ToInt32(r["KapasiteSayisi"]),
            SureDakika      = Convert.ToInt32(r["SureDakika"]),
            FiyatKisiBasiTL = Convert.ToDouble(r["FiyatKisiBasiTL"]),
            AktifMi         = Convert.ToInt32(r["AktifMi"]) == 1,
        };
    }
}
