using System;
using System.Collections.Generic;
using System.Data.SQLite;
using oceangate_r.Entities;

namespace oceangate_r.DAL
{
    public static class RezervasyonDAL
    {
        private const string SelectJoin = @"
            SELECT r.*, k.KullaniciAdi,
                   b.Ad || ' – ' || s.KalkisSaati AS SeferBilgisi
            FROM   Rezervasyonlar r
            JOIN   Kullanicilar k ON r.KullaniciId = k.Id
            JOIN   Seferler     s ON r.SeferId     = s.Id
            JOIN   Bolgeler     b ON s.BolgeId     = b.Id";

        public static void Ekle(Rezervasyon rv)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Rezervasyonlar " +
                    "(KullaniciId,SeferId,KisiSayisi,ToplamTutar,RezervasyonTarihi,SeferTarihi,Durum,DekontNo) " +
                    "VALUES (@kid,@sid,@kisi,@tutar,@rtarih,@starih,@durum,@dekont)", conn))
                {
                    cmd.Parameters.AddWithValue("@kid",    rv.KullaniciId);
                    cmd.Parameters.AddWithValue("@sid",    rv.SeferId);
                    cmd.Parameters.AddWithValue("@kisi",   rv.KisiSayisi);
                    cmd.Parameters.AddWithValue("@tutar",  rv.ToplamTutar);
                    cmd.Parameters.AddWithValue("@rtarih", rv.RezervasyonTarihi.ToString("o"));
                    cmd.Parameters.AddWithValue("@starih", rv.SeferTarihi.ToString("o"));
                    cmd.Parameters.AddWithValue("@durum",  rv.Durum);
                    cmd.Parameters.AddWithValue("@dekont", rv.DekontNo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Rezervasyon> KullanicininRezervasyonlari(int kullaniciId)
        {
            return GetList("WHERE r.KullaniciId=@p ORDER BY r.RezervasyonTarihi DESC", kullaniciId);
        }

        public static List<Rezervasyon> Tumunu()
        {
            return GetList("ORDER BY r.RezervasyonTarihi DESC", -1);
        }

        public static void DurumGuncelle(int id, string durum)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Rezervasyonlar SET Durum=@d WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@d",  durum);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SeferTarihiGuncelle(int id, DateTime yeniTarih)
        {
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Rezervasyonlar SET SeferTarihi=@t WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@t",  yeniTarih.ToString("o"));
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static List<Rezervasyon> GetList(string whereOrderClause, int param)
        {
            var list = new List<Rezervasyon>();
            using (var conn = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                string sql = SelectJoin + " " + whereOrderClause;
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (param >= 0)
                        cmd.Parameters.AddWithValue("@p", param);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Read(r));
                }
            }
            return list;
        }

        private static Rezervasyon Read(SQLiteDataReader r) => new Rezervasyon
        {
            Id                 = Convert.ToInt32(r["Id"]),
            KullaniciId        = Convert.ToInt32(r["KullaniciId"]),
            KullaniciAdi       = r["KullaniciAdi"].ToString(),
            SeferId            = Convert.ToInt32(r["SeferId"]),
            SeferBilgisi       = r["SeferBilgisi"].ToString(),
            KisiSayisi         = Convert.ToInt32(r["KisiSayisi"]),
            ToplamTutar        = Convert.ToDouble(r["ToplamTutar"]),
            RezervasyonTarihi  = DateTime.Parse(r["RezervasyonTarihi"].ToString()),
            SeferTarihi        = DateTime.Parse(r["SeferTarihi"].ToString()),
            Durum              = r["Durum"].ToString(),
            DekontNo           = r["DekontNo"].ToString(),
        };
    }
}
