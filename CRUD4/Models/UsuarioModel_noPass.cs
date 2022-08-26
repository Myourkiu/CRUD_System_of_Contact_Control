using CRUD4.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRUD4.Models
{
    public class UsuarioModel_noPass
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Insira seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira seu login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Seu email precisa estar da seguinte forma: email@gmail.com")]
        [EmailAddress(ErrorMessage = "Insira um email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário!")]
        public PerfilEnum? Perfil { get; set; }
    }
}
