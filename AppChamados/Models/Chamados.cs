using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppChamados.Models {
    public class Chamados {
        public Chamados(int? id, string numero, DateTime data, string nome, string telefone, string email, string problema, DateTime dataSolucao, DateTime horaInicio, DateTime horaFim)
        {
            this.id = id;

            this.numero = numero;

            this.data = data;

            this.nome = nome;

            this.telefone = telefone;

            this.email = email;

            this.problema = problema;

            this.dataSolucao = dataSolucao;

            this.horaInicio = horaInicio;

            this.horaFim = horaFim;

        }

        public Chamados(Chamados pChamado)
        {
            this.id = pChamado.id;
            
            this.numero = pChamado.numero;
            
            this.data = pChamado.data;
            
            this.nome = pChamado.nome;
            
            this.telefone = pChamado.telefone;
            
            this.email = pChamado.email;
            
            this.problema = pChamado.problema;
            
            this.dataSolucao = pChamado.dataSolucao;
            
            this.horaInicio = pChamado.horaInicio;
            
            this.horaFim = pChamado.horaFim;
            
        }

        public int? id { get; set; }

        public string numero { get; set; }

        public DateTime data { get; set; }

        [NotMapped]
        public string dataDisplay{
            get {
                return this.data.ToString("yyyy-MM-dd");
            }
        }

        public string nome { get; set; }

        public string telefone { get; set; }

        public string email { get; set; }

        public string problema { get; set; }

        public DateTime dataSolucao { get; set; }

        [NotMapped]
        public string dataSolucaoDisplay{
            get {
                return this.dataSolucao.ToString("yyyy-MM-dd");
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