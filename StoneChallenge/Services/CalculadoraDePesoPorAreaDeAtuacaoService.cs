using StoneChallenge.Models;
using StoneChallenge.Models.Enums;

namespace StoneChallenge.Services
{
    public class CalculadoraDePesoPorAreaDeAtuacaoService : CalculadoraDePesoService
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
