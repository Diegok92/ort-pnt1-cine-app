using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace CineApp.Models.Entities
{
    public class Funcion
    {
        [Key]
        public int idFuncion { get; set; }
        public int idPelicula { get;set; }
        public int idSala { get; set; }
        public int butacasVendidas {get;set; }
        public DiasDeLaSemana dia {  get; set; }
        public Turno horario { get; set; }

        public Sala sala { get; set; }

        public Pelicula pelicula { get; set; }
        public List<Butaca> listaButacas { get; set; }


    }
}
