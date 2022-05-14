using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2.Test.Controllers
{
    internal class AuthControllerTest
    {
        [Test]
        public void Login()
        {
            var controller = new AuthController(null);
            var view = controller.Login() as ViewResult;
            Assert.IsNotNull(view);
        }


        [Test]

        public void LoginOk()
        {
            
            var mockIUsuarioRepositorio = new Mock<IUsuarioRepositorio>();
            var controller = new AuthController(mockIUsuarioRepositorio.Object,null);
            var view = controller.Login("admin","123456");

            Assert.IsNotNull(view);
            Assert.IsInstanceOf<ViewResult>(view);
             
        }
    }
}
