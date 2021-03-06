using Microsoft.AspNetCore.Mvc;
using Moq;
using StoneChallenge.Controllers;
using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using StoneChallenge.Models.Repository.IRepository;
using StoneChallenge.Services;
using StoneChallenge.Services.Interfaces;
using StoneChallenge.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StoneChallenge.Test
{
    public class FuncionariosControllerTest
    {
        private ICalculadoraDePesoService _calculadoraDePesoPorAreaDeAtuacaoService;
        private ICalculadoraDePesoService _calculadoraDePesoPorTempoDeAdmissaoService;
        private ICalculadoraDePesoService _calculadoraDePesoPorFaixaSalarial;
        private ICalculadoraDeBonusService _calculadoraDeBonusService;

        //public FuncionariosControllerTest(ICalculadoraDePesoService calculadoraDePesoPorAreaDeAtuacaoService, ICalculadoraDePesoService calculadoraDePesoPorTempoDeAdmissaoService, ICalculadoraDePesoService calculadoraDePesoPorFaixaSalarial)
        public FuncionariosControllerTest()
        {
            _calculadoraDePesoPorAreaDeAtuacaoService = new CalculadoraDePesoPorAreaDeAtuacaoService();
            _calculadoraDePesoPorTempoDeAdmissaoService = new CalculadoraDePesoPorTempoDeAdmissaoService();
            _calculadoraDePesoPorFaixaSalarial = new CalculadoraDePesoPorFaixaSalarial();
            _calculadoraDeBonusService = new CalculadoraDeBonusService(_calculadoraDePesoPorAreaDeAtuacaoService, _calculadoraDePesoPorTempoDeAdmissaoService, _calculadoraDePesoPorFaixaSalarial);
        }

        [Fact]
        public void Index_Deve_Retornar_Todos_Os_Funcionarios()
        {
            var mock = new Mock<IUnitOfWork>();
            var controller = new FuncionariosController(mock.Object, _calculadoraDeBonusService);
            mock.Setup(s => s.Funcionario.GetAll(null, null, null)).Returns(FuncionariosMockData.GetTestFuncionarioItems());
            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewResultValue = Assert.IsAssignableFrom<List<Funcionario>>(viewResult.ViewData.Model);
            Assert.Equal(4, viewResultValue.Count);
            mock.Verify();
        }

        [Theory]
        [InlineData(0009968, 0000000)]
        public void Details_Deve_Retornar_Um_Funcionario_Dado_Um_id(int validId, int invalidId)
        {
            var mock = new Mock<IUnitOfWork>();
            FuncionariosController controller = new FuncionariosController(mock.Object, _calculadoraDeBonusService);

            #region valid id
            mock.Setup<Funcionario>(s => s.Funcionario.GetById(validId)).Returns(FuncionariosMockData.GetTestFuncionarioItems().FirstOrDefault(n => n.Id == validId));

            var result = controller.Details(validId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewResultValue = Assert.IsAssignableFrom<Funcionario>(viewResult.ViewData.Model);

            Assert.Equal("Victor Wilson", viewResultValue.Nome);
            Assert.Equal(Departamento.Diretoria, viewResultValue.Departamento);
            Assert.Equal("Diretor Financeiro", viewResultValue.Cargo);
            Assert.Equal(new decimal(12696.20), viewResultValue.SalarioBruto);
            Assert.Equal(new DateTime(2012, 01, 05), viewResultValue.DataDeAdmissao);
            #endregion

            #region invalid id
            mock.Setup(s => s.Funcionario.GetById(invalidId)).Returns(FuncionariosMockData.GetTestFuncionarioItems().FirstOrDefault(n => n.Id == invalidId));
            var notFoundResult = controller.Details(invalidId);

            Assert.IsType<NotFoundResult>(notFoundResult);
            #endregion
            mock.Verify();
        }

        [Theory]
        [ClassData(typeof(CreateUnitTestFakeData))]
        public void CreateUnitTest_Deve_Permitir_Apenas_A_Criacao_De_Um_Funcionario_Valido(Funcionario funcionario, bool valido)
        {
            // arrange
            var mock = new Mock<IUnitOfWork>();
            FuncionariosController controller = new FuncionariosController(mock.Object, _calculadoraDeBonusService);
            mock.Setup(s => s.Funcionario.Insert(funcionario)).Verifiable();

            // assert
            if (valido)
            {
                // act
                var result = controller.Create(funcionario);

                // assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal(nameof(FuncionariosController.Index), redirectToActionResult.ActionName);
                Assert.Null(redirectToActionResult.ControllerName);
                mock.VerifyAll();
            }
            else
            {
                // act
                controller.ModelState.AddModelError("Parametros", "Falta um dos parametros para a criacao do funcionario");
                var result = controller.Create(funcionario);

                var viewResult = Assert.IsType<ViewResult>(result);
                var viewResultValue = Assert.IsAssignableFrom<Funcionario>(viewResult.ViewData.Model);
            }
        }
    }
}
