using Associados.Domain;

namespace Associados.API.Controllers.DTOs
{
    public class DependenteDTO
    {
        public string nomeDependente { get; set; }

        public string nomeAssociado { get; set; }
        
        public DependenteDTO(Dependente dependente)
        {
            this.nomeDependente = dependente.nome;

            this.nomeAssociado = dependente.associado.nome;   
        }
    }
}