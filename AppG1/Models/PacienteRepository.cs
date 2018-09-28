using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppG1.Models
{
    public class PacienteRepository : IPacienteRepository
    {
        private DataContext DataContextPaciente;

        public PacienteRepository(DataContext dataContextPaciente)
        {
            this.DataContextPaciente = dataContextPaciente;
        }

        public void Create(Paciente paciente)
        {
            this.DataContextPaciente.Paciente.Add(paciente);

            this.Save();
        }

        public void Delete(int id)
        {
            this.DataContextPaciente.Paciente.Remove(this.Get(id));

            this.Save();
        }

        public List<Paciente> Get()
        {
            return this.DataContextPaciente.Paciente.Include(it => it.convenio).Include(it => it.consultas).OrderBy(it => it.nome).ToList();
        }

        public Paciente Get(int id)
        {
            if(id == 0)
                return this.Get().FirstOrDefault();

            return this.DataContextPaciente.Paciente.Include(it => it.convenio).Include(it => it.consultas).ToList().Find(it => it.id == id);
        }

        public void Save()
        {
            this.DataContextPaciente.SaveChanges();
        }

        public void Update(Paciente novoPaciente)
        {
            Paciente paciente = this.Get(novoPaciente.id);

            paciente = novoPaciente.Clone();

            this.Save();
        }
    }
}