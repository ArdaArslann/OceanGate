namespace oceangate_r.Entities
{
    public enum OdaDurum
    {
        Bos,   
        Dolu,   
        Secili  
    }

    
    public class OtelOda
    {
        public int      Id       { get; set; }
        public string   OdaNo    { get; set; }   
        public int      Kapasite { get; set; }   
        public OdaDurum Durum    { get; set; } = OdaDurum.Bos;
    }
}
