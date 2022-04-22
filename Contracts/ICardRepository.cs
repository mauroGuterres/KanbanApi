using KanbanAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Contracts
{
    public interface ICardRepository
    {
        public Task<IList<Card>> GetAllCards();
        public Task<Card> GetCardById(int cardId);
        public Task<IList<Card>> GetCardsByProjeto(int ProjetoId);
        public Task<IList<Card>> GetCardsByColaborador(int ColaboradorId);
        public Task<IList<Card>> GetCardsByStatus(Status Status);
        public Task<IList<Card>> GetCardsByColunas(int[] colunasId);
        
        public Task UpdateVerticalCardPosition(int cardId, int newPosition);
        public Task UpdateHorizontalCardPosition(int cardId,int newColunaId, int newPosition);
        public Task CreateCard(Card card);
        public Task UpdateCard(Card card);
        public Task RemoveCard(int cardId);
    }


}
