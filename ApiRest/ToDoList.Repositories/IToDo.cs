using System.Collections.Generic;
using ToDoList.Domain;

namespace ToDoList.Repositories
{
    public interface IToDo
    {
        void Create(ToDo toDo);

        List<ToDo> GetAll();

        ToDo Update(ToDo todo);

        ToDo GetById(int id);

        void Delete(int id);
    }
}