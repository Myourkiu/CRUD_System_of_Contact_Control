using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD4.Models
{
    public class ContatoModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Insira seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Seu email precisa estar da seguinte forma: email@gmail.com")]
        [EmailAddress(ErrorMessage ="Insira um email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Seu número precisa estar da seguinte forma: xx xxxxx-xxxx")]
        [Phone(ErrorMessage ="Insira um número de celular válido!")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Seu número precisa estar da seguinte forma: xx xxxxx-xxxx")]
        public string Celular { get; set; }
    }
}
