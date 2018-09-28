using System.Collections.Generic;

namespace AppG1.Models
{
    public class Convenio
    {
        public int id { get; set; }

        public string codigo { get; set; }

        public string descricao { get; set; }

        public List<Paciente> pacientes { get; set; }

        public Convenio(){}
        
        public Convenio(Convenio pConvenio)
        {
            id = pConvenio.id;

            codigo = pConvenio.codigo;

            descricao = pConvenio.descricao;

            pacientes = pConvenio.pacientes;
        }

        public Convenio Clone()
        {
            return this;
        }


    }
}