using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webapi.Domains
{
    public partial class ClasseHabilidade
    {
        public int? IdClasse { get; set; }
        public int? IdHab { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabNavigation { get; set; }
    }
}
