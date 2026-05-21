using System;
using System.Collections.Generic;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    public static class TalepDAL
    {
        private const string SelectJoin =
            "SELECT t.*, k.KullaniciAdi, r.DekontNo " +
            "FROM   Talepler       t " +
            "JOIN   Kullanicilar   k ON t.KullaniciId   = k.Id " +
            "JOIN   Rezervasyonlar r ON t.RezervasyonId = r.Id";

        public static void Ekle(Talep t)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Talepler " +
                    "(RezervasyonId,KullaniciId,TalepTipi,Aciklama,TalepTarihi,Durum,YeniSeferTarihi) " +
                    "VALUES (@rid,@kid,@tip,@ac,@tarih,'Bekliyor',@yst)", conn))
                {
                    cmd.Parameters.AddWithValue("@rid",  t.RezervasyonId);
                    cmd.Parameters.AddWithValue("@kid",  t.KullaniciId);
                    cmd.Parameters.AddWithValue("@tip",  t.TalepTipi);
                    cmd.Parameters.AddWithValue("@ac",   t.Aciklama ?? "");
                    cmd.Parameters.AddWithValue("@tarih",DateTime.Now.ToString("o"));
                    cmd.Parameters.AddWithValue("@yst",  t.YeniSeferTarihi ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Talep> Tumunu()     => GetList("ORDER BY t.TalepTarihi DESC");
        public static List<Talep> Bekleyenler()=> GetList("WHERE t.Durum='Bekliyor' ORDER BY t.TalepTarihi DESC");

        public static void DurumGuncelle(int id, string durum)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("UPDATE Talepler SET Durum=@d WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@d",  durum);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static List<Talep> GetList(string whereOrder)
        {
            var list = new List<Talep>();
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(SelectJoin + " " + whereOrder, conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(Read(r));
            }
            return list;
        }

        private static Talep Read(SQLiteDataReader r) => new Talep
        {
            Id              = Convert.ToInt32(r["Id"]),
            RezervasyonId   = Convert.ToInt32(r["RezervasyonId"]),
            DekontNo        = r["DekontNo"].ToString(),
            KullaniciId     = Convert.ToInt32(r["KullaniciId"]),
            KullaniciAdi    = r["KullaniciAdi"].ToString(),
            TalepTipi       = r["TalepTipi"].ToString(),
            Aciklama        = r["Aciklama"].ToString(),
            TalepTarihi     = DateTime.Parse(r["TalepTarihi"].ToString()),
            Durum           = r["Durum"].ToString(),
            YeniSeferTarihi = r["YeniSeferTarihi"].ToString(),
        };
    }
}
