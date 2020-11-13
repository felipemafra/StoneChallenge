using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StoneChallenge.Test.Data
{
    class CreateUnitTestFakeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Funcionario válido
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

                true // Funcionario válido
           };

            // Funcionario inválido - sem nome
            yield return new object[]
           {
                new Funcionario
                {
                    Id = 9999001,
                    Cargo = "Dummy",
                    Departamento = Departamento.Diretoria,
                    SalarioBruto = new decimal(2000.00),
                    DataDeAdmissao = DateTime.Now.AddMonths(-3)
                },

                false // Funcionario válido
           };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
