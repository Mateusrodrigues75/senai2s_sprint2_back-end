using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedicalgroup.webapi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdProntuario { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Prontuario IdProntuarioNavigation { get; set; }
    }
}
