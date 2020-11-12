using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Data.Fake
{
    public class TempoDeAdmissaoFakeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Teste de peso por tempo de adimissão para funcionarios com menos de 1 ano.
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

                1 // O resultado do peso deve ser esse valor
            };

            // Teste de peso por tempo de adimissão para funcionarios com mais de 1 ano e menos de 3 anos. 
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddYears(-2)
                },

                2 // O resultado do peso deve ser esse valor
           };

            // Teste de peso por tempo de adimissão para funcionarios com mais de 3 anos e menos de 8 anos. 
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddYears(-5)
                },

                3 // O resultado do peso deve ser esse valor
            };

            // Teste de peso por tempo de adimissão para funcionarios com mais de 8 anos
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddYears(-9)
                },

                5 // O resultado do peso deve ser esse valor
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
