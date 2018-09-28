using System.Collections.Generic;

namespace AppG1.Models
{
    public interface IConvenioRepository
    {
        void Create(Convenio convenio);

        void Update(Convenio novoConvenio);

        void Delete(int id);

        List<Convenio> Get();

        Convenio Get(int id);

        void Save();
    }
}