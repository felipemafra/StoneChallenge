using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Data.Fake
{
    public class AreaDeAtuacaoFakeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Teste de peso por área de atuação - Diretoria
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Diretoria,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                1 // O resultado do peso deve ser esse valor
            };

            // Teste de peso por área de atuação - Contabilidade
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Contabilidade,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                2 // O resultado do peso deve ser esse valor
           };

            // Teste de peso por área de atuação - Financeiro
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                2 // O resultado do peso deve ser esse valor
           };

            // Teste de peso por área de atuação - Serviços Gerais
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.ServicosGerais,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                3 // O resultado do peso deve ser esse valor
           };

            // Teste de peso por área de atuação - Relacionamento com o cliente
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.RelacionamentoComOCliente,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                5 // O resultado do peso deve ser esse valor
           };


        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
