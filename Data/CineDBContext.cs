using BiblotecaPnt.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CineApp.Data
{
    public class CineDBContext : DbContext
    {
        public CineDBContext(DbContextOptions options) : base(options)
        { 
        
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Butaca>().HasKey(cv => new { cv.idButaca });

            modelBuilder.Entity<Funcion>().HasKey(cv => new { cv.idFuncion });

            modelBuilder.Entity<Usuario>().HasKey(cv => new { cv.Id });

            modelBuilder.Entity<Pelicula>().HasKey(cv => new { cv.idPelicula });

            modelBuilder.Entity<Reserva>().HasKey(cv => new { cv.IdReserva });

            modelBuilder.Entity<Sala>().HasKey(cv => new { cv.idSala });

        }
        //aca poner las listas que va a usar la bd

        public DbSet<Butaca> Butacas { get; set; } 
        public DbSet<Funcion> Funciones { get; set; }    
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Reserva> Reservas { get; set;}
        public DbSet<Sala> Sala { get; set; }   


                

    }
}
