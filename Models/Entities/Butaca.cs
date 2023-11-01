using System.ComponentModel.DataAnnotations;
namespace BiblotecaPnt.Models.Entities
{
    public class Butaca
    {
        [Key]
        public int idButaca {get;set;} 
        public Boolean estaDisponible { get; set;}  

    }
}
