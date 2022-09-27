using System.ComponentModel.DataAnnotations;

namespace Chapter.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe seu email.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe sua senha.")]
        public string senha { get; set; }
    }
}
