using AppChamados.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppChamados.Controllers
{
    public class SolicitantesController : Controller
    {
        private readonly IRepositorySolicitantes _repository;

        public SolicitantesController(IRepositorySolicitantes pRepository)
        {
            _repository = pRepository;
        }

        public IActionResult index()
        {
            var solicitantes = _repository.Get();

            return View(solicitantes);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(string nome, string email, string telefone)
        {
            _repository.Create(
                new Solicitante(
                    null,
                    nome,
                    email,
                    telefone
                )
            );

            return RedirectToAction("index");
        }

        public IActionResult delete(int id){
            _repository.Delete(id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult update(int id){
            var solicitante = _repository.Get(id);

            ViewData["base_url"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            return View(solicitante);
        }

        [HttpPost]
        public IActionResult update(int id, string nome, string email, string telefone){

            Solicitante solicitante = 
                new Solicitante(
                    id, 
                    nome,
                    email,
                    telefone
                );

            _repository.Update(solicitante);

            return RedirectToAction("index");
        }
    }
}