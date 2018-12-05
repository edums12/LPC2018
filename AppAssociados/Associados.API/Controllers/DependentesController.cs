using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associados.API.Controllers.DTOs;
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
        public async Task<List<DependenteDTO>> Get()
        {
            List<DependenteDTO> dependentesSimple = new List<DependenteDTO>();

            List<Dependente> dependentesCadastrados = await this.repository.Get();
            
            dependentesCadastrados
                .ForEach(dependente => {
                    dependentesSimple.Add(new DependenteDTO(dependente));
                });

            return dependentesSimple;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<DependenteDTO> Get(int id)
        {
            return new DependenteDTO(await this.repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Dependente dependente)
        {
            if(ModelState.IsValid)
            {
                await this.repository.Create(dependente);

                return Ok(new {
                    message = "Cadastrado com sucesso.",
                    usuario = new DependenteDTO(dependente)
                });
            }
            else
            {
                var errors = new List<string>();

                ModelState.ToList().ForEach(state => {
                    state.Value.Errors.ToList().ForEach(error =>{
                        errors.Add(error.ErrorMessage);
                    });
                });

                return BadRequest(new {
                    message = errors
                });
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] Dependente dependente)
        {
            await this.repository.Update(dependente);

            return Ok(new {
                message = "Atualizado com sucesso.",
                dependente = new DependenteDTO(dependente)
            });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.Delete(id);

            return Ok(new{
                message = "Deletado com sucesso.",
                id = id
            });
        }
    }
}
