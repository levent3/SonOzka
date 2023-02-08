namespace Entites
{
    public class Sehir
    {

        public int Id { get; set; }
        public string SehirKodu { get; set; }
        public string SehirAdi { get; set; }

        public int UlkeId { get; set; }
        public Ulke? Ulke { get; set; }
    }
}
