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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Create(Habilidade novoHabilidade)
        {
            ctx.Habilidades.Add(novoHabilidade);
            ctx.SaveChanges();
        }

        public void Delete(Habilidade novoHabilidade)
        {
            ctx.Habilidades.Remove(novoHabilidade);
            ctx.SaveChanges();
        }

        public List<Habilidade> ReadAll()
        {
            return ctx.Habilidades.ToList();
        }

        public Habilidade ReadById(int id)
        {
            return ctx.Habilidades.Include(u => u.IdTipoNavigation).FirstOrDefault(u => u.IdHab == id);
        }

        public void Update(int id, Habilidade novoHabilidade)
        {
            Habilidade HabilidadeBuscado = ctx.Habilidades.FirstOrDefault(u => u.IdHab == id);

            if (HabilidadeBuscado.NomeHab != null)
            {
                HabilidadeBuscado.NomeHab = novoHabilidade.NomeHab;
            }

            ctx.Habilidades.Update(HabilidadeBuscado);
            ctx.SaveChanges();
        }
    }
}
