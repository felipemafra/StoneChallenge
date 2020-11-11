using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Services
{
    public class CalculadoraDePesoPorTempoDeAdmissaoService : CalculadoraDePesoService
    {
        public override int Calcular(Funcionario funcionario)
        {
            switch (funcionario.Departamento)
            {
                case Departamento.Diretoria:
                    return 1;
                case Departamento.Contabilidade:
                case Departamento.Financeiro:
                case Departamento.Tecnologia:
                    return 2;
                case Departamento.ServicosGerais:
                    return 3;
                case Departamento.RelacionamentoComOCliente:
                    return 5;
                default:
                    return 0;
            }
        }
    }
}
