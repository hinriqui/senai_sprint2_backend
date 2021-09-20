using Microsoft.EntityFrameworkCore;
using senai.hroads.Contexts;
using senai.hroads.Domains;
using senai.hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Create(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Delete(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Remove(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ReadAll()
        {
            return ctx.TipoUsuarios.Include(u => u.Usuarios).ToList();
        }

        public TipoUsuario ReadById(int id)
        {
            return ctx.TipoUsuarios.Include(u => u.Usuarios).FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public void Update(int id, TipoUsuario novoTipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.FirstOrDefault(u => u.IdTipoUsuario == id);

            if (TipoUsuarioBuscado.Titulo != null)
            {
                TipoUsuarioBuscado.Titulo = novoTipoUsuario.Titulo;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }
    }
}
