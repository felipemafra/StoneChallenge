using StoneChallenge.Models;
using StoneChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Services
{
    public abstract class CalculadoraDePesoService : ICalculadoraDePesoService
    {
        public abstract int Calcular(Funcionario funcionario);
    }
}
