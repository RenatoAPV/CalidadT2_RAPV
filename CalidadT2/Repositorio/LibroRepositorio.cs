using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface ILibroRepositorio
    {
        Libro ObtenerDetallesLibro(int id);
    }
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly AppBibliotecaContext app;

        public LibroRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }
        public Libro ObtenerDetallesLibro(int id)
        {
            return app.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }
    }
}
