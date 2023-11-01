namespace BiblotecaPnt.Models.Entities
{
    public class Usuario : Persona
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public List<Reserva> ListaReservas { get; set; }
        
    }
}
