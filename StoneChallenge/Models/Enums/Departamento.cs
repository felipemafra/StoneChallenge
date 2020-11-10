using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Models.Enums
{
    public enum Departamento : byte
    {
        Diretoria = 1,
        Contabilidade = 2,
        Financeiro = 3,
        Tecnologia = 4,

        [Display(Name = "Serviços Gerais")]
        ServicosGerais = 5,

        [Display(Name = "Relacionamento com o Cliente")]
        RelacionamentoComOCliente = 6
    }
}
