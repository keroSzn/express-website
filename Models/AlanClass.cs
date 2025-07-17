namespace express_website.Models
{
    public class AlanClass
    {
        public int AlanId { get; set; }

        public string? AlanAdi { get; set; }

        public int ModelId { get; set; }

        public ElemanModeliClass? ElemanModeli { get; set; }
        
        public List<HucreClass>? HucreListe { get; set; }

    }
}
