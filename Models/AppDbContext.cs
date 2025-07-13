using Microsoft.EntityFrameworkCore;

namespace express_website.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<HakkimizdaClass> Hakkimizda { get; set; }
        public DbSet<KategoriClass> Kategori { get; set; }
        public DbSet<BaslikClass> Baslik { get; set; }
        public DbSet<AltBaslikClass> AltBaslik { get; set; }
        public DbSet<ElemanClass> Eleman { get; set; }
        public DbSet<ElemanModeliClass> ElemanModeli { get; set; }
        public DbSet<AlanClass> Alan { get; set; }
        public DbSet<HucreClass> Hucre { get; set; }
        

    }
}