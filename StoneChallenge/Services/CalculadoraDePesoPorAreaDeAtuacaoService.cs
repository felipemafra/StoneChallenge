using StoneChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Services
{
    public class CalculadoraDePesoPorAreaDeAtuacaoService : CalculadoraDePesoService
    {
        public override int Calcular(Funcionario funcionario)
        {
            if (DateTime.Now.Year - funcionario.DataDeAdmissao.Year >= 8)
                return 5;
            else if (DateTime.Now.Year - funcionario.DataDeAdmissao.Year >= 3)
                return 3;
            else if (DateTime.Now.Year - funcionario.DataDeAdmissao.Year >= 1)
                return 2;
            else
                return 1;
        }
    }
}
