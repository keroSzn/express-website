namespace express_website.Models
{
    public class BaslikClass
    {
        public int BaslikId { get; set; }

        public string? BaslikAdi { get; set; }

        public int KategoriId { get; set; }

        public KategoriClass? KategoriClass { get; set; }
        
        public List<AltBaslikClass>? AltBaslikListe { get; set; }

    }
}
