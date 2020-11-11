using StoneChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Services
{
    public class CalculadoraDePesoPorFaixaSalarial : CalculadoraDePesoService
    {
        public decimal SalarioMinimo { get; set; }

        public CalculadoraDePesoPorFaixaSalarial()
        {
            SalarioMinimo = new decimal(1000);
        }

        public override int Calcular(Funcionario funcionario)
        {
            if (funcionario.SalarioBruto > (new Decimal(8.0) * SalarioMinimo))
                return 5;
            else if (funcionario.SalarioBruto >= (new Decimal(5.0) * SalarioMinimo) && funcionario.SalarioBruto < (new Decimal(8.0) * SalarioMinimo))
                return 3;
            else if (funcionario.SalarioBruto >= (new Decimal(3.0) * SalarioMinimo) && funcionario.SalarioBruto < (new Decimal(5.0) * SalarioMinimo))
                return 2;
            else
                return 1;
        }
    }
}
