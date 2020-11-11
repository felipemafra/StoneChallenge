using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using StoneChallenge.Services;
using StoneChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoneChallenge.Test
{
    public class CalculadoraDeBonusServiceTest
    {
        //private ICalculadoraDePesoService _calculadoraDePesoPorAreaDeAtuacaoService;
        //private ICalculadoraDePesoService _calculadoraDePesoPorTempoDeAdmissaoService;
        //private ICalculadoraDePesoService _calculadoraDePesoPorFaixaSalarial;
        //private ICalculadoraDeBonusService _calculadoraDeBonusService;

        //public CalculadoraDeBonusServiceTest()
        //{
        //    _calculadoraDePesoPorAreaDeAtuacaoService = new CalculadoraDePesoPorAreaDeAtuacaoService();
        //    _calculadoraDePesoPorTempoDeAdmissaoService = new CalculadoraDePesoPorTempoDeAdmissaoService();
        //    _calculadoraDePesoPorFaixaSalarial = new CalculadoraDePesoPorFaixaSalarial();
        //    _calculadoraDeBonusService = new CalculadoraDeBonusService(_calculadoraDePesoPorAreaDeAtuacaoService, _calculadoraDePesoPorTempoDeAdmissaoService, _calculadoraDePesoPorFaixaSalarial);
        //}

        [Fact]
        public void CalculadoraDePesoPorTempoDeAdmissaoService()
        {
            var _calculadora = new CalculadoraDePesoPorTempoDeAdmissaoService();

            // Peso 1: Até 1 ano de casa;
            var funcionarioComMenosDeUmAno = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Financeiro,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddMonths(-3)
            };

            Assert.Equal(1, _calculadora.Calcular(funcionarioComMenosDeUmAno));
            // Peso 2: Mais de 1 ano e menos de 3 anos;
            // Peso 3: Acima de 3 anos e menos de 8 anos;
            // Peso 5: Mais de 8 anos
        }
    }
}
