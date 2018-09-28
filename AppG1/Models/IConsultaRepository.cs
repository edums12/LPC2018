using System.Collections.Generic;

namespace AppG1.Models
{
    public interface IConsultaRepository
    {
        void Create(Consulta consulta);

        void Update(Consulta novaConsulta);

        void Delete(int id);

        List<Consulta> Get();

        Consulta Get(int id);

        void Save();
    }
}