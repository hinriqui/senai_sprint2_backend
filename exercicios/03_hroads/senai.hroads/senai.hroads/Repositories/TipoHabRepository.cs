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
    public class TipoHabRepository : ITipoHabRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Create(TipoHab novoTipoHab)
        {
            ctx.TipoHabs.Add(novoTipoHab);
            ctx.SaveChanges();
        }

        public void Delete(TipoHab novoTipoHab)
        {
            ctx.TipoHabs.Remove(novoTipoHab);
            ctx.SaveChanges();
        }

        public List<TipoHab> ReadAll()
        {
            return ctx.TipoHabs.Include(u => u.Habilidades).ToList();
        }

        public TipoHab ReadById(int id)
        {
            return ctx.TipoHabs.Include(u => u.Habilidades).FirstOrDefault(u => u.IdTipo == id);
        }

        public void Update(int id, TipoHab novoTipoHab)
        {
            TipoHab TipoHabBuscado = ctx.TipoHabs.FirstOrDefault(u => u.IdTipo == id);

            if (TipoHabBuscado.NomeTipo != null)
            {
                TipoHabBuscado.NomeTipo = novoTipoHab.NomeTipo;
            }

            ctx.TipoHabs.Update(TipoHabBuscado);
            ctx.SaveChanges();
        }
    }
}
