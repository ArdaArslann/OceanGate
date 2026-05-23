using oceangate_r.Entities;

namespace oceangate_r
{

    public static class SessionManager
    {
        public static Kullanici AktifKullanici { get; private set; }
        public static bool AdminMi => AktifKullanici?.Rol == "admin";

        public static void GirisYap(Kullanici kullanici)
        {
            AktifKullanici = kullanici;
        }

        public static void CikisYap()
        {
            AktifKullanici = null;
        }
    }
}
