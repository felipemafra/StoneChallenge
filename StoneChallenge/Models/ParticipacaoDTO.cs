using System.Collections.Generic;

namespace StoneChallenge.Models
{
    public class ParticipacaoDTO
    {
        public List<FuncionarioDTO> Participacoes { get; set; }
        public int Total_de_funcionarios { get; set; }
        public decimal Total_distribuido { get; set; }
        public decimal Total_disponibilizado { get; set; }
        public decimal Saldo_total_disponibilizado { get; set; }
    }
}
