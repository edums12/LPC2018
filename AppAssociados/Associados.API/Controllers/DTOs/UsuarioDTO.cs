using Associados.Domain;

namespace Associados.API.Controllers.DTOs
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        
        public string nome { get; set; }

        public UsuarioDTO(Usuario usuarioCompleto)
        {
            this.id = usuarioCompleto.id;
            
            this.nome = usuarioCompleto.usuario;
        }
    }
}