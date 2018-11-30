using System.Collections.Generic;
using System.Linq;
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

        public void Create(Usuario usuario)
        {
            dataContext.Entry(usuario).State = EntityState.Added;

            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dataContext.Remove(this.Get(id));

            dataContext.SaveChanges();
        }

        public List<Usuario> Get()
        {
            return dataContext.Usuarios.ToList();
        }

        public Usuario Get(int id)
        {
            return this.Get().SingleOrDefault(it => it.id == id);
        }

        public void Update(Usuario usuario)
        {
            dataContext.Entry(usuario).State = EntityState.Modified;
            
            dataContext.SaveChanges();
        }

        public Usuario AuthUser(Usuario usuario)
        {
            return 
                dataContext
                .Usuarios
                .SingleOrDefault(it => 
                    it.usuario == usuario.usuario && 
                    it.senha == System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(usuario.senha)));
        }
    }
}