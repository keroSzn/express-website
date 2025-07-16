namespace express_website.Models
{
    public class BlogClass
    {
        public int BlogId { get; set; }

        public DateOnly BlogTarih { get; set; }

        public string? BlogBaslik { get; set; }

        public string? BlogMetin { get; set; }

    }
}