using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Data.Fake
{
    public class FaixaSalarialFakeData : IEnumerable<object[]>
    {
        private readonly decimal _salarioMinimo = new decimal(1000.00);
        public IEnumerator<object[]> GetEnumerator()
        {
            // Teste de peso por tempo de adimissão para funcionarios que ganham ate 3 salarios minimos.
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = _salarioMinimo * 2,
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                _salarioMinimo,

                1 // O resultado do peso deve ser esse valor
            };

            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = _salarioMinimo * 3,
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                _salarioMinimo,

                1 // O resultado do peso deve ser esse valor
            };

            // Teste de peso por tempo de adimissão para funcionarios que ganham acima de 3 salários mínimos e menos que 5 salários mínimos.
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = _salarioMinimo * 4,
                    DataDeAdmissao = DateTime.Now.AddMonths(-4)
                },

                _salarioMinimo,

                2 // O resultado do peso deve ser esse valor
            };

            // Teste de peso por tempo de adimissão para funcionarios que ganham acima de 5 salários mínimos e menos que 8 salários mínimos.
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = _salarioMinimo * 6,
                    DataDeAdmissao = DateTime.Now.AddMonths(-4)
                },

                _salarioMinimo,

                3 // O resultado do peso deve ser esse valor
            };

            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = _salarioMinimo * 8,
                    DataDeAdmissao = DateTime.Now.AddMonths(-4)
                },

                _salarioMinimo,

                3 // O resultado do peso deve ser esse valor
            };

            // Teste de peso por tempo de adimissão para funcionarios que ganham acima de 8 salários mínimos.
            yield return new object[]
            {
                new Funcionario
                {
                    Id = 9999001,
                    Nome = "Alberto",
                    Cargo = "Dummy",
                    Departamento = Departamento.Financeiro,
                    SalarioBruto = _salarioMinimo * 9,
                    DataDeAdmissao = DateTime.Now.AddMonths(-4)
                },

                _salarioMinimo,

                5 // O resultado do peso deve ser esse valor
            };



        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
