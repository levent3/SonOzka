using System.ComponentModel.DataAnnotations;

namespace MvcWuıLayer.Models
{
    public class SehirlerInsertDto
    {
        public string SehirKodu { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sehir Adi Boş Olamaz")]
        public string SehirAdi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ulke Secilmek Zorundadir")]

        public int UlkeId { get; set; }

    }
}
