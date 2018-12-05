using System.Linq;
using Associados.Domain;

namespace Associados.API.Controllers.DTOs
{
    public class AssociadoDTO
    {
        public string nome { get; set; }

        public string cpf { get; set; }

        public string cidade { get; set; }

        public string uf { get; set; }

        public int quantidadeDependentes { get; set; }

        public AssociadoDTO(Associado associado)
        {
            this.nome = associado.nome;

            this.cpf = associado.cpf;

            this.cidade = associado.cidade;

            this.uf = associado.uf;

            if(associado.dependentes?.Any() ?? false)
                this.quantidadeDependentes = associado.dependentes.Count;
            else
                this.quantidadeDependentes = 0;
        }
    }
}