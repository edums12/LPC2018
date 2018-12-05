using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associados.Domain;
using Microsoft.EntityFrameworkCore;

namespace Associados.Repositories
{
    public class UsuarioRepository : IRepositoryUsuario
    {
        private DataContext dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> Create(Usuario usuario)
        {
            dataContext.Entry(usuario).State = EntityState.Added;

            await dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            dataContext.Remove(await this.Get(id));

            await dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Usuario>> Get()
        {
            return await dataContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Get(int id)
        {
            return await dataContext.Usuarios.FirstAsync(it => it.id == id);
        }

        public async Task<bool> Update(Usuario usuario)
        {
            dataContext.Entry(usuario).State = EntityState.Modified;
            
            await dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario> AuthUser(Usuario usuario)
        {
            return await 
                dataContext
                    .Usuarios
                    .SingleOrDefaultAsync(it => 
                        it.usuario == usuario.usuario && 
                        it.senha == usuario.senha
                    );
        }
    }
}