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
    public class CalculadoraDeBonusService : ICalculadoraDeBonusService
    {
        private ICalculadoraDePesoService _calculadoraDePesoPorAreaDeAtuacaoService { get; set; }
        private  ICalculadoraDePesoService _calculadoraDePesoPorTempoDeAdmissaoService { get; set; }
        private  ICalculadoraDePesoService _calculadoraDePesoPorFaixaSalarial { get; set; }

        public CalculadoraDeBonusService(ICalculadoraDePesoService calculadoraDePesoPorAreaDeAtuacaoService, ICalculadoraDePesoService calculadoraDePesoPorTempoDeAdmissaoService, ICalculadoraDePesoService calculadoraDePesoPorFaixaSalarial)
        {
            _calculadoraDePesoPorAreaDeAtuacaoService = calculadoraDePesoPorAreaDeAtuacaoService;
            _calculadoraDePesoPorTempoDeAdmissaoService = calculadoraDePesoPorTempoDeAdmissaoService;
            _calculadoraDePesoPorFaixaSalarial = calculadoraDePesoPorFaixaSalarial;
        }

        public ParticipacaoDTO CalculatarBonus(IEnumerable<Funcionario> funcionarios, decimal bonusDisponivel)
        {
            decimal bonusTotal = new Decimal(0.0);
            List <FuncionarioDTO> listaDeFuncionarios = new List<FuncionarioDTO>();

            foreach (var funcionario in funcionarios)
            {
                decimal bonusDoFuncionario = (12 * funcionario.SalarioBruto * (_calculadoraDePesoPorTempoDeAdmissaoService.Calcular(funcionario) + _calculadoraDePesoPorAreaDeAtuacaoService.Calcular(funcionario))) / _calculadoraDePesoPorFaixaSalarial.Calcular(funcionario);
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
