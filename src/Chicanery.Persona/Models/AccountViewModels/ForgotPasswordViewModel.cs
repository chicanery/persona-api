using System.ComponentModel.DataAnnotations;

namespace Chicanery.Persona.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ResetPasswordUrl { get; set; }
    }
}
