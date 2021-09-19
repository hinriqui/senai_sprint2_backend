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
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Create(ClasseHabilidade novoClasseHabilidade)
        {
            ctx.ClasseHabilidades.Add(novoClasseHabilidade);
            ctx.SaveChanges();
        }

        public void Delete(ClasseHabilidade novoClasseHabilidade)
        {
            ctx.ClasseHabilidades.Remove(novoClasseHabilidade);
            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> ReadAll()
        {
            return ctx.ClasseHabilidades.Include(u => u.IdClasseNavigation).Include(u => u.IdHabNavigation).ToList();
        }
    }
}
