using System.ComponentModel.DataAnnotations;

namespace Money.Core.Requests.Account
{
    public class LoginRequest : Request
    {
        [Required(ErrorMessage = "E-mail inválido. Seu preenchimento é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha inválida. Seu preenchimento é obrigatório.")]
        public string Password { get; set; } = string.Empty;
    }
}
