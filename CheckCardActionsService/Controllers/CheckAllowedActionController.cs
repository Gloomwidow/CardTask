using CardActions.Services.Interfaces;
using Cards.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckCardActionsService.Controllers
{
    [Route("api/cardActions")]
    [ApiController]
    public class CheckAllowedActionController : ControllerBase
    {
        private readonly ICardDetailsService cardDetailsService;
        private readonly ICardActionsService cardActionsService;

        public CheckAllowedActionController(ICardDetailsService cardDetailsService, ICardActionsService cardActionsService)
        {
            this.cardDetailsService = cardDetailsService;
            this.cardActionsService = cardActionsService;
        }

        [HttpGet("user/{userId}/card/{cardNumber}/allowed")]
        public async Task<IActionResult> GetAllowedActionsForCard(string userId, string cardNumber)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("userId is empty");
            }

            if (string.IsNullOrEmpty(cardNumber))
            {
                return BadRequest("cardNumber is empty");
            }

            var getCardDetailsTask = this.cardDetailsService.GetCardDetails(userId, cardNumber);

            // if that would be a call to external api, we could also check status code and react appropriately

            try
            {
                await getCardDetailsTask;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occured while retrieving card details: {ex.Message}");
            }

            if (getCardDetailsTask.Result == null)
            {
                return NotFound($"Card with supplied details not found...");
            }

            var allowedActionNames = cardActionsService.GetAllowedCardActionsNames(getCardDetailsTask.Result);

            return Ok(allowedActionNames);
        }
    }
}
