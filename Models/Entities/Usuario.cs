using System.ComponentModel.DataAnnotations;

namespace CineApp.Models.Entities
{
    public class Usuario 

    {
        [Key] public required int IdUsuario { get; set; }
        [StringLength(30)] public required string Email { get; set; }
        [StringLength(30)] public required string Contraseña { get; set; }
        //public List<Reserva> ListaReservas { get; set; }  
        
    }
}
