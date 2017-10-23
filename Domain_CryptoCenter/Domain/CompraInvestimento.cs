using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CryptoCenter.Domain
{
    public class CompraInvestimento
    {
        [Display(Name ="Investimento")]
        public int CompraInvestimentoId { get; set; }
        [Display(Name ="Data da compra")]
        public DateTime DataCompra { get; set; }
        public int Quantidade { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int InvestimentoId { get; set; }
        public virtual Investimento Investimento { get; set; }
    }
}
