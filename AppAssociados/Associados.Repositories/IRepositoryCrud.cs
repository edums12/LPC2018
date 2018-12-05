using System.Collections.Generic;
using System.Threading.Tasks;

namespace Associados.Repositories
{
    public interface IRepositoryCrud<T> where T : class
    {
        Task<List<T>> Get();

        Task<T> Get(int id);

        Task<bool> Create(T obj);

        Task<bool> Update(T obj);

        Task<bool> Delete(int id);
    }
}