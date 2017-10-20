using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CryptoCenter.Domain
{
    public class CompraInvestimento
    {
        public int CompraInvestimentoId { get; set; }
        public DateTime DataCompra { get; set; }
        public int Quantidade { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int InvestimentoId { get; set; }
        public virtual Investimento Investimento { get; set; }
    }
}
