using System;
using System.Collections.Generic;
using AppPeople.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppPeople.Controllers
{
    public class PeopleController : Controller
    {
        #region Atributos
        
        private PersonRepository _repository = new PersonRepository();

        #endregion

        #region Propriedades
        
        public PersonRepository Repository { get => _repository; set => _repository = value; }

        #endregion

        #region Métodos

        public IActionResult Index()
        {
            List<Person> people = Repository.GetAll();
            
            return View(people);
        }

        public IActionResult Create()
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

        #endregion
    }
}