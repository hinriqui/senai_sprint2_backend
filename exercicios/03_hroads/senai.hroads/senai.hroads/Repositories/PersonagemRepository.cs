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
    public class PersonagemRepository : IPersonagemRepository
    {
        HRoadsContext ctx = new HRoadsContext();
        public void Create(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);
            ctx.SaveChanges();
        }

        public void Delete(Personagem novoPersonagem)
        {
            ctx.Personagems.Remove(novoPersonagem);
            ctx.SaveChanges();
        }

        public List<Personagem> ReadAll()
        {
            return ctx.Personagems.Include(u => u.IdClasseNavigation).ToList();
        }

        public Personagem ReadById(int id)
        {
            return ctx.Personagems.Include(u => u.IdClasseNavigation).FirstOrDefault(u => u.IdPerso == id);
        }

        public void Update(int id, Personagem novoPersonagem)
        {
            Personagem PersonagemBuscado = ctx.Personagems.FirstOrDefault(u => u.IdPerso == id);

            if (PersonagemBuscado.NomePerso != null)
            {
                PersonagemBuscado.NomePerso = novoPersonagem.NomePerso;
                PersonagemBuscado.IdClasse = novoPersonagem.IdClasse;
                PersonagemBuscado.ManaMax = novoPersonagem.ManaMax;
                PersonagemBuscado.VidaMax = novoPersonagem.VidaMax;
                PersonagemBuscado.DataAtua = novoPersonagem.DataAtua;
                PersonagemBuscado.DataCria = novoPersonagem.DataCria;
            }

            ctx.Personagems.Update(PersonagemBuscado);
            ctx.SaveChanges();
        }
    }
}
