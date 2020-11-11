using StoneChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Services.Interfaces
{
    public interface ICalculadoraDeBonusService
    {
        ParticipacaoDTO CalculatarBonus(IEnumerable<Funcionario> funcionarios, decimal bonusDisponivel);
    }
}
