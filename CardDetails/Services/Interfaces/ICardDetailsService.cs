using Cards.Models;

namespace Cards.Services.Interfaces
{
    public interface ICardDetailsService
    {
        public Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
    }
}
