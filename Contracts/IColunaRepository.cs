using KanbanAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Contracts
{
   public interface IColunaRepository
    {
        public Task<IList<Coluna>> GetAllColunas();
        public Task<IList<Coluna>> GetColunasById(int[] colunasId);
        public Task<Coluna> GetColunaById(int colunaId);
        public Task CreateColuna(Coluna coluna);
        public Task UpdateColuna(Coluna coluna);
        public Task RemoveColuna(int colunaId);
    }
}
