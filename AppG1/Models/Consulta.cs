using System;
using System.Collections.Generic;

namespace AppG1.Models
{
    public class Consulta
    {
        public int id { get; set; }

        public DateTime data { get; set; }

        public bool finalizado { get; set; }

        public int pacienteId { get; set; }

        public Paciente paciente { get; set; }

        public string resumo { get; set; }

        public bool revisao { get; set; }
        
        public decimal valor 
        {
            get
            {
                return valor;
            }
            set
            {
                if(paciente.particular)
                {
                    valor = value;
                }
                else
                {
                    valor = 0m;
                }
            }
        }

        public Consulta() {}

        public Consulta(Consulta pConsulta)
        {
            id = pConsulta.id;

            data = pConsulta.data;

            finalizado = pConsulta.finalizado;

            pacienteId = pConsulta.pacienteId;

            paciente = pConsulta.paciente;

            resumo = pConsulta.resumo;

            revisao = pConsulta.revisao;

            valor = pConsulta.valor;
        }

        public Consulta Clone()
        {
            return this;
        }
        
    }
}