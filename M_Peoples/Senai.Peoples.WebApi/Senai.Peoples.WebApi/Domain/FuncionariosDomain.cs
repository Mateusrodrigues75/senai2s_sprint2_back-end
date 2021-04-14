using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domain
{
    public class FuncionariosDomain
    {
        public int idFuncionario { get; set; }
        public string nome { get; set; }

        [Required(ErrorMessage = "O sobrenome do funcionário é obrigatório!")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "O sobrenome do funcionário deve conter de 5 a 10 caracteres")]
        //[RegularExpression()] - Para controlar tipos de caracteres.
        public string sobrenome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
