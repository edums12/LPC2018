using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppChamados.Models {
    [Table("Chamados")]
    public class Chamados {
        public Chamados(int? id, string numero, int solicitanteId, string problema, DateTime dataSolucao, DateTime horaInicio, DateTime horaFim, int situacaoId)
        {
            this.id = id;

            this.numero = numero;
            
            this.solicitanteId = solicitanteId;

            this.problema = problema;

            this.dataSolucao = dataSolucao;

            this.horaInicio = horaInicio;

            this.horaFim = horaFim;

            this.situacaoId = situacaoId;

        }

        public Chamados(){}

        public Chamados(Chamados pChamado)
        : this(pChamado.id, pChamado.numero, pChamado.solicitanteId, pChamado.problema, pChamado.dataSolucao, pChamado.horaInicio, pChamado.horaFim, pChamado.situacaoId)
        {
        
        }

        public int? id { get; set; }

        public string numero { get; set; }

        public int solicitanteId { get; set; }

        public Solicitante solicitante { get; set; }
        
        public int situacaoId { get; set; }

        public Situacoes situacao { get; set; }

        public string problema { get; set; }

        public DateTime dataSolucao { get; set; }

        [NotMapped]
        public string dataSolucaoDisplay{
            get {
                return this.dataSolucao.ToString("yyyy-MM-ddTHH:mm");
            }
        }

        public DateTime horaInicio { get; set; }

        [NotMapped]
        public string horaInicioDisplay{
            get {
                return this.horaInicio.ToString("yyyy-MM-ddTHH:mm");
            }
        }

        public DateTime horaFim { get; set; }

        [NotMapped]
        public string horaFimDisplay{
            get {
                return this.horaFim.ToString("yyyy-MM-ddTHH:mm");
            }
        }

        [NotMapped]
        public double totalHorasAtendimento { get; set; }

        public Chamados Clone()
        {
            return this;
        }
    }
}