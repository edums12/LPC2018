using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeople.Models
{
    [Table("people")]
    public class Person
    {
        #region Atributos

        private int _id;

        private string _name;

        private string _address;

        #endregion

        #region Propriedades
        
        [Key]
        public int GetId { get => _id; set => _id = value; }
        
        public string Name { get => _name; set => _name = value; }
    
        public string Address { get => _address; set => _address = value; }
            
        #endregion

        #region Métodos
        
        public Person()
        {

        }

        public Person(int pId, string pName, string pAddress)
        {
            _id = pId;
            _name = pName;
            _address = pAddress;
        }

        #endregion
    }   
}