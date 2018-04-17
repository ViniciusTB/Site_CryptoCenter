using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CryptoCenter.Domain
{
    public class Moeda
    {
        [Key]
        public int MoedaId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public double Preco { get; set; }
        public double Saldo { get; set; }
        public double Saldo1 { get; set; }
    }
}
