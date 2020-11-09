using StoneChallenge.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Models
{
    public class Funcionario
    {
        [Key]
        [DisplayFormat(DataFormatString = "{0:D7}")]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Area")]
        public Departmento Departamento { get; set; }
        public string Cargo { get; set; }

        [Display(Name = "Salário Bruto")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalarioBruto { get; set; }

        [Display(Name = "Data de Adimissão"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeAdmissao { get; set; }
    }
}
