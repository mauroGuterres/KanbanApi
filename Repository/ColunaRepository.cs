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
    public class ColunaRepository : IColunaRepository
    {

        private KanbanDBContext _context;

        public ColunaRepository(KanbanDBContext context) {
            _context = context;
        }

        public async Task CreateColuna(Coluna coluna)
        {
            await _context.Coluna.AddAsync(coluna);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Coluna>> GetAllColunas()
        {
            var colunas = await _context.Coluna.ToListAsync();
            return colunas;
        }

        public async Task<Coluna> GetColunaById(int colunaId)
        {
            var coluna = await _context.Coluna.FirstOrDefaultAsync(x => x.Id == colunaId);
            return coluna;
        }

        public async Task<IList<Coluna>> GetColunasById(int[] colunasId)
        {
            var colunas = await _context.Coluna.Where(x => colunasId.Contains(x.Id)).ToListAsync();
            return colunas;
        }

        public async Task RemoveColuna(int colunaId)
        {
            var coluna = await _context.Coluna.FirstOrDefaultAsync(x => x.Id == colunaId);
            _context.Coluna.Remove(coluna);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateColuna(Coluna coluna)
        {
            _context.Coluna.Update(coluna);
            await _context.SaveChangesAsync();
        }
    }
}
