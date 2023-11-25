using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace CineApp.Models.Entities
{
    public class Pelicula
    {
        [Key]
        public int IdPelicula { get; set; }

        [StringLength(50)]
        public string NombrePelicula { get; set; }
        public double DuracionEnMin { get; set; }
        public string Descripcion { get; set; }


        public override string ToString()
        {
            return $"{NombrePelicula}";
        }



    }
}
