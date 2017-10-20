using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CryptoCenter.Domain
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Cpf { get; set; }
        [Display(Name = "Data de cadastro")]
        public DateTime DataCadastro { get; }
        public IEnumerable<Moeda> Moedas { get; set; }
        public IEnumerable<Investimento> Investimentos { get; set; }

    }
}
