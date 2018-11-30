using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associados.Domain;
using Associados.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Associados.API.Controllers
{
    [Route("api/[controller]")]
    public class DependentesController : Controller
    {
        private readonly IRepositoryCrud<Dependente> repository;

        public DependentesController(IRepositoryCrud<Dependente> repository){
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<Dependente> Get()
        {
            return this.repository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public Dependente Get(int id)
        {
            return this.repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Dependente dependente)
        {
            this.repository.Create(dependente);

            return Ok(new {
                message = "Cadastrado com sucesso.",
                dependente = dependente
            });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put([FromBody] Dependente dependente)
        {
            this.repository.Update(dependente);

            return Ok(new {
                message = "Atualizado com sucesso.",
                dependente = dependente
            });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
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
