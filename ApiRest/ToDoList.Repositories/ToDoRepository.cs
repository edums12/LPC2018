using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;

namespace ToDoList.Repositories
{
    public class ToDoRepository : IToDo
    {
        private DataContext dataContext;
        
        public ToDoRepository(DataContext dataContext)
        {           
            this.dataContext = dataContext;
        }

        public void Create(ToDo todo)
        {
            dataContext.Add(todo);
            dataContext.SaveChanges();
        }
        public List<ToDo> GetAll()
        {
            return dataContext.Todos.Include(it => it.items).ToList();
        }
        
        public ToDo Update(ToDo todo)
        {
            var obj  = GetById(todo.id);
            
            obj.id = todo.id;

            obj.descricao = todo.descricao;
            
            dataContext.SaveChanges();

            return obj;
        }
        public ToDo GetById(int id)
        {
            return dataContext.Todos.Include(it => it.items).SingleOrDefault(x => x.id == id);
        }
        
        public void Delete(int id)
        {
            dataContext.Remove(GetById(id));
            dataContext.SaveChanges();
        }
    }
}
