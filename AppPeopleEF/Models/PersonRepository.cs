using System;
using System.Collections.Generic;
using System.Linq;
using AppPeopleEF.Models;

namespace AppPeople.Models
{
    public class PersonRepository : IPersonRepository
    {
        #region Atributos

        private static List<Person> _people = new List<Person>();

        private DataContext _context;
        
        #endregion

        #region Propriedades

        public List<Person> People { get => _people; set => _people = value; }
            
        #endregion
        
        #region Métodos

        public PersonRepository(DataContext context)
        {
            _context = context;
        }
        
        public List<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public Person GetById(int pId)
        {
            throw new NotImplementedException();
        }

        public void Create(Person pPerson)
        {
            People.Add(pPerson);
        }

        public void Update(Person pNewPerson)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}