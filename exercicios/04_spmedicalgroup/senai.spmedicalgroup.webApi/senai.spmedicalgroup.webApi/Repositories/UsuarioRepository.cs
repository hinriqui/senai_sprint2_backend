using senai.spmedicalgroup.webApi.Contexts;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(Domains.UsuarioRepository objAtualizado)
        {
            Domains.UsuarioRepository objBuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == objAtualizado.Email);

            if (objBuscado.Email != null)
            {
                objBuscado.Email = objAtualizado.Email;
                objBuscado.TipoUsuario = objAtualizado.TipoUsuario;
                objBuscado.NomeUsuario = objAtualizado.NomeUsuario;
                objBuscado.Senha = objAtualizado.Senha;
            }

            ctx.Usuarios.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Domains.UsuarioRepository Buscar(string email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Cadastrar(Domains.UsuarioRepository objAtualizado)
        {
            ctx.Usuarios.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(string email)
        {
            ctx.Usuarios.Remove(ctx.Usuarios.FirstOrDefault(u => u.Email == email));
            ctx.SaveChanges();
        }

        public List<Domains.UsuarioRepository> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Domains.UsuarioRepository Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

    }
}
