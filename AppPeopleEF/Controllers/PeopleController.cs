using System;
using System.Collections.Generic;
using AppPeople.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppPeopleEF.Models;
using Microsoft.EntityFrameworkCore;

namespace AppPeople.Controllers
{
    public class PeopleController : Controller
    {
        #region Atributos

        private readonly IPersonRepository _repository;

        #endregion

        #region Propriedades
        
        public IPersonRepository Repository => _repository;

        #endregion

        #region Métodos

        public PeopleController(IPersonRepository pRepository)
        {
            _repository = pRepository;
        }

        public IActionResult Index()
        {
            var people = _repository.GetAll();

            return View(people);
        }

       /*  public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, string name, string address)
        {
            Repository.Create(new Person(id, name, address));
            
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(Repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(int id, string name, string address)
        {
            Repository.Update(id, new Person(id, name, address));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Repository.Delete(id);

            return RedirectToAction("Index");
        }
        */
        #endregion 
    }
}