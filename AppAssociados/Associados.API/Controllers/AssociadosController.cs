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
    public class AssociadosController : Controller
    {
        private readonly IRepositoryCrud<Associado> repository;

        public AssociadosController(IRepositoryCrud<Associado> repository){
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<Associado> Get()
        {
            return this.repository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public Associado Get(int id)
        {
            return this.repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Associado associado)
        {
            this.repository.Create(associado);

            return Ok(new {
                message = "Cadastrado com sucesso.",
                associado = associado
            });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put([FromBody] Associado associado)
        {
            this.repository.Update(associado);

            return Ok(new {
                message = "Atualizado com sucesso.",
                associado = associado
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
