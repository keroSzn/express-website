using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace express_website.Models
{
    // DbContext yerine IdentityDbContext kullanacağız
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HakkimizdaClass> Hakkimizda { get; set; }
        public DbSet<KategoriClass> Kategori { get; set; }
        public DbSet<BaslikClass> Baslik { get; set; }
        public DbSet<AltBaslikClass> AltBaslik { get; set; }
        public DbSet<ElemanClass> Eleman { get; set; }
        public DbSet<ElemanModeliClass> ElemanModeli { get; set; }
        public DbSet<AlanClass> Alan { get; set; }
        public DbSet<HucreClass> Hucre { get; set; }
        public DbSet<ReferansClass> Referans { get; set; }
        public DbSet<ProjeClass> Proje { get; set; }
        public DbSet<BlogClass> Blog { get; set; }
        public DbSet<IletisimClass> Iletisim { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Identity tablolarını eklemesi için

            modelBuilder.Entity<KategoriClass>().HasKey(x => x.KategoriId);
            modelBuilder.Entity<HakkimizdaClass>().HasKey(x => x.HakkimizdaId);
            modelBuilder.Entity<BaslikClass>().HasKey(x => x.BaslikId);
            modelBuilder.Entity<AltBaslikClass>().HasKey(x => x.AltBaslikId);
            modelBuilder.Entity<ElemanClass>().HasKey(x => x.ElemanId);
            modelBuilder.Entity<ElemanModeliClass>().HasKey(x => x.ElemanModeliId);
            modelBuilder.Entity<AlanClass>().HasKey(x => x.AlanId);
            modelBuilder.Entity<HucreClass>().HasKey(x => x.HucreId);
            modelBuilder.Entity<ReferansClass>().HasKey(x => x.ReferansId);
            modelBuilder.Entity<ProjeClass>().HasKey(x => x.ProjeId);
            modelBuilder.Entity<BlogClass>().HasKey(x => x.BlogId);
            modelBuilder.Entity<IletisimClass>().HasKey(x => x.IletisimId);
        }
    }
}