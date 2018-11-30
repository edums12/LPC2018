using System.Collections.Generic;

namespace Associados.Repositories
{
    public interface IRepositoryCrud<T> where T : class
    {
        List<T> Get();

        T Get(int id);

        void Create(T obj);

        void Update(T obj);

        void Delete(int id);
    }
}