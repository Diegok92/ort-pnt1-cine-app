using System.ComponentModel.DataAnnotations;
namespace BiblotecaPnt.Models.Entities
{
    public class Sala
    {
        [Key]
        public int idSala { get; set; }
        public int capacidad { get; set; }

    }
}
