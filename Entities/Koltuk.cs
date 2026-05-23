namespace oceangate_r.Entities
{
   
    public enum KoltukDurum
    {
        Bos,        
        DoluKadin,  
        DoluErkek,  
        Secili    
    }

  
    public class Koltuk
    {
        public int No    { get; set; }   
        public KoltukDurum Durum { get; set; } = KoltukDurum.Bos;
    }
}
