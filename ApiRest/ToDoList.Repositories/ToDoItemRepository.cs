using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;

namespace ToDoList.Repositories
{
    public class ToDoItemRepository : IToDoItem
    {
        private DataContext dataContext;
        
        public ToDoItemRepository(DataContext dataContext)
        {           
            this.dataContext = dataContext;
        }

        public void Create(ToDoItem todoItem)
        {
            dataContext.Add(todoItem);
            dataContext.SaveChanges();
        }
        public List<ToDoItem> GetAll()
        {
            return dataContext.TodosItem.ToList();
        }
        
        public ToDoItem Update(ToDoItem todoItem)
        {
            var obj  = GetById(todoItem.id);
            
            obj.id = todoItem.id;

            obj.nome = todoItem.nome;
            
            dataContext.SaveChanges();

            return obj;
        }
        public ToDoItem GetById(int id)
        {
            return dataContext.TodosItem.SingleOrDefault(x=>x.id == id);
        }
        
        public void Delete(int id)
        {
            dataContext.Remove(GetById(id));
            dataContext.SaveChanges();
        }
    }
}
