using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedicalgroup.webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<UsuarioRepository>();
        }

        public string Sigla { get; set; }
        public string TipoUsuario1 { get; set; }

        public virtual ICollection<UsuarioRepository> Usuarios { get; set; }
    }
}
