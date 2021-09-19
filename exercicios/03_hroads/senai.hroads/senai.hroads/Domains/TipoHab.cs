using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.Domains
{
    public partial class TipoHab
    {
        public TipoHab()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public byte IdTipo { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
