using System.Collections.Generic;

namespace AppChamados.Models
{
    public interface IRepositorySituacoes
    {
        void Create(Situacoes pSituacao);

        void Update(Situacoes pNewSituacao);

        void Delete(int pId);

        List<Situacoes> Get();

        Situacoes Get(int? pId);
    }
}