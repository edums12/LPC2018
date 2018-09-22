using System.Collections.Generic;

namespace AppChamados.Models
{
    public class Solicitante
    {
        public Solicitante(int? id, string nome, string email, string telefone)
        {
            this.id = id;

            this.nome = nome;

            this.email = email;

            this.telefone = telefone;
        }

        public Solicitante(Solicitante pSolicitante)
        : this(pSolicitante.id, pSolicitante.nome, pSolicitante.email, pSolicitante.telefone)
        {

        }

        public Solicitante(){}

        public int? id { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public List<Chamados> chamados { get; set; }

        public Solicitante Clone()
        {
            return this;
        }

    }
}