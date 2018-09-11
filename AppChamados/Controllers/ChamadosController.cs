using System;
using System.Collections.Generic;
using AppChamados.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppChamados.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly IRepositoryChamados _repository;

        public ChamadosController(IRepositoryChamados pRepository)
        {
            _repository = pRepository;
        }

        public IActionResult index()
        {
            var chamados = _repository.Get();

            chamados.ForEach(it => {
                it.totalHorasAtendimento = (it.horaFim.Subtract(it.horaInicio)).TotalHours;
            });

            return View(chamados);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(string numero, DateTime data, string nome, string telefone, string email, string problema, DateTime dataSolucao, DateTime horaInicio, DateTime horaFim)
        {
            _repository.Create(new Chamados(null, numero, data, nome, telefone, email, problema, dataSolucao, horaInicio, horaFim));

            return RedirectToAction("index");
        }

        public IActionResult delete(int id){
            _repository.Delete(id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult update(int id){
            var chamado = _repository.Get(id);

            ViewData["base_url"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            return View(chamado);
        }

        [HttpPost]
        public IActionResult update(int id, string numero, DateTime data, string nome, string telefone, string email, string problema, DateTime dataSolucao, DateTime horaInicio, DateTime horaFim){

            Chamados chamado = new Chamados(id, numero, data, nome, telefone, email, problema, dataSolucao, horaInicio, horaFim);

            _repository.Update(chamado);

            return RedirectToAction("index");
        }
    }
}