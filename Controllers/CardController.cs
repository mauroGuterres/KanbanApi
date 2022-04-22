using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanAPI.Context.Entities;
using KanbanAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KanbanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        

        private readonly ILogger<CardController> _logger;
        private readonly ICardRepository _cardRepository;

        public CardController(ILogger<CardController> logger, ICardRepository cardRepository)
        {
            _logger = logger;
            _cardRepository = cardRepository;
        }

        [HttpGet]
        [Route("GetAllCards")]
        public async Task<IList<Card>> GetAllCards() {
            var cards = await _cardRepository.GetAllCards();
            return cards;
        }

        [HttpGet]
        [Route("GetCardById/{cardId}")]
        public async Task<Card> GetCardById([FromRoute] int cardId)
        {
            var card = await _cardRepository.GetCardById(cardId);
            return card;
        }

        [HttpPost]
        [Route("CreateCard")]
        public async Task<IActionResult> CreateCard([FromBody] Card card) {
            await _cardRepository.CreateCard(card);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCard")]
        public  async Task<IActionResult> UpdateCard([FromBody] Card card)
        {
            await _cardRepository.UpdateCard(card);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCard/{cardId}")]
        public async Task<IActionResult> DeleteCard([FromRoute] int cardId)
        {
            await _cardRepository.RemoveCard(cardId);
            return Ok();
        }

        [HttpGet]
        [Route("GetCardsByColuna")]
        public async Task<IList<Card>> GetCardsByColuna([FromQuery(Name = "colunas")] int[] colunas) {
            var cards = await _cardRepository.GetCardsByColunas(colunas);
            return cards;
        }

        [HttpPut]
        [Route("UpdateVerticalCardPosition/card/{cardId}/position/{newPosition}")]
        public async Task<IActionResult> UpdateVerticalCardPosition([FromRoute] int cardId, int newPosition) {
            await _cardRepository.UpdateVerticalCardPosition(cardId, newPosition);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCardHorizontalPosition/{cardId}/coluna/{newColunaId}/position/{newPosition}")]
        public async Task<IActionResult> UpdateCardHorizontalPosition([FromRoute] int cardId, int newColunaId, int newPosition)
        {
            await _cardRepository.UpdateHorizontalCardPosition(cardId, newColunaId, newPosition);
            return Ok();
        }



    }
}
