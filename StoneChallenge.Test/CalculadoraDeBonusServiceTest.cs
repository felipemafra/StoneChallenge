using StoneChallenge.Data.Fake;
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
        [Theory]
        [ClassData(typeof(TempoDeAdmissaoFakeData))]
        public void A_CalculadoraDePesoPorTempoDeAdmissao_Deve_Retornar_O_Peso_Correto(Funcionario funcionario, int resultadoEsperado)
        {
            var _calculadora = new CalculadoraDePesoPorTempoDeAdmissaoService();

            Assert.Equal(resultadoEsperado, _calculadora.Calcular(funcionario));
        }

        [Theory]
        [ClassData(typeof(AreaDeAtuacaoFakeData))]
        public void A_CalculadoraDePesoPorAreaDeAtuacaoServiceTest_Deve_Retornar_O_Peso_Correto(Funcionario funcionario, int resultadoEsperado)
        {
            var _calculadora = new CalculadoraDePesoPorAreaDeAtuacaoService();

            Assert.Equal(resultadoEsperado, _calculadora.Calcular(funcionario));
        }

        [Theory]
        [ClassData(typeof(FaixaSalarialFakeData))]
        public void A_CalculadoraDePesoPorFaixaSalarial_Deve_Retornar_O_Peso_Correto(Funcionario funcionario, decimal salarioMinimo, int resultadoEsperado)
        {
            var _calculadora = new CalculadoraDePesoPorFaixaSalarial();
            _calculadora.SalarioMinimo = salarioMinimo;

            Assert.Equal(resultadoEsperado, _calculadora.Calcular(funcionario));
        }
    }
}
