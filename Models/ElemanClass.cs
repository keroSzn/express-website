namespace express_website.Models
{
    public class ElemanClass
    {
        public int ElemanId { get; set; }

        public string? ElemanAdi { get; set; }

        public string? ElemanMetin { get; set; }

        public int AltBaslikId { get; set; }

        public AltBaslikClass? AitOlduguAltBaslik { get; set; }
        
        public List<ElemanModeliClass>? ElemanModeliListe { get; set; }

    }
}
