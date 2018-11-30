using Associados.Domain;

namespace Associados.Repositories
{
    public interface IRepositoryUsuario : IRepositoryCrud<Usuario>
    {
        Usuario AuthUser(Usuario usuario);
    }
}