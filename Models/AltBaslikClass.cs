namespace express_website.Models
{
    public class AltBaslikClass
    {
        public int AltBaslikId { get; set; }

        public string? AltBaslikAdi { get; set; }

        public int BaslikId { get; set; }

        public BaslikClass? Baslik { get; set; }
        
        public List<ElemanClass>? ElemanListe { get; set; }

    }
}
