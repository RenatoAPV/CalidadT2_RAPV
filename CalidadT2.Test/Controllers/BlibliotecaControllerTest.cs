using CalidadT2.Controllers;
using CalidadT2.Models;
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
    internal class BlibliotecaControllerTest
    {
        [Test]
        public void IndexBiblioteca()
        {
            var mockContext = new Mock<HttpContext>();
            var mockClamis = new Mock<ClaimsPrincipal>();
            var mockApp = new Mock<BibliotecaController>();
            //mockApp.
            mockClamis.Setup(x => x.Claims).Returns(new List<Claim>
            {
                new Claim (ClaimTypes.Name,"Renato")
            });
            mockContext.Setup(x => x.User).Returns(mockClamis.Object);
            var controller = new BibliotecaController(null);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            var view = controller.Index();
          

            Assert.IsNotNull(view);
        }
    }
}
