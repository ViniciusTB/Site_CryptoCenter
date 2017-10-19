using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CryptoCenter.Domain
{
    public class Transacao
    {
        [Key]
        public int TransacaoId { get; set; }
        public int UsuarioId { get; set; }
        [Display(Name ="Usuario")]
        public virtual Usuario Usuario { get; set; }
        public virtual Moeda Moeda { get; set; }
        public int MoedaId { get; set; }
        public DateTime DataTransacao { get; set; }
        public int Quantidade { get; set; }
    }
}
