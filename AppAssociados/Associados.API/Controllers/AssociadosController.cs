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
    public class AssociadosController : Controller
    {
        private readonly IRepositoryCrud<Associado> repository;

        public AssociadosController(IRepositoryCrud<Associado> repository){
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public async Task<List<AssociadoDTO>> Get()
        {
            List<AssociadoDTO> associadosSimple = new List<AssociadoDTO>();

            List<Associado> associadosCadastrados = await this.repository.Get();
            
            associadosCadastrados
                .ForEach(associado => {
                    associadosSimple.Add(new AssociadoDTO(associado));
                });

            return associadosSimple;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<AssociadoDTO> Get(int id)
        {
            return new AssociadoDTO(await this.repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Associado associado)
        {
            // Se o associado possui dependentes
            if(associado.dependentes?.Any() ?? false)
            {
                // Faz o tratamento para atribuir os dependentes a esse associado
                associado.dependentes.ForEach(it => it.associado = associado );

                // Limpara a validação do modelstate
                ModelState.Clear();

                // Pede para revalidar associado
                TryValidateModel(associado);
            }
           
            if(ModelState.IsValid)
            {
                await this.repository.Create(associado);

                return Ok(new {
                    message = "Cadastrado com sucesso.",
                    usuario = new AssociadoDTO(associado)
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
        public async Task<IActionResult> Put([FromBody] Associado associado)
        {
            await this.repository.Update(associado);

            return Ok(new {
                message = "Atualizado com sucesso.",
                associado = new AssociadoDTO(associado)
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
