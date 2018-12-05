using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Associados.API.Controllers.DTOs;
using Associados.Domain;
using Associados.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Associados.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IRepositoryUsuario repository;

        public UsuariosController(IRepositoryUsuario repository){
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public async Task<List<UsuarioDTO>> Get()
        {
            List<UsuarioDTO> usuariosSimple = new List<UsuarioDTO>();

            List<Usuario> usuariosCadastrados = await this.repository.Get();

            usuariosCadastrados
                .ForEach(usuario => {
                    usuariosSimple.Add(new UsuarioDTO(usuario)); 
                });

            return usuariosSimple;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<UsuarioDTO> Get(int id)
        {
            return new UsuarioDTO(await this.repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                await this.repository.Create(usuario);

                return Ok(new {
                    message = "Cadastrado com sucesso.",
                    usuario = new UsuarioDTO(usuario)
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
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            await this.repository.Update(usuario);

            return Ok(new {
                message = "Atualizado com sucesso.",
                usuario = new UsuarioDTO(usuario)
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

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authentication([FromBody] Usuario usuario)
        {
            var autenticacaoUsuario = this.repository.AuthUser(usuario);

            if(autenticacaoUsuario == null)
                return BadRequest(new {
                    message = "Login e/ou senha incorreto(s)"
                });

            return Ok(new{
                token = this.buildToken()
            });
        }

        private string buildToken()
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Aula15UlbraTorres"));

            var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                audience: "Aula15",
                issuer: "Aula15",
                signingCredentials: creed
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
