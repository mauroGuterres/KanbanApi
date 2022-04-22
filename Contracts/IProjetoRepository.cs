using KanbanAPI.Context.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanAPI.Contracts
{
   public interface IProjetoRepository
    {
        public Task<IList<Projeto>> GetAllProjetos();
        public Task CreateProjeto(Projeto projeto);
        public Task UpdateProjeto(Projeto projeto);
        public Task RemoveProjeto(int ProjetoId);
        public Task<Projeto> GetProjetoById(int ProjetoId);
    }
}
