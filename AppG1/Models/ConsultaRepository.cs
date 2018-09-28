using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppG1.Models
{
    public class ConsultaRepository : IConsultaRepository
    {
        private DataContext DataContextConsulta;

        public ConsultaRepository(DataContext dataContextConsulta)
        {
            this.DataContextConsulta = dataContextConsulta;
        }

        public void Create(Consulta consulta)
        {
            this.DataContextConsulta.Consulta.Add(consulta);

            this.Save();
        }

        public void Delete(int id)
        {
            this.DataContextConsulta.Consulta.Remove(this.Get(id));

            this.Save();
        }

        public List<Consulta> Get()
        {
            return this.DataContextConsulta.Consulta.Include(it => it.paciente).OrderByDescending(it => it.data).ToList();
        }

        public Consulta Get(int id)
        {
            if(id == 0)
                return this.Get().FirstOrDefault();

            return this.DataContextConsulta.Consulta.Include(it => it.paciente).ToList().Find(it => it.id == id);
        }

        public void Save()
        {
            this.DataContextConsulta.SaveChanges();
        }

        public void Update(Consulta novaConsulta)
        {
            Consulta consulta = this.Get(novaConsulta.id);

            consulta = novaConsulta.Clone();

            this.Save();
        }
    }
}