using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> Create(Dependente dependente)
        {
            dataContext.Entry(dependente).State = EntityState.Added;

            await dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Dependente>> Get()
        {
            return await dataContext.Dependentes.Include(it => it.associado).ToListAsync();
        }

        public async Task<Dependente> Get(int id){
            return await 
                dataContext
                .Dependentes
                .FirstAsync(it => 
                    it.id == id
                );
        }

        public async Task<bool> Update(Dependente dependente){
            dataContext.Entry(dependente).State = EntityState.Modified;
           
            await dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id){
            dataContext.Dependentes.Remove(await this.Get(id));

            await dataContext.SaveChangesAsync();

            return true;
        }
    }
}