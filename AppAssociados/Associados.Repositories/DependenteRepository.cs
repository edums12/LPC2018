using System.Collections.Generic;
using System.Linq;
using Associados.Domain;
using Microsoft.EntityFrameworkCore;

namespace Associados.Repositories
{
    public class DependenteRepository : IRepositoryCrud<Dependente>
    {
        private DataContext dataContext;

        public DependenteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(Dependente dependente)
        {
            dataContext.Entry(dependente).State = EntityState.Added;

            dataContext.SaveChanges();
        }

        public List<Dependente> Get()
        {
            return dataContext.Dependentes.ToList();
        }

        public Dependente Get(int id){
            return this.Get().SingleOrDefault(it => it.id == id);
        }

        public void Update(Dependente dependente){
            dataContext.Entry(dependente).State = EntityState.Modified;
           
            dataContext.SaveChanges();
        }

        public void Delete(int id){
            dataContext.Dependentes.Remove(this.Get(id));

            dataContext.SaveChanges();
        }
    }
}