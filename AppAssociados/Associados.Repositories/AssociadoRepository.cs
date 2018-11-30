using System.Collections.Generic;
using System.Linq;
using Associados.Domain;
using Microsoft.EntityFrameworkCore;

namespace Associados.Repositories
{
    public class AssociadoRepository : IRepositoryCrud<Associado>
    {
        private DataContext dataContext;

        public AssociadoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(Associado associado)
        {
            dataContext.Entry(associado).State = EntityState.Added;

            foreach (var dependente in associado.dependentes)
            {
                dataContext.Entry(dependente).State = EntityState.Added;
            }

            dataContext.SaveChanges();
        }

        public List<Associado> Get()
        {
            return dataContext.Associados.Include(it => it.dependentes).ToList();
        }

        public Associado Get(int id){
            return this.Get().SingleOrDefault(it => it.id == id);
        }

        public void Update(Associado associado){
            dataContext.Entry(associado).State = EntityState.Modified;
           
            dataContext.SaveChanges();
        }

        public void Delete(int id){
            dataContext.Associados.Remove(this.Get(id));

            dataContext.SaveChanges();
        }
    }
}