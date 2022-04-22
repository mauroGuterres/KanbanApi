using KanbanAPI.Context.Entities;
using KanbanAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanAPI.Controllers
{
    public class ProjetoController : ControllerBase
    {
        private readonly ILogger<ProjetoController> _logger;
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoController(ILogger<ProjetoController> logger, IProjetoRepository projetoRepository)
        {
            _logger = logger;
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        [Route("GetAllProjetos")]
        public async Task<IList<Projeto>> GetAllProjetos()
        {
            var projetos = await _projetoRepository.GetAllProjetos();
            return projetos;
        }

        [HttpGet]
        [Route("GetProjetoById/{projetoId}")]
        public async Task<Projeto> GetProjetoById([FromRoute] int projetoId)
        {
            var projeto = await _projetoRepository.GetProjetoById(projetoId);
            return projeto;
        }

        [HttpPost]
        [Route("CreateProjeto")]
        public async Task<IActionResult> CreateProjeto([FromBody] Projeto projeto)
        {
            await _projetoRepository.CreateProjeto(projeto);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateProjeto")]
        public async Task<IActionResult> UpdateProjeto([FromBody] Projeto projeto)
        {
            await _projetoRepository.UpdateProjeto(projeto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteProjeto/{projetoId}")]
        public async Task<IActionResult> DeleteProjeto([FromRoute] int projetoId)
        {
            await _projetoRepository.RemoveProjeto(projetoId);
            return Ok();
        }

        
    }
}
