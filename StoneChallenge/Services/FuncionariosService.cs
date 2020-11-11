using StoneChallenge.Models;
using StoneChallenge.Models.Enums;
using StoneChallenge.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Services
{
    public class FuncionariosService : IFuncionariosService
    {
        public ICalculadoraDePesoService Paa { get; set; }
        public ICalculadoraDePesoService Pta { get; set; }
        public ICalculadoraDePesoService Pfs { get; set; }

        public ParticipacaoDTO CalculatarBonus(IEnumerable<Funcionario> funcionarios, decimal bonusDisponivel)
        {
            decimal bonusTotal = new Decimal(0.0);
            List <FuncionarioDTO> listaDeFuncionarios = new List<FuncionarioDTO>();

            foreach (var funcionario in funcionarios)
            {
                Paa = new CalculadoraDePesoPorAreaDeAtuacaoService();
                Pta = new CalculadoraDePesoPorTempoDeAdmissaoService();
                Pfs = new CalculadoraDePesoPorFaixaSalarial();

                decimal bonusDoFuncionario = (12 * funcionario.SalarioBruto * (Pta.Calcular(funcionario) + Paa.Calcular(funcionario))) / Pfs.Calcular(funcionario);
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
