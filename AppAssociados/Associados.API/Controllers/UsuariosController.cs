using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Usuario> Get()
        {
            return this.repository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return this.repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            this.repository.Create(usuario);

            return Ok(new {
                message = "Cadastrado com sucesso.",
                usuario = usuario
            });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            this.repository.Update(usuario);

            return Ok(new {
                message = "Atualizado com sucesso.",
                usuario = usuario
            });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);

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
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Aula15UlbraLPC"));

            var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                audience: "Aula15UlbraLPC",
                issuer: "Aula15UlbraLPC",
                signingCredentials: creed
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
