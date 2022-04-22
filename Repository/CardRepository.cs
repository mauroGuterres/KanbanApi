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
    public class CardRepository : ICardRepository
    {
        private KanbanDBContext _context;

        public CardRepository(KanbanDBContext context)
        {
            _context = context;
        }

        private async Task HandleCardPosition(Card card)
        {
            var listaCard = await _context.Card.Where(x => x.ColunaId == card.ColunaId).OrderBy(x => x.Posicao).ToListAsync();
            if (card.Posicao == 0)
            {
                var lastPosition = listaCard.Last().Posicao;
                card.Posicao = lastPosition + 1;
            }
            else
            {
                var samePositionCard = listaCard.FirstOrDefault(x => x.Posicao == card.Posicao && x.ColunaId == card.ColunaId);
                if (samePositionCard != null)
                {
                    await UpdateVerticalPositionFrom(listaCard, samePositionCard.Posicao);
                }
            }
        }

        public async Task CreateCard(Card card)
        {
            await HandleCardPosition(card);
            _context.Card.Add(card);
            await _context.SaveChangesAsync();
        }       

        public async Task UpdateCard(Card card)
        {
            await HandleCardPosition(card);
            _context.Card.Update(card);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCard(int CardId)
        {
            var card = _context.Card.FirstOrDefault(x => x.Id == CardId);
            _context.Card.Remove(card);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Card>> GetAllCards()
        {
            var cards = await _context.Card
                .Include(x => x.Projeto)
                .Include(x => x.Colaborador_Card)
                .ThenInclude(x => x.Colaborador)
                .ToListAsync();
            return cards;
        }

        public async Task<IList<Card>> GetCardsByProjeto(int ProjetoId)
        {
            var cardsByProjeto = await _context.Card
                .Where(x => x.ProjetoId == ProjetoId)
                .Include(x => x.Projeto)
                .ToListAsync();
            return cardsByProjeto;
        }

        public async Task<IList<Card>> GetCardsByStatus(Status Status)
        {
            var cardsByStatus = await _context.Card
                .Where(x => x.Status == Status)
                .ToListAsync();
            return cardsByStatus;
        }

        public async Task<IList<Card>> GetCardsByColaborador(int ColaboradorId)
        {
            var cardsByColaborador = await _context.Colaborador_Card
                .Where(x => x.ColaboradorId == ColaboradorId)
                .Select(x => x.Card).ToListAsync();
            return cardsByColaborador;
        }

        public async Task<IList<Card>> GetCardsByColunas(int[] colunasId)
        {
            var cards = await _context.Card
                .Where(x => colunasId.Contains(x.ColunaId))                
                .Include(x => x.Projeto)
                .Include(x => x.Colaborador_Card)
                .ThenInclude(x => x.Colaborador)
                .ToListAsync();

            return cards;
        }

        public async Task<Card> GetCardById(int cardId)
        {
            var card = await _context.Card.FirstOrDefaultAsync(x => x.Id == cardId);
            return card;
        }

        private async Task UpdateVerticalPositionFrom(List<Card> listaCard, int startPosition)
        {
            var cards = listaCard
                .Where(x => x.Posicao >= startPosition)
                .ToList();
            foreach (var card in cards)
            {
                card.Posicao += 1;
            }
            _context.UpdateRange(cards);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVerticalCardPosition(int cardId, int newPosition)
        {
            var cardToBeUpdated = await _context.Card.FirstOrDefaultAsync(x => x.Id == cardId);
            var samePositionCard = await _context.Card.FirstOrDefaultAsync(x => x.Id != cardId
            && x.ColunaId == cardToBeUpdated.ColunaId
            && x.Posicao == newPosition);
            if (samePositionCard != null)
            {
                samePositionCard.Posicao = cardToBeUpdated.Posicao;                                
            }
            cardToBeUpdated.Posicao = newPosition;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHorizontalCardPosition(int cardId, int newColunaId, int newPosition)
        {
            var cardToBeUpdated = await _context.Card.FirstOrDefaultAsync(x => x.Id == cardId);
            var samePositionCard = await _context.Card.FirstOrDefaultAsync(x => x.Id != cardId
            && x.ColunaId == newColunaId
            && x.Posicao == newPosition);
            if (samePositionCard != null)
            {
                var listaCard = await _context.Card.Where(x => x.ColunaId == samePositionCard.ColunaId).ToListAsync();
                await UpdateVerticalPositionFrom(listaCard, samePositionCard.Posicao);
            }
            cardToBeUpdated.Posicao = newPosition;
            cardToBeUpdated.ColunaId = newColunaId;
            await _context.SaveChangesAsync();
        }

      
    }
}
