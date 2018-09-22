using System;
using System.Collections.Generic;
using System.Linq;
using AppChamados.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppChamados.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly IRepositoryChamados _repositoryChamados;

        private readonly IRepositorySolicitantes _repositorySolicitantes;

        private readonly IRepositorySituacoes _repositorySituacoes;

        public ChamadosController(IRepositoryChamados pRepositoryChamados, IRepositorySolicitantes pRepositorySolicitante, IRepositorySituacoes pRepositorySituacoes)
        {
            _repositoryChamados = pRepositoryChamados;

            _repositorySolicitantes = pRepositorySolicitante;

            _repositorySituacoes = pRepositorySituacoes;
            
        }

        public IActionResult index()
        {
            var chamados = _repositoryChamados.Get();

            chamados.ForEach(it => {
                it.totalHorasAtendimento = (it.horaFim.Subtract(it.horaInicio)).TotalHours;
            });

            return View(chamados);
        }

        public IActionResult create()
        {   
            ViewBag.solicitantes = _repositorySolicitantes.Get();

            ViewBag.situacoes = _repositorySituacoes.Get();

            return View();
        }

        [HttpPost]
        public IActionResult create(string numero, int solicitanteId, string problema, DateTime dataSolucao, DateTime horaInicio, DateTime horaFim, int situacaoId)
        {
            _repositoryChamados.Create(
                new Chamados(
                    null, 
                    numero, 
                    solicitanteId,
                    problema, 
                    dataSolucao, 
                    horaInicio, 
                    horaFim,
                    situacaoId
                )
            );

            return RedirectToAction("index");
        }

        public IActionResult delete(int id){
            _repositoryChamados.Delete(id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult update(int id){
            var chamado = _repositoryChamados.Get(id);

            ViewBag.solicitantes = _repositorySolicitantes.Get();

            ViewBag.situacoes = _repositorySituacoes.Get();

            ViewData["base_url"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            return View(chamado);
        }

        [HttpPost]
        public IActionResult update(int id, string numero, int solicitanteId, string problema, DateTime dataSolucao, DateTime horaInicio, DateTime horaFim, int situacaoId){

            Chamados chamado = 
                new Chamados(
                    id, 
                    numero, 
                    solicitanteId,
                    problema, 
                    dataSolucao, 
                    horaInicio, 
                    horaFim,
                    situacaoId
                );

            _repositoryChamados.Update(chamado);

            return RedirectToAction("index");
        }
    }
}