using KanbanAPI.Context.Entities;
using KanbanAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController : ControllerBase
    {


        private readonly ILogger<ColaboradorController> _logger;
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(ILogger<ColaboradorController> logger, IColaboradorRepository colaboradorRepository)
        {
            _logger = logger;
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        [Route("GetAllColaboradores")]
        public async Task<IList<Colaborador>> GetAllColaboradores()
        {
            var colaboradores = await _colaboradorRepository.GetAllColaboradores();
            return colaboradores;
        }

        [HttpGet]
        [Route("GetColaboradorById/{colaboradorId}")]
        public async Task<Colaborador> GetcolaboradorById([FromRoute] int colaboradorId)
        {
            var colaborador = await _colaboradorRepository.GetColaboradorById(colaboradorId);
            return colaborador;
        }

        [HttpPost]
        [Route("CreateColaborador")]
        public async Task<IActionResult> CreateColaborador([FromBody] Colaborador colaborador)
        {
            await _colaboradorRepository.AddColaborador(colaborador);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateColaborador")]
        public async Task<IActionResult> UpdateColaborador([FromBody] Colaborador colaborador)
        {
            await _colaboradorRepository.UpdateColaborador(colaborador);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteColaborador/{colaboradorId}")]
        public async Task<IActionResult> DeleteColaborador([FromRoute] int colaboradorId)
        {
            await _colaboradorRepository.RemoveColaborador(colaboradorId);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteColaboradorCard/{colaboradorId}/card/{cardId}")]
        public async Task<IActionResult> DeleteColaboradorCard([FromRoute] int colaboradorId, int cardId)
        {
            await _colaboradorRepository.RemoveColaboradorCard(colaboradorId, cardId);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteColaboradoresCard/{colaboradorId}/card/{cardId}")]
        public async Task<IActionResult> DeleteColaboradoresCard([FromQuery] int[] colaboradorId, int cardId)
        {
            await _colaboradorRepository.RemoveColaboradoresCard(colaboradorId, cardId);
            return Ok();
        }

        [HttpGet]
        [Route("GetColaboradorByCard/{cardId}")]
        public async Task<IList<Colaborador>> GetColaboradorByCard([FromRoute] int cardId)
        {
            var colaboradors = await _colaboradorRepository.GetColaboradorByCard(cardId);
            return colaboradors;
        }

        [HttpPost]
        [Route("AddColaboradorCard")]
        public async Task<IActionResult> AddcolaboradorCard([FromBody]int colaboradorId, int cardId)
        {
            await _colaboradorRepository.AddColaboradorCard(colaboradorId, cardId);
            return Ok();
        }

        [HttpPost]
        [Route("AddColaboradoresCard")]
        public async Task<IActionResult> AddcolaboradoresCard([FromBody] int[] colaboradoresId, int cardId)
        {
            await _colaboradorRepository.AddColaboradoresCard(colaboradoresId, cardId);
            return Ok();
        }





    }
}
