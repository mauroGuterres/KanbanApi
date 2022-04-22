using KanbanAPI.Context;
using KanbanAPI.Context.Entities;
using KanbanAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {

        private KanbanDBContext _context;

        public ProjetoRepository(KanbanDBContext context)
        {
            _context = context;
        }

        public async Task CreateProjeto(Projeto projeto)
        {
            _context.Projeto.Add(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Projeto>> GetAllProjetos()
        {
            var projetos = await _context.Projeto.ToListAsync();
            return projetos;
        }

        public async Task<Projeto> GetProjetoById(int ProjetoId)
        {
            var projeto = await _context.Projeto.FirstOrDefaultAsync(x => x.Id == ProjetoId);
            return projeto;
        }

        public async Task RemoveProjeto(int projetoId)
        {
            var projeto = _context.Projeto.FirstOrDefault(x => x.Id == projetoId);
            _context.Projeto.Remove(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjeto(Projeto projeto)
        {
            _context.Projeto.Update(projeto);
            await _context.SaveChangesAsync();
        }
    }
}
