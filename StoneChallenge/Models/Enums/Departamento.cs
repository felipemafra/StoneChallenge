using System.ComponentModel.DataAnnotations;

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
