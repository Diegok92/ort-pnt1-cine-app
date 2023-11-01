using System.ComponentModel.DataAnnotations;
namespace BiblotecaPnt.Models.Entities
{
    public class Pelicula
    {
        [Key]
        public int idPelicula { get; set; }

        [StringLength(50)]
        public String nombre { get; set; }
        public double duracionEnMin { get; set; }
        public DateTime fechaEstreno { get; set; }
        
    }
}
