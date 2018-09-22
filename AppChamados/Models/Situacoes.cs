using System.Collections.Generic;

namespace AppChamados.Models
{
    public class Situacoes
    {
        public Situacoes(int? id, string descricao)
        {
            this.id = id;

            this.descricao = descricao;
        }

        public Situacoes(Situacoes pSituacao) 
        :this(pSituacao.id, pSituacao.descricao){}

        public Situacoes() {}

        public int? id { get; set; }

        public string descricao { get; set; }

        public List<Chamados> chamados {get; set;}

        public Situacoes Clone()
        {
            return this;
        }
    }
}