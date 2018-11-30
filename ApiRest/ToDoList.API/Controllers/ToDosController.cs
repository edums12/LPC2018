using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain;
using ToDoList.Repositories;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    public class ToDosController : Controller
    {
        private readonly IToDo repository;

        public ToDosController(IToDo repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<ToDo> Get()
        {
            return this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public ToDo Get(int id)
        {
            return this.repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ToDo ToDo)
        {
            this.repository.Create(ToDo);

            return Ok(ToDo);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ToDo ToDo)
        {
            ToDo newTodo = this.repository.Update(ToDo);

            return Ok(newTodo);
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