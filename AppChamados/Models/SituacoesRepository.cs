using System.Collections.Generic;
using System.Linq;

namespace AppChamados.Models
{
    public class SituacoesRepository : IRepositorySituacoes
    {
        private DataContext DataContext;

        public SituacoesRepository(DataContext pDataContext)
        {
            this.DataContext = pDataContext;
        }

        public void Create(Situacoes pSituacao)
        {
            this.DataContext.Situacoes.Add(pSituacao);

            this.DataContext.SaveChanges();
        }

        public void Delete(int pId)
        {
            this.DataContext.Situacoes.Remove(this.Get(pId));

            this.DataContext.SaveChanges();
        }

        public List<Situacoes> Get()
        {
            return this.DataContext.Situacoes.OrderBy(it => it.id).ToList();
        }

        public Situacoes Get(int? pId)
        {
            if(pId == null)
                return this.Get().FirstOrDefault();

            return this.DataContext.Situacoes.ToList().Find(it => it.id == pId);
        }

        public void Update(Situacoes pNewSituacao)
        {
            Situacoes situacao = this.Get(pNewSituacao.id);

            situacao.descricao = pNewSituacao.descricao;

            this.DataContext.SaveChanges();
        }
    }
}