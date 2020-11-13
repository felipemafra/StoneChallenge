using StoneChallenge.Models;
using System.Collections.Generic;

namespace StoneChallenge.Services.Interfaces
{
    public interface ICalculadoraDeBonusService
    {
        ParticipacaoDTO CalculatarBonus(IEnumerable<Funcionario> funcionarios, decimal bonusDisponivel);
    }
}
