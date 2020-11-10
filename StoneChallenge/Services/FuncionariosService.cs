using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Services
{
    public static class FuncionariosService
    {
        private static decimal _salarioMinimo = new Decimal(1000.00);


        private static int CalcularPesoPorTempoDeAdmissao(Funcionario funcionario)
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

        private static int CalcularPesoPorAreaDeAtuacao(Funcionario funcionario)
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

        private static int CalcularPesoPorFaixaSalarial(Funcionario funcionario, decimal salarioMinimo)
        {
            if (funcionario.SalarioBruto > (new Decimal(8.0) * salarioMinimo))
                return 5;
            else if (funcionario.SalarioBruto >= (new Decimal(5.0) * salarioMinimo) && funcionario.SalarioBruto < (new Decimal(8.0) * salarioMinimo))
                return 3;
            else if (funcionario.SalarioBruto >= (new Decimal(3.0) * salarioMinimo) && funcionario.SalarioBruto < (new Decimal(5.0) * salarioMinimo))
                return 2;
            else
                return 1;
        }

        public static ParticipacaoDTO CalculatarBonus(IEnumerable<Funcionario> funcionarios, decimal bonusDisponivel)
        {
            decimal bonusTotal = new Decimal(0.0);
            List <FuncionarioDTO> listaDeFuncionarios = new List<FuncionarioDTO>();

            foreach (var funcionario in funcionarios)
            {
                int pta = CalcularPesoPorTempoDeAdmissao(funcionario);
                int paa = CalcularPesoPorAreaDeAtuacao(funcionario);
                int pfs = CalcularPesoPorFaixaSalarial(funcionario, _salarioMinimo);

                decimal bonusDoFuncionario = (12 * funcionario.SalarioBruto * (pta + paa)) / pfs;
                bonusTotal += bonusDoFuncionario;

                listaDeFuncionarios.Add(new FuncionarioDTO
                {
                    Matricula = funcionario.Id,
                    Nome = funcionario.Nome,
                    ValorDaParticipacao = bonusDoFuncionario
                });
            }
            return new ParticipacaoDTO
            {
                Participacoes = listaDeFuncionarios,
                Total_de_funcionarios = listaDeFuncionarios.Count,
                Total_distribuido = bonusTotal,
                Total_disponibilizado = bonusDisponivel,
                Saldo_total_disponibilizado = bonusDisponivel - bonusTotal
            };
        }
    }
}
