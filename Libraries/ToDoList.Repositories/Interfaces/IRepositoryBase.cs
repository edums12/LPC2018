using System.Collections.Generic;

namespace ToDoList.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> Get();

        void Create(T obj);

        void Update(T obj);

        void Delete(T obj);

        void SaveChanges();
         
    }
}