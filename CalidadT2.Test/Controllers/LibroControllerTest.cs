using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CalidadT2.Test.Controllers
{
    internal class LibroControllerTest
    {
        [Test]
        public void DetailsCase()
        {
            var mockLibro = new Mock<ILibroRepositorio>();
            var controller = new LibroController(mockLibro.Object, null);
            var view = controller.Details(1);

            Assert.IsNotNull(view);
        }

        [Test]
        public void AddComentarioCase()
        {
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>
            {
                new Claim (ClaimTypes.Name, "Renato")
            });
            var mockContext = new Mock<HttpContext>();
            mockContext.SetupGet(o => o.User).Returns(mockClaimsPrincipal.Object); ;
            var controller = new LibroController(null, null);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var view = controller.AddComentario(null);
           



            Assert.IsNotNull(view);
        }

    }
}
