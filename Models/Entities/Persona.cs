using System.ComponentModel.DataAnnotations;
namespace CineApp.Models.Entities
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Contraseña { get; set; }
    }
}
