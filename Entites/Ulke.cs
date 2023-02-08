namespace Entites
{
    public class Ulke
    {
        public int Id { get; set; }

        public string UlkeKodu { get; set; }
        public string UlkeAdi { get; set; }
        public int TelefonKodu { get; set; }
        public ICollection<Sehir> Sehirler { get; set; }
    }
}
