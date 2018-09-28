using System;
using System.Collections.Generic;

namespace AppG1.Models
{
    public class Paciente
    {
        public int id { get; set; }

        public string nome { get; set; }

        public List<string> emails { get; set; }

        public List<string> telefones { get; set; }

        public DateTime data_nascimento { get; set; }

        public Convenio convenio 
        { 
            get
            {
                return convenio;
            } 
            set
            {
                if(value != null)
                {
                    particular = false;

                    convenio = value;
                }
            }
        }

        public bool particular
        {
            get
            {
                return particular;
            }
            set
            {
                if(value)
                {
                    convenio = null;

                    particular = true;
                }
            }
        }

        public List<Consulta> consultas { get; set; }

        public Paciente(){}

        public Paciente(Paciente pPaciente)
        {
            id = pPaciente.id;
        
            nome = pPaciente.nome;
        
            emails = pPaciente.emails;
        
            telefones = pPaciente.telefones;
        
            data_nascimento = pPaciente.data_nascimento;
        
            convenio = pPaciente.convenio;

            consultas = pPaciente.consultas;

            particular = pPaciente.particular;
        }

        public Paciente Clone()
        {
            return this;
        }
    }
}