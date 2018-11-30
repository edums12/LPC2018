using System;
using System.ComponentModel.DataAnnotations;

namespace Associados.Domain
{
    public class Dependente
    {
        [Required(ErrorMessage = "ID é obrigatório")]
        public int id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string nome { get; set; }
        
        public string grauParentesco { get; set; }

        [Required(ErrorMessage = "Para o cadastro do dependente é obrigatório informar o associado")]
        public Associado associado { get; set; }
        
        [Required(ErrorMessage = "Data do nascimento é obrigatória")]
        public DateTime dataNascimento { get; set; }

        public Dependente(){}
    }
}