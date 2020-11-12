using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Data.Fake
{
    public static class FuncionariosMockData
    {
        public static IEnumerable<Funcionario> GetTestFuncionarioItems()
        {
            var _funcionarios = new List<Funcionario>()
            {
                new Funcionario()
                {
                    Id = 9968,
                    Nome = "Victor Wilson",
                    Departamento = Departamento.Diretoria,
                    Cargo = "Diretor Financeiro",
                    SalarioBruto = new decimal(12696.20),
                    DataDeAdmissao = new DateTime(2012, 01, 05)
                },
                new Funcionario()
                {
                     Id = 4468,
                     Nome = "Flossie Wilson",
                     Departamento = Departamento.Contabilidade,
                     Cargo = "Auxiliar de Contabilidade",
                     SalarioBruto =  new decimal(1396.52),
                     DataDeAdmissao =  new DateTime(2015, 01, 05)
                },
                new Funcionario()
                {
                    Id = 8174,
                    Nome = "Sherman Hodges",
                    Departamento = Departamento.RelacionamentoComOCliente,
                    Cargo = "Líder de Relacionamento",
                    SalarioBruto =  new decimal(3899.74),
                    DataDeAdmissao =  new DateTime(2015, 06, 07)
                },
                new Funcionario()
                {
                    Id = 7463,
                    Nome = "Charlotte Romero",
                    Departamento = Departamento.Financeiro,
                    Cargo = "Contador Pleno",
                    SalarioBruto =  new decimal(3199.82),
                    DataDeAdmissao =  new DateTime(2018, 01, 03)
 },
            };

            return _funcionarios;
        }
    }
}
