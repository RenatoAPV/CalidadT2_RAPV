using CalidadT2.Models;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public bool VerificarUsuario(string user, string password);
    }
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppBibliotecaContext app;
        public bool VerificarUsuario(string user, string password)
        {
            return app.Usuarios.Where(o => o.Username == user && o.Password == password).FirstOrDefault() != null;
        }
    }
}
