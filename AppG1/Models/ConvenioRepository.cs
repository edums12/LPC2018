using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppG1.Models
{
    public class ConvenioRepository : IConvenioRepository
    {
        private DataContext DataContextConvenio;

        public ConvenioRepository(DataContext dataContextConvenio)
        {
            this.DataContextConvenio = dataContextConvenio;
        }

        public void Create(Convenio convenio)
        {
            this.DataContextConvenio.Convenio.Add(convenio);

            this.Save();
        }

        public void Delete(int id)
        {
            this.DataContextConvenio.Convenio.Remove(this.Get(id));

            this.Save();
        }

        public List<Convenio> Get()
        {
            return this.DataContextConvenio.Convenio.Include(it => it.pacientes).OrderBy(it => it.descricao).ToList();
        }

        public Convenio Get(int id)
        {
            if(id == 0)
                return this.Get().FirstOrDefault();

            return this.DataContextConvenio.Convenio.Include(it => it.pacientes).ToList().Find(it => it.id == id);
        }

        public void Save()
        {
            this.DataContextConvenio.SaveChanges();
        }

        public void Update(Convenio novoConvenio)
        {
            Convenio convenio = this.Get(novoConvenio.id);

            convenio = novoConvenio.Clone();

            this.Save();
        }
    }
}