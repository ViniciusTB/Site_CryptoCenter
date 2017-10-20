using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CryptoCenter.Domain
{
    public class Investimento
    {
        [Key]
        public int InvestimentoId { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public double Valor { get; set; }
        public int QuantidadeVendida { get; set; }
    }
}
