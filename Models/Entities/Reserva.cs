using System.ComponentModel.DataAnnotations;
namespace CineApp.Models.Entities
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
       
        public string EmailCliente { get; set; }
        public int IdFuncion { get; set; }
        public int CantidadEntradas { get; set; }


        public int ButacasVendidas { get; set; }
        public int ButacasTotales { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }


    }
}
