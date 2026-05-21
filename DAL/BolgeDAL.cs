using System;
using System.Collections.Generic;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    public static class BolgeDAL
    {
        public static List<Bolge> Listele(bool sadecAktif = false)
        {
            var list = new List<Bolge>();
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                string sql = sadecAktif
                    ? "SELECT * FROM Bolgeler WHERE AktifMi=1 ORDER BY Ad"
                    : "SELECT * FROM Bolgeler ORDER BY Ad";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(Read(r));
            }
            return list;
        }

        public static void Ekle(Bolge b)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Bolgeler (Ad, Aciklama, Derinlik, AktifMi) VALUES (@ad,@ac,@d,@aktif)", conn))
                {
                    cmd.Parameters.AddWithValue("@ad",    b.Ad);
                    cmd.Parameters.AddWithValue("@ac",    b.Aciklama ?? "");
                    cmd.Parameters.AddWithValue("@d",     b.Derinlik);
                    cmd.Parameters.AddWithValue("@aktif", b.AktifMi ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Guncelle(Bolge b)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Bolgeler SET Ad=@ad, Aciklama=@ac, Derinlik=@d, AktifMi=@aktif WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@ad",    b.Ad);
                    cmd.Parameters.AddWithValue("@ac",    b.Aciklama ?? "");
                    cmd.Parameters.AddWithValue("@d",     b.Derinlik);
                    cmd.Parameters.AddWithValue("@aktif", b.AktifMi ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id",    b.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>Soft-delete: aktif durumu 0 yapılır, fiziksel silme yapılmaz.</summary>
        public static void Sil(int id)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("UPDATE Bolgeler SET AktifMi=0 WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Bolge Read(SQLiteDataReader r) => new Bolge
        {
            Id       = Convert.ToInt32(r["Id"]),
            Ad       = r["Ad"].ToString(),
            Aciklama = r["Aciklama"].ToString(),
            Derinlik = Convert.ToDouble(r["Derinlik"]),
            AktifMi  = Convert.ToInt32(r["AktifMi"]) == 1,
        };
    }
}
