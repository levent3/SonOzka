using Newtonsoft.Json;

namespace MvcWuıLayer.Models
{
    public class SehirlerSelectDto
    {
        public int id { get; set; }
        public string sehirKodu { get; set; }
        public string sehirAdi { get; set; }
        public int ulkeId { get; set; }
        public Ulke ulke { get; set; }

    }


    public class Ulke
    {
        public int id { get; set; }
        public string ulkeKodu { get; set; }
        public string ulkeAdi { get; set; }
        public int telefonKodu { get; set; }
        [JsonIgnore]
        public List<object> sehirler { get; set; }
    }



}
