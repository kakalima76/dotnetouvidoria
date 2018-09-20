using System.ComponentModel.DataAnnotations;

namespace Rio.SMF.CCU.Ouvidoria.Dominio.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage="Informe um usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Informe uma senha")]
        [DataType("Password")]
        public string Password { get; set; }

             
        public string ConfirmPassword { get; set; }
        public string Status { get; set; }

    }

    public class UsuarioCadastro : Usuario {
        [DataType("Password")]
        [Compare("Password", ErrorMessage="Senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}