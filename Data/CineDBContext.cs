using CineApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CineApp.Data
{
    public class CineDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = CRISTIAN\\SQLEXPRESS;" +
                "Initial Catalog = CineDB; " +
                "Integrated Security = true; " +
                "encrypt = true; TrustServerCertificate = true");
        }

        public CineDBContext(DbContextOptions<CineDBContext> options) : base(options)
        {
        }

        public CineDBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        
            modelBuilder.Entity<Usuario>().HasKey(cv => new { cv.IdUsuario });

       
        }
        //aca poner las listas que va a usar la bd
      


    }
}
