using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Domain;
using ToDoList.Repositories.Data;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories
{
    public class ToDoRepositories : IToDoRepository
    {
        private DataContext _db;

        public DataContext DataContext { get; }

        public ToDoRepositories(DataContext dataContext)
        {
            _db = dataContext;
        }

        public void Create(ToDo obj)
        {
            this.DataContext.Add(obj);

            this.SaveChanges();
        }

        public void Delete(ToDo obj)
        {
            this.DataContext.Remove(obj);

            this.SaveChanges();
        }

        public List<ToDo> Get()
        {
            return this.DataContext.ToDos.ToList();
        }

        public void Update(ToDo obj)
        {
            ToDo todo = this.Get().Find(it => it.id == obj.id);

            todo.descricao = obj.descricao;

            this.SaveChanges();
        }

        public void SaveChanges()
        {
            this.DataContext.SaveChanges();
        }
    }
}
