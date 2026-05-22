namespace oceangate_r.Entities
{
    public class Bolge
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public double Derinlik { get; set; }
        public bool AktifMi { get; set; }

        public override string ToString() => Ad;
    }
}
