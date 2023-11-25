using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace CineApp.Models.Entities
{
    public class Funcion
    {
        [Key]
        public int IdFuncion { get; set; }
        public string NombrePelicula { get;set; }
        public int ButacasVendidas {get;set; }
        public int ButacasTotales { get; set; }
        public string Dia {  get; set; }
        public string Horario { get; set; }


        public override string ToString()
        {
            return $"{NombrePelicula} - Butacas disponibles: " + cantButacasDisponibles()+ $" {Dia} - {Horario}";
        }

        public int cantButacasDisponibles()
        {
            return ButacasTotales - ButacasVendidas;

        }

    }


}
