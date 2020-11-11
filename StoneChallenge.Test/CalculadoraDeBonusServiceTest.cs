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
        [Fact]
        public void CalculadoraDePesoPorTempoDeAdmissaoServiceTest()
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
            var funcionarioComMaisDeUmAnoEMenosDeTres = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Financeiro,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddYears(-2)
            };

            Assert.Equal(2, _calculadora.Calcular(funcionarioComMaisDeUmAnoEMenosDeTres));

            // Peso 3: Acima de 3 anos e menos de 8 anos;
            var funcionarioComMaisDeTresAnosEMenosDeOito = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Financeiro,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddYears(-5)
            };

            Assert.Equal(3, _calculadora.Calcular(funcionarioComMaisDeTresAnosEMenosDeOito));

            // Peso 5: Mais de 8 anos
            var funcionarioComMaisDeOitoAnos = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Financeiro,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddYears(-9)
            };

            Assert.Equal(5, _calculadora.Calcular(funcionarioComMaisDeOitoAnos));
        }

        [Fact]
        public void CalculadoraDePesoPorAreaDeAtuacaoServiceTest()
        {
            var _calculadora = new CalculadoraDePesoPorAreaDeAtuacaoService();

            // Peso 1: Diretoria;
            var funcionarioDaDiretoria = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Diretoria,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddMonths(-3)
            };

            Assert.Equal(1, _calculadora.Calcular(funcionarioDaDiretoria));

            // Peso 2: Contabilidade, Financeiro, Tecnologia;
            var funcionarioDaContabilidade = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Contabilidade,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddMonths(-3)
            };

            Assert.Equal(2, _calculadora.Calcular(funcionarioDaContabilidade));

            var funcionarioDoFinanceito = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Financeiro,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddMonths(-3)
            };

            Assert.Equal(2, _calculadora.Calcular(funcionarioDoFinanceito));

            var funcionarioDaTecnologia = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.Tecnologia,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddMonths(-3)
            };

            Assert.Equal(2, _calculadora.Calcular(funcionarioDaTecnologia));


            // Peso 3: Serviços Gerais;
            var funcionarioDeServicosGerais = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.ServicosGerais,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddMonths(-3)
            };

            Assert.Equal(3, _calculadora.Calcular(funcionarioDeServicosGerais));

            // Peso 5: Relacionamento com o Cliente;
            var funcionarioDeRelacionamentoComOCliente = new Funcionario
            {
                Id = 9999001,
                Nome = "Alberto",
                Cargo = "Dummy",
                Departamento = Departamento.RelacionamentoComOCliente,
                SalarioBruto = new decimal(2000.00),
                DataDeAdmissao = DateTime.Now.AddMonths(-3)
            };

            Assert.Equal(5, _calculadora.Calcular(funcionarioDeRelacionamentoComOCliente));
        }
    }
}
