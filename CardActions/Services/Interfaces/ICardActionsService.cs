using Cards.Models;

namespace CardActions.Services.Interfaces
{
    public interface ICardActionsService
    {
        public IEnumerable<string> GetAllowedCardActionsNames(CardDetails details);
    }
}
