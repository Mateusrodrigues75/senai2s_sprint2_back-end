using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedicalgroup.webapi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Prontuarios = new HashSet<Prontuario>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage ="O email do usuário é obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="A senha deve possuir 10 caracteres!")]
        [StringLength(10)]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Prontuario> Prontuarios { get; set; }
    }
}
