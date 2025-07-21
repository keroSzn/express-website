namespace express_website.Models
{
    public class HomePageViewModel
    {
        public HakkimizdaClass Hakkimizda { get; set; } = new(); // boş listeyle başlat
        public List<ProjeClass> Projeler { get; set; } = new();         // boş listeyle başlat
        public List<BlogClass> Blog { get; set; } = new();             // boş listeyle başlat
        public List<ReferansClass> Referanslar { get; set; } = new();   // boş listeyle başlat
    }
}