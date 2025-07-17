namespace express_website.Models
{
    public class ElemanModeliClass
    {
        public int ElemanModeliId { get; set; }

        public string? ElemanModeliAdi { get; set; }

        public int? FiyatBilgisi1 { get; set; }

        public int? FiyatBilgisi2 { get; set; }

        public int ElemanId { get; set; }

        public ElemanClass? Eleman { get; set; }
        
        public List<AlanClass>? AlanListe { get; set; }

    }
}
