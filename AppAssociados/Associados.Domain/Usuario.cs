using System.ComponentModel.DataAnnotations;

namespace Associados.Domain
{
    public class Usuario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório")]
        [MinLength(8, ErrorMessage = "Tamanho mínimo para usuário é de 8 dígitos")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(4, ErrorMessage = "Tamanho mínimo para senha é de 4 dígitos")]
        public string senha { get; set; }

        public Usuario(){}
    }
}