using System.Collections.Generic;

namespace AppG1.Models
{
    public interface IPacienteRepository
    {
        void Create(Paciente paciente);

        void Update(Paciente novoPaciente);

        void Delete(int id);

        List<Paciente> Get();

        Paciente Get(int id);

        void Save();
    }
}