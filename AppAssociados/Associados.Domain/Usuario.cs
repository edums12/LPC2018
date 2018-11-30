using System.ComponentModel.DataAnnotations;

namespace Associados.Domain
{
    public class Usuario
    {
        [Required(ErrorMessage = "ID é obrigatório")]
        public int id { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório")]
        [MinLength(8, ErrorMessage = "Tamanho mínimo para usuário é 8")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(4, ErrorMessage = "Tamanho mínimo para senha é 4")]
        public string senha {
            get => senha;
            set => System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
            
        }

        public Usuario(){}        
    }
}