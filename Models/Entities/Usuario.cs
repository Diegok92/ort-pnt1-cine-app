using System.ComponentModel.DataAnnotations;

namespace CineApp.Models.Entities
{
    public class Usuario 

    {
        [Key] public int IdUsuario { get; set; }
        [StringLength(30)] public required string Email { get; set; }
        [StringLength(30)] public required string Contraseña { get; set; }
     
        public Boolean mismoEmail(string email)
        {
            return this.Email.Equals(email);
        }
        public Boolean mismaContraseña(string contrase)
        {
            return this.Contraseña.Equals(contrase);
        }
    }
}
