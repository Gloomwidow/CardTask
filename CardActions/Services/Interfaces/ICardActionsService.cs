using Cards.Models;

namespace CardActions.Services.Interfaces
{
    public interface ICardActionsService
    {
        public List<string> GetAllowedCardActionsNames(CardDetails details);
    }
}
