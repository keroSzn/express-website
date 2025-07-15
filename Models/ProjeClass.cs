using System.ComponentModel.DataAnnotations.Schema;

namespace express_website.Models
{
    public class ProjeClass
    {
        public int ProjeId { get; set; }
        public string? ProjeAdi { get; set; }
        public byte[]? ProjeGorsel { get; set; }

        [NotMapped]
        public IFormFile? ProjeGorselDosya { get; set; }
    }
}
