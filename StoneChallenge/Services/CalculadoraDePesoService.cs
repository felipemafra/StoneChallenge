using StoneChallenge.Models;
using StoneChallenge.Services.Interfaces;

namespace StoneChallenge.Services
{
    public abstract class CalculadoraDePesoService : ICalculadoraDePesoService
    {
        public abstract int Calcular(Funcionario funcionario);
    }
}
