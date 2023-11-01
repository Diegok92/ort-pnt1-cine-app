using System.ComponentModel.DataAnnotations;
namespace BiblotecaPnt.Models.Entities
{
    public class Cine
    {
        public String Nombre = "CineApp";
        public List<Persona> ListaUsuarios { get; set; }
        public List<Reserva> ListaReservas {  get; set; }
        public List<Funcion> ListaFunciones { get; set; }



    }
}
