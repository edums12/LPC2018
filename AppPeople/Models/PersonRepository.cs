using System.Collections.Generic;

namespace AppPeople.Models
{
    public class PersonRepository
    {
        #region Atributos

        private static List<Person> _people = new List<Person>();
        
        #endregion

        #region Propriedades

        public List<Person> People { get => _people; set => _people = value; }
            
        #endregion
        
        #region Métodos
        
        public List<Person> GetAll()
        {
            return People;
        }

        public Person GetById(int pId)
        {
            return People.Find((it) => it.GetId == pId);
        }

        public void Create(Person pPerson)
        {
            People.Add(pPerson);
        }

        public void Delete(int pId)
        {
            People.Remove(GetById(pId));
        }

        public void Update(int pId, Person pPerson)
        {
            Delete(pId);
            Create(pPerson);
        }

        #endregion
    }
}