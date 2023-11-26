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
            return $"{IdFuncion} - {NombrePelicula} - Butacas disponibles: " + cantButacasDisponibles()+ $" - {Dia} - {Horario}hs";
        }

        public int cantButacasDisponibles()
        {
            return ButacasTotales - ButacasVendidas;

        }
        public Boolean mismoNombrePelicula(string nombre)
        {
            return NombrePelicula.Equals(nombre);
        }
        public void venderEntradas(int cant)  {   this.ButacasVendidas += cant;  }

        public Boolean quedanEntradasSuficientes(int cant) { return this.cantButacasDisponibles()>=cant; }
    }

       
}
