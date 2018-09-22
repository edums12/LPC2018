using System.Collections.Generic;

namespace AppChamados.Models
{
    public interface IRepositorySolicitantes
    {
        void Create(Solicitante pSolicitante);

        void Update(Solicitante pNewSolicitante);

        void Delete(int pId);

        List<Solicitante> Get();

        Solicitante Get(int? pId);
    }
}