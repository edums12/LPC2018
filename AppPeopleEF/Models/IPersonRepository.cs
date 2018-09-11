using System.Collections.Generic;
using AppPeople.Models;

namespace AppPeopleEF.Models
{
    public interface IPersonRepository
    {
        void Create(Person pPerson);
         
        List<Person> GetAll();

        void Update(Person pNewPerson);

        void Delete();
    }
}