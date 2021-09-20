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
    public class ClasseRepository : IClasseRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Create(Classe novoClasse)
        {
            ctx.Classes.Add(novoClasse);
            ctx.SaveChanges();
        }

        public void Delete(Classe novoClasse)
        {
            ctx.Classes.Remove(novoClasse);
            ctx.SaveChanges();
        }

        public List<Classe> ReadAll()
        {
            return ctx.Classes.Include(u => u.Personagems).ToList();
        }

        public Classe ReadById(int id)
        {
            return ctx.Classes.Include(u => u.Personagems).FirstOrDefault(u => u.IdClasse == id);
        }

        public void Update(int id, Classe novoClasse)
        {
            Classe ClasseBuscado = ctx.Classes.FirstOrDefault(u => u.IdClasse == id);

            if (ClasseBuscado.NomeClasse != null)
            {
                ClasseBuscado.NomeClasse = novoClasse.NomeClasse;
            }

            ctx.Classes.Update(ClasseBuscado);
            ctx.SaveChanges();
        }
    }
}
