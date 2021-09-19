using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.Domains
{
    public partial class Habilidade
    {
        public byte IdHab { get; set; }
        public byte IdTipo { get; set; }
        public string NomeHab { get; set; }

        public virtual TipoHab IdTipoNavigation { get; set; }
    }
}
