using AppChamados.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppChamados.Controllers
{
    public class SituacoesController : Controller
    {
        private readonly IRepositorySituacoes _repository;

        public SituacoesController(IRepositorySituacoes pRepository)
        {
            _repository = pRepository;
        }

        public IActionResult Index()
        {
            var situacoes = _repository.Get();

            return View(situacoes);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(string descricao)
        {
            _repository.Create(
                new Situacoes(
                    null,
                    descricao
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
            var situacao = _repository.Get(id);

            ViewData["base_url"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            return View(situacao);
        }

        [HttpPost]
        public IActionResult update(int id, string descricao){

            Situacoes situacao = 
                new Situacoes(
                    id,
                    descricao
                );

            _repository.Update(situacao);

            return RedirectToAction("index");
        }
    }
}