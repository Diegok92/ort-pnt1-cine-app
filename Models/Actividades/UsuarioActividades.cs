
using CineApp.Models.Entities;
using CineApp.Persistencia;

namespace CineApp.Models.Actividades
{
    public class UsuarioActividades
    {
        Usuario_Persistencia usuario_persistencia= new Usuario_Persistencia();

        public bool Create(Usuario usuario)
        {
            return usuario_persistencia.Create(usuario);
        }
        public bool Update(Usuario usuario)
        {
            return usuario_persistencia.Update(usuario);    
        }
        public List<Usuario>? ReadAll()
        {
            return usuario_persistencia.ReadAll();
        }
        public Usuario? ReadById(int id)
        {
            return usuario_persistencia.ReadById(id);
        }
        public bool Delete(int id)
        {
            return usuario_persistencia.Delete(id);
        }
    }
}
