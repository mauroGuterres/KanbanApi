using KanbanAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Contracts
{
   public interface IColaboradorRepository
    {
        public Task AddColaborador(Colaborador colaborador);
        public Task UpdateColaborador(Colaborador colaborador);
        public Task RemoveColaborador(int colaboradorId);
        public Task<Colaborador> GetColaboradorById(int colaboradorId);
        public Task<IList<Colaborador>> GetColaboradorByCard(int cardId);
        public Task<IList<Colaborador>> GetAllColaboradores();
        public Task AddColaboradorCard(int colaboradorId, int cardId);
        public Task RemoveColaboradorCard(int colaboradorId, int cardId);
        public Task AddColaboradoresCard(int[] colaboradorId, int cardId);
        public Task RemoveColaboradoresCard(int[] colaboradorId, int cardId);
    }
}
