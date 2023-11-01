using System.ComponentModel.DataAnnotations;
namespace BiblotecaPnt.Models.Entities
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
       
        public String EmailCliente { get; set; }
        public int IdFuncion { get; set; }
        public int CantidadEntradas { get; set; }
        public List<Butaca> ListaButacasElegidas { get; set; }

    }
}
