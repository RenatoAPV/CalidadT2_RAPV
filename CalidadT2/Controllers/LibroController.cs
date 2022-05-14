using System;
using System.Linq;
using System.Security.Claims;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        //private readonly AppBibliotecaContext app;
        private AppBibliotecaContext app;
        public readonly ILibroRepositorio _libroRepositorio;

        public LibroController(ILibroRepositorio libroRepositorio, AppBibliotecaContext app)
        {
            _libroRepositorio = libroRepositorio;
            this.app = app;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _libroRepositorio.ObtenerDetallesLibro(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            app.Comentarios.Add(comentario);

            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
