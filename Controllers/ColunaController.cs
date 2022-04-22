using KanbanAPI.Context.Entities;
using KanbanAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColunaController : ControllerBase
    {
        private readonly ILogger<ColunaController> _logger;
        private readonly IColunaRepository _colunaRepository;

        public ColunaController(ILogger<ColunaController> logger, IColunaRepository colunaRepository)
        {
            _logger = logger;
            _colunaRepository = colunaRepository;
        }

        [HttpGet]
        public async Task<IList<Coluna>> GetAllColuna()
        {
            var Colunas = await _colunaRepository.GetAllColunas();
            return Colunas;
        }

        [HttpPost]
        [Route("CreateColuna")]
        public async Task<IActionResult> CreateColuna([FromBody] Coluna coluna) {
            await _colunaRepository.CreateColuna(coluna);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateColuna")]
        public async Task<IActionResult> UpdateColuna([FromBody] Coluna coluna)
        {
            await _colunaRepository.UpdateColuna(coluna);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteColuna/{colunaId}")]
        public async Task<IActionResult> DeleteColuna([FromRoute] int colunaId)
        {
            await _colunaRepository.RemoveColuna(colunaId);
            return Ok();
        }

        [HttpGet]
        [Route("GetColunasById")]
        public async Task<IList<Coluna>> GetColunasByColuna([FromQuery(Name = "colunas")] int[] colunas)
        {
            var Colunas = await _colunaRepository.GetColunasById(colunas);
            return Colunas;
        }

        [HttpGet]
        [Route("GetColunaById/{colunaId}")]
        public async Task<Coluna> GetColunaByColuna([FromRoute] int colunaId)
        {
            var coluna = await _colunaRepository.GetColunaById(colunaId);
            return coluna;
        }


    }
}
