using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain;
using ToDoList.Repositories;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    public class ToDosItemController : Controller
    {
        private readonly IToDoItem repository;

        public ToDosItemController(IToDoItem repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<ToDoItem> Get()
        {
            return this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public ToDoItem Get(int id)
        {
            return this.repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ToDoItem ToDoItem)
        {
            this.repository.Create(ToDoItem);

            return Ok(ToDoItem);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ToDoItem ToDoItem)
        {
            ToDoItem newTodoItem = this.repository.Update(ToDoItem);

            return Ok(newTodoItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);

            return Ok(new{
                message = "Deletado com sucesso.",
                id = id
            });
        }
    }
}