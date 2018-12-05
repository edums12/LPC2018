using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> Create(Associado associado)
        {
            dataContext.Entry(associado).State = EntityState.Added;

            if (associado.dependentes?.Any() ?? false)
            {
                foreach (var dependente in associado.dependentes)
                    dataContext.Entry(dependente).State = EntityState.Added;
            }

            await dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Associado>> Get()
        {
            return await dataContext.Associados.Include(it => it.dependentes).ToListAsync();
        }

        public async Task<Associado> Get(int id){
            return await dataContext.Associados.Include(it => it.dependentes).FirstAsync(it => it.id == id);
        }

        public async Task<bool> Update(Associado associado){
            dataContext.Entry(associado).State = EntityState.Modified;
           
            await dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id){
            dataContext.Associados.Remove(await this.Get(id));

            await dataContext.SaveChangesAsync();

            return true;
        }
    }
}