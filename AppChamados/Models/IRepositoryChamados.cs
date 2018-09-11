using System.Collections.Generic;

namespace AppChamados.Models
{
    public interface IRepositoryChamados
    {
        void Create(Chamados pChamados);

        void Update(Chamados pNewChamados);

        void Delete(int pId);

        List<Chamados> Get();

        Chamados Get(int? pId);
    }
}