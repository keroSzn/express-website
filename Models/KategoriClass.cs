namespace express_website.Models
{
    public class KategoriClass
    {
        public int KategoriId { get; set; }

        public string? KategoriAdi { get; set; }

        public string? KategoriMetin { get; set; }
        
        public List<BaslikClass>? BaslikListe { get; set; }

    }
}
