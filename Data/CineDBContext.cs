using CineApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CineApp.Data
{
    public class CineDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }

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
            modelBuilder.Entity<Usuario>().HasKey(cv => new { cv.IdUsuario });
            modelBuilder.Entity<Reserva>().HasKey(cv => new { cv.IdReserva });
            modelBuilder.Entity<Pelicula>().HasKey(cv => new { cv.IdPelicula });
            modelBuilder.Entity<Funcion>().HasKey(cv => new { cv.IdFuncion });

        }
        //aca poner las listas que va a usar la bd
      


    }
}
