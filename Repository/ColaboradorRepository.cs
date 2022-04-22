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
    public class ColaboradorRepository : IColaboradorRepository
    {

        private KanbanDBContext _context;
        public ColaboradorRepository(KanbanDBContext context)
        {
            _context = context;
        }
        public async Task AddColaborador(Colaborador colaborador)
        {
            await _context.AddAsync(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task AddColaboradorCard(int colaboradorId, int cardId)
        {
            await _context.Colaborador_Card.AddAsync(new Colaborador_Card() { CardId = cardId, ColaboradorId = colaboradorId });
            await _context.SaveChangesAsync();
        }

        public async Task AddColaboradoresCard(int[] colaboradorId, int cardId)
        {
            var colaboradorCard = new List<Colaborador_Card>();
            foreach (var colaborador in colaboradorId) {
                colaboradorCard.Add(new Colaborador_Card() { CardId = cardId, ColaboradorId = colaborador });
            }
            await _context.Colaborador_Card.AddRangeAsync(colaboradorCard);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateColaborador(Colaborador colaborador)
        {
            _context.Colaborador.Update(colaborador);
            await _context.SaveChangesAsync();

        }

        public async Task<IList<Colaborador>> GetAllColaboradores()
        {
            return await _context.Colaborador.ToListAsync();
        }

        public async Task<IList<Colaborador>> GetColaboradorByCard(int cardId)
        {
            return await _context.Colaborador_Card.Where(x => x.CardId == cardId).Select(x => x.Colaborador).ToListAsync();
        }

        public async Task<Colaborador> GetColaboradorById(int colaboradorId)
        {
            return await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == colaboradorId);
        }

        public async Task RemoveColaborador(int colaboradorId)
        {
            var colaborador = await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == colaboradorId);
            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveColaboradorCard(int colaboradorId, int cardId)
        {
            var colaboradorCard = await _context.Colaborador_Card.FirstOrDefaultAsync(x => x.CardId == cardId && x.ColaboradorId == colaboradorId);
            _context.Colaborador_Card.Remove(colaboradorCard);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveColaboradoresCard(int[] colaboradorId, int cardId)
        {
            var colaboradorCard = await _context.Colaborador_Card.Where(x => x.CardId == cardId && colaboradorId.Contains(x.ColaboradorId)).ToListAsync();
            _context.Colaborador_Card.RemoveRange(colaboradorCard);
            await _context.SaveChangesAsync();
        }
    }
}
