
using CineApp.Models.Entities;
using CineApp.Data;

namespace CineApp.Persistencia
{
    public class Usuario_Persistencia
    {
        CineDBContext context = new CineDBContext();

        public bool Create(Usuario usuario)
        {
            bool estado = false;

            if(usuario != null)
            {
                context.Usuarios.Add(usuario);
        
                context.SaveChanges();
                estado = true;
            }
            return estado;
        }
        public List<Usuario>?ReadAll()
        {
           return context.Usuarios.ToList();
        }
        public Usuario? ReadById(int id) 
        {
            return context.Usuarios.Find(id);
        }
        public bool Update(Usuario usuario)
        {
            bool estado=false;
            if(usuario != null)
            {
               context.Usuarios.Update(usuario);
               context.SaveChanges();
                estado = true;
            }
            return estado;
        }
        public bool Delete(int id)
        {
            bool estado=false;
            Usuario? usuario = ReadById(id);
            if(usuario != null) 
            { 
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                estado = true;
            }
            return estado;
        }

    }
}
