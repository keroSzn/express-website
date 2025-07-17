namespace express_website.Models
{
    public class HucreClass
    {
        public int HucreId { get; set; }

        public string? HucreMetin { get; set; }

        public int AlanId { get; set; }

        public AlanClass? Alan { get; set; }
        
    }
}
