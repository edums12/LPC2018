using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Associados.Domain
{
    public class Associado
    {
        [Required(ErrorMessage = "ID é obrigatório")]        
        public int id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        public string cpf { get; set; }

        public DateTime dataCadastro { get; set; }
    
        public string endereco { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "UF é obrigatório")]
        [MinLength(2, ErrorMessage = "UF deve possui 2 caracteres")]
        [MaxLength(2, ErrorMessage = "UF deve possui 2 caracteres")]
        public string uf { get; set; }

        public List<string> email { get; set; }

        [Required(ErrorMessage = "Estado civil é obrigatório")]
        public EnumEstadosCivis estadoCivil { get; set; }

        [Required(ErrorMessage = "Data nascimento é obrigatória")]
        public DateTime dataNascimento { get; set; }

        public List<Dependente> dependentes { get; set; }

        public Associado(){

        }
    }
}
