using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace oceangate_r.DAL
{
    /// <summary>
    /// SQLite veritabanı bağlantısını ve tablo oluşturmayı yönetir.
    /// Uygulama açılışında DatabaseManager.Initialize() çağrılmalıdır.
    /// </summary>
    public static class DatabaseManager
    {
        private static string _dbPath;
        private static string _connectionString;

        public static string ConnectionString => _connectionString;

        public static void Initialize()
        {
            string appData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Oceangate");
            Directory.CreateDirectory(appData);
            _dbPath = Path.Combine(appData, "oceangate.db");
            _connectionString = $"Data Source={_dbPath};Version=3;";

            CreateTables();
            SeedData();
        }

        private static void CreateTables()
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                // UTF-8 kodlamasını zorla
                Execute(conn, "PRAGMA encoding = 'UTF-8';");
                Execute(conn, "PRAGMA foreign_keys = ON;");

                string sql = @"
CREATE TABLE IF NOT EXISTS Kullanicilar (
    Id            INTEGER PRIMARY KEY AUTOINCREMENT,
    Ad            TEXT    NOT NULL,
    Soyad         TEXT    NOT NULL,
    KullaniciAdi  TEXT    UNIQUE NOT NULL,
    SifreHash     TEXT    NOT NULL,
    Rol           TEXT    NOT NULL DEFAULT 'kullanici',
    KayitTarihi   TEXT    NOT NULL
);

CREATE TABLE IF NOT EXISTS Bolgeler (
    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
    Ad       TEXT    NOT NULL,
    Aciklama TEXT,
    Derinlik REAL    DEFAULT 0,
    AktifMi  INTEGER DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Seferler (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    BolgeId         INTEGER NOT NULL,
    KalkisSaati     TEXT    NOT NULL,
    KapasiteSayisi  INTEGER DEFAULT 20,
    SureDakika      INTEGER DEFAULT 120,
    FiyatKisiBasiTL REAL    NOT NULL,
    AktifMi         INTEGER DEFAULT 1,
    FOREIGN KEY (BolgeId) REFERENCES Bolgeler(Id)
);

CREATE TABLE IF NOT EXISTS Rezervasyonlar (
    Id                 INTEGER PRIMARY KEY AUTOINCREMENT,
    KullaniciId        INTEGER NOT NULL,
    SeferId            INTEGER NOT NULL,
    KisiSayisi         INTEGER NOT NULL DEFAULT 1,
    ToplamTutar        REAL    NOT NULL,
    RezervasyonTarihi  TEXT    NOT NULL,
    SeferTarihi        TEXT    NOT NULL,
    Durum              TEXT    NOT NULL DEFAULT 'Onaylandi',
    DekontNo           TEXT    UNIQUE NOT NULL,
    FOREIGN KEY (KullaniciId) REFERENCES Kullanicilar(Id),
    FOREIGN KEY (SeferId)     REFERENCES Seferler(Id)
);

CREATE TABLE IF NOT EXISTS Talepler (
    Id               INTEGER PRIMARY KEY AUTOINCREMENT,
    RezervasyonId    INTEGER NOT NULL,
    KullaniciId      INTEGER NOT NULL,
    TalepTipi        TEXT    NOT NULL,
    Aciklama         TEXT,
    TalepTarihi      TEXT    NOT NULL,
    Durum            TEXT    NOT NULL DEFAULT 'Bekliyor',
    YeniSeferTarihi  TEXT,
    FOREIGN KEY (RezervasyonId) REFERENCES Rezervasyonlar(Id),
    FOREIGN KEY (KullaniciId)   REFERENCES Kullanicilar(Id)
);";
                Execute(conn, sql);
            }
        }

        private static void SeedData()
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                // Admin kullanıcısı
                long adminSayisi = (long)Scalar(conn, "SELECT COUNT(*) FROM Kullanicilar WHERE Rol='admin'");
                if (adminSayisi == 0)
                {
                    Execute(conn,
                        "INSERT INTO Kullanicilar (Ad, Soyad, KullaniciAdi, SifreHash, Rol, KayitTarihi) " +
                        $"VALUES ('Admin', 'Oceangate', 'admin', '{HashSifre("admin123")}', 'admin', '{DateTime.Now:o}')");
                }

                // Örnek bölgeler ve seferler
                long bolgeSayisi = (long)Scalar(conn, "SELECT COUNT(*) FROM Bolgeler");
                if (bolgeSayisi == 0)
                {
                    string[][] bolgeler = {
                        new[]{"Kizil Deniz Safari",       "Egzotik mercan resifleri ve tropikal baliklar",    "45"},
                        new[]{"Atlantik Derin Su",        "Gizemli Atlantik okyanus dibi kesifi",             "320"},
                        new[]{"Karayip Mercan Bahcesi",   "Renkli mercan bahceleri ve canlı deniz yasami",    "80"},
                        new[]{"Pasifik Batik Kesfi",      "II. Dunya Savasi batiklari ve tarihi harabeler",   "150"},
                        new[]{"Arktik Buz Alti",          "Buzul alti mistik dunya ve buz magaralari",        "200"},
                    };

                    foreach (var b in bolgeler)
                    {
                        Execute(conn,
                            $"INSERT INTO Bolgeler (Ad, Aciklama, Derinlik, AktifMi) " +
                            $"VALUES ('{b[0]}', '{b[1]}', {b[2]}, 1)");
                    }

                    // Her bölge için en az 2 sefer
                    string[][] seferler = {
                        new[]{"1","09:00","20","180","4500"},
                        new[]{"1","14:00","20","180","4500"},
                        new[]{"2","10:00","12","480","12000"},
                        new[]{"2","16:00","12","480","12000"},
                        new[]{"3","08:00","25","240","7500"},
                        new[]{"3","13:00","25","240","7500"},
                        new[]{"4","11:00","15","360","9000"},
                        new[]{"4","15:00","15","360","9000"},
                        new[]{"5","07:00","10","420","15000"},
                        new[]{"5","12:00","10","420","15000"},
                    };

                    foreach (var s in seferler)
                    {
                        Execute(conn,
                            $"INSERT INTO Seferler (BolgeId, KalkisSaati, KapasiteSayisi, SureDakika, FiyatKisiBasiTL, AktifMi) " +
                            $"VALUES ({s[0]}, '{s[1]}', {s[2]}, {s[3]}, {s[4]}, 1)");
                    }
                }
            }
        }

        // ── Yardımcı metotlar ────────────────────────────────────────────────

        private static void Execute(SQLiteConnection conn, string sql)
        {
            using (var cmd = new SQLiteCommand(sql, conn))
                cmd.ExecuteNonQuery();
        }

        private static object Scalar(SQLiteConnection conn, string sql)
        {
            using (var cmd = new SQLiteCommand(sql, conn))
                return cmd.ExecuteScalar();
        }

        public static string HashSifre(string sifre)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                return Convert.ToBase64String(bytes);
            }
        }

        public static string YeniDekontNo()
        {
            return "OG-" + DateTime.Now.ToString("yyyyMMdd") + "-" +
                   Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }
    }
}
