using System.Collections.Generic;
using System.Linq;

namespace AppChamados.Models
{
    public class SolicitanteRepository : IRepositorySolicitantes
    {
        private DataContext DataContext;

        public SolicitanteRepository(DataContext pDataContext)
        {
            this.DataContext = pDataContext;
        }

        public void Create(Solicitante pSolicitante)
        {
            this.DataContext.Solicitante.Add(pSolicitante);

            this.DataContext.SaveChanges();
        }

        public void Delete(int pId)
        {
            this.DataContext.Solicitante.Remove(this.Get(pId));

            this.DataContext.SaveChanges();
        }

        public List<Solicitante> Get()
        {
            return this.DataContext.Solicitante.OrderBy(it => it.id).ToList();
        }

        public Solicitante Get(int? pId)
        {
            if(pId == null)
                return this.Get().FirstOrDefault();

            return this.DataContext.Solicitante.ToList().Find(it => it.id == pId);
        }

        public void Update(Solicitante pNewSolicitante)
        {
            Solicitante solicitante = this.Get(pNewSolicitante.id);

            solicitante.nome = pNewSolicitante.nome;

            solicitante.telefone = pNewSolicitante.telefone;

            solicitante.email = pNewSolicitante.email;

            this.DataContext.SaveChanges();
        }
    }
}