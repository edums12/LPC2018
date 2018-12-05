using System.Threading.Tasks;
using Associados.Domain;

namespace Associados.Repositories
{
    public interface IRepositoryUsuario : IRepositoryCrud<Usuario>
    {
        Task<Usuario> AuthUser(Usuario usuario);
    }
}