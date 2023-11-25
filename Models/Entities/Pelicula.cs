using System.ComponentModel.DataAnnotations;
namespace CineApp.Models.Entities
{
    public class Pelicula
    {
        [Key]
        public int IdPelicula { get; set; }

        [StringLength(50)]
        public String Nombre { get; set; }
        public double DuracionEnMin { get; set; }
        public DateTime FechaEstreno { get; set; }

        public String Descripcion { get; set; }
        
    }
}
