using System.ComponentModel.DataAnnotations.Schema;

namespace express_website.Models
{
    public class ReferansClass
    {
        public int ReferansId { get; set; }
        public byte[]? ReferansGorsel { get; set; }

        [NotMapped]
        public IFormFile? GorselDosya { get; set; }
    }
}
