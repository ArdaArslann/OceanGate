using System;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    public static class KullaniciDAL
    {
        public static Kullanici GirisKontrol(string kullaniciAdi, string sifre)
        {
            string hash = DatabaseManager.HashSifre(sifre);
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT * FROM Kullanicilar WHERE KullaniciAdi=@k AND SifreHash=@s", conn))
                {
                    cmd.Parameters.AddWithValue("@k", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@s", hash);
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
                string hash = DatabaseManager.HashSifre(sifre);
                using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(
                        "INSERT INTO Kullanicilar (Ad, Soyad, KullaniciAdi, SifreHash, Rol, KayitTarihi) " +
                        "VALUES (@ad, @soyad, @k, @hash, 'kullanici', @tarih)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ad",    ad);
                        cmd.Parameters.AddWithValue("@soyad", soyad);
                        cmd.Parameters.AddWithValue("@k",     kullaniciAdi);
                        cmd.Parameters.AddWithValue("@hash",  hash);
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

        private static Kullanici Read(SQLiteDataReader r) => new Kullanici
        {
            Id           = Convert.ToInt32(r["Id"]),
            Ad           = r["Ad"].ToString(),
            Soyad        = r["Soyad"].ToString(),
            KullaniciAdi = r["KullaniciAdi"].ToString(),
            SifreHash    = r["SifreHash"].ToString(),
            Rol          = r["Rol"].ToString(),
            KayitTarihi  = DateTime.Parse(r["KayitTarihi"].ToString()),
        };
    }
}
