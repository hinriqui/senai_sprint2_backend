using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.Domains
{
    public partial class Personagem
    {
        public byte IdPerso { get; set; }
        public byte IdClasse { get; set; }
        public string NomePerso { get; set; }
        public byte VidaMax { get; set; }
        public byte ManaMax { get; set; }
        public DateTime DataAtua { get; set; }
        public DateTime DataCria { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
