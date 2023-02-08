namespace MvcWuıLayer.Models
{
    public class SehirlerDto
    {
        public int id { get; set; }
        public string sehirAdi { get; set; }
        public string ulkeAdi { get; set; }
        public int ulkeId { get; set; }
    }


    public class Sehirler
    {
        public int id { get; set; }
        public string sehirAdi { get; set; }
        public string ulkeAdi { get; set; }
    }
}
