using System;
using System.ComponentModel.DataAnnotations;

namespace Domain_CryptoCenter.Domain
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        [Display(Name ="Data da publicação")]
        public DateTime? DataPost { get; set; }
        public bool Publicado { get; set; }
    }
}
