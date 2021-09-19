using Microsoft.EntityFrameworkCore;
using senai.hroads.Contexts;
using senai.hroads.Domains;
using senai.hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HRoadsContext ctx = new HRoadsContext();

        public Usuario SearchAccount(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.Email == email & u.Senha == senha);
        }

        public void Create(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario buscado = ReadById(id);
            ctx.Usuarios.Remove(buscado);
            ctx.SaveChanges();
        }

        public List<Usuario> ReadAll()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario ReadById(int id)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Update(int id, Usuario novoUsuario)
        {
            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

            if (usuarioBuscado.Email != null)
            {
                usuarioBuscado.Email = novoUsuario.Email;
                usuarioBuscado.Senha = novoUsuario.Senha;
                usuarioBuscado.IdTipoUsuario = novoUsuario.IdTipoUsuario;
            }

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }
    }
}
