using Microsoft.AspNetCore.Mvc;
using Moq;
using StoneChallenge.Controllers;
using StoneChallenge.Data.Mock;
using StoneChallenge.Models;
using StoneChallenge.Models.Repository;
using StoneChallenge.Models.Repository.IRepository;
using System;
using System.Collections.Generic;
using Xunit;

namespace StoneChallenge.Test
{
    public class FuncionariosControllerTest
    {
        private FuncionariosController _controller;
        //private Mock<FuncionarioRepository> _mock = new Mock<FuncionarioRepository>();

        [Fact]
        public void IndexUnitTest()
        {
            var _mock = new Mock<IUnitOfWork>();
            _mock.Setup(s => s.Funcionario.GetAll(null, null, null)).Returns(FuncionariosMockData.GetTestFuncionarioItems());
            var controller = new FuncionariosController(_mock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewResultFuncionarios = Assert.IsAssignableFrom<List<Funcionario>>(viewResult.ViewData.Model);
            Assert.Equal(4, viewResultFuncionarios.Count);
        }
    }
}
