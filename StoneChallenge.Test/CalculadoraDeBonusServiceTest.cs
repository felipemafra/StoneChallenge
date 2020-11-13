using StoneChallenge.Models;
using StoneChallenge.Services;
using StoneChallenge.Test.Data;
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

        [Theory]
        [InlineData(1000.00, 1, 1, 1, 24000.00)]
        [InlineData(2000.00, 2, 1, 3, 24000.00)]
        [InlineData(1500.00, 3, 5, 5, 28800.00)]
        [InlineData(998.55, 3, 5, 3, 31953.60)]
        // (decimal salarioBruto, int pesoPorTempoDeAdmissao, int pesoPorAreaDeAtuacao, int pesoPorFaixaSalarial)
        public void O_Servico_De_Calcular_Bonus_Deve_Retornar_O_Valor_Correto(double salarioBruto, int pesoPorTempoDeAdmissao, int pesoPorAreaDeAtuacao, int pesoPorFaixaSalarial, double resultado)
        {
            // arrange
            decimal salario = new decimal(salarioBruto);
            decimal resultadoExperado = new decimal(resultado);

            // act 

            // assert
            Assert.Equal(resultadoExperado, CalculadoraDeBonusService.FormulaDeCalculo(salario, pesoPorTempoDeAdmissao, pesoPorAreaDeAtuacao, pesoPorFaixaSalarial));
        }
    }
}
