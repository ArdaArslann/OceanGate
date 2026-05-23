using System;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    public static class KullaniciDAL
    {
        public static Kullanici GirisKontrol(string kullaniciAdi, string sifre)
        {
            
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT * FROM Kullanicilar WHERE KullaniciAdi=@k ", conn))
                {
                    cmd.Parameters.AddWithValue("@k", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read()) return Read(r);
                    }
                }
            }
            return null;
        }

        public static bool KayitOl(string ad, string soyad, string kullaniciAdi, string sifre)
        {
            try
            {
                
                using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(
                        "INSERT INTO Kullanicilar (Ad, Soyad, KullaniciAdi, Sifre, Rol, KayitTarihi) " +
                        "VALUES (@ad, @soyad, @k, @sifre, 'kullanici', @tarih)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ad",    ad);
                        cmd.Parameters.AddWithValue("@soyad", soyad);
                        cmd.Parameters.AddWithValue("@k",     kullaniciAdi);
                        cmd.Parameters.AddWithValue("@sifre", sifre);
                        cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("o"));
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch { return false; }
        }

        public static bool KullaniciAdiVarMi(string kullaniciAdi)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@k", conn))
                {
                    cmd.Parameters.AddWithValue("@k", kullaniciAdi);
                    return (long)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static double BakiyeGetir(int kullaniciId)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT Bakiye FROM Kullanicilar WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", kullaniciId);
                    var result = cmd.ExecuteScalar();
                    return result == null ? 0 : Convert.ToDouble(result);
                }
            }
        }

        public static void BakiyeYukle(int kullaniciId, double eklenecekMiktar)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Kullanicilar SET Bakiye = Bakiye + @miktar WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@miktar", eklenecekMiktar);
                    cmd.Parameters.AddWithValue("@id", kullaniciId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void BakiyeDus(int kullaniciId, double miktar)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Kullanicilar SET Bakiye = Bakiye - @miktar WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@miktar", miktar);
                    cmd.Parameters.AddWithValue("@id", kullaniciId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Kullanici Read(SQLiteDataReader r) => new Kullanici
        {
            Id           = Convert.ToInt32(r["Id"]),
            Ad           = r["Ad"].ToString(),
            Soyad        = r["Soyad"].ToString(),
            KullaniciAdi = r["KullaniciAdi"].ToString(),
            Rol          = r["Rol"].ToString(),
            KayitTarihi  = DateTime.Parse(r["KayitTarihi"].ToString()),
            Bakiye       = r["Bakiye"] != DBNull.Value ? Convert.ToDouble(r["Bakiye"]) : 0,
        };
    }
}

