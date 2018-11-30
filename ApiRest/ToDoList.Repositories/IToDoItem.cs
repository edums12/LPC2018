using System.Collections.Generic;
using ToDoList.Domain;

namespace ToDoList.Repositories
{
    public interface IToDoItem
    {
        void Create(ToDoItem toDoItem);
        List<ToDoItem> GetAll();
        ToDoItem Update(ToDoItem toDoItem);
        ToDoItem GetById(int id);
        void Delete(int id);
    }
}