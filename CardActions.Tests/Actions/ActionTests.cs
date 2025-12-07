using CardActions.Services;
using Cards.Enums;
using Cards.Models;
using Microsoft.VisualBasic;

namespace CardActions.Tests.Actions
{
    [TestClass]
    public class ActionTests()
    {
        private CardActionsService service = new CardActionsService();

        [TestMethod]
        public void IsAction1MappedCorrectlyForCardsTypes()
        {
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                var card = new CardDetails(
                                CardNumber: "1",
                                CardType: cardType,
                                CardStatus: CardStatus.Active,
                                IsPinSet: true);

                var actions = service.GetAllowedCardActionsNames(card);
                Assert.Contains("ACTION1", actions);
            }
        }

        [TestMethod]
        public void IsAction1MappedCorrectlyForCardStatuses()
        {
            foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
            {
                var card = new CardDetails(
                                CardNumber: "11",
                                CardType: CardType.Debit,
                                CardStatus: cardStatus,
                                IsPinSet: true);

                var actions = service.GetAllowedCardActionsNames(card);
                if (cardStatus == CardStatus.Active) Assert.Contains("ACTION1", actions);
                else Assert.DoesNotContain("ACTION1", actions);
            }
        }

        [TestMethod]
        public void IsAction5MappedCorrectlyForCardTypes()
        {
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                var card = new CardDetails(
                                CardNumber: "5",
                                CardType: cardType,
                                CardStatus: CardStatus.Ordered,
                                IsPinSet: true);

                var actions = service.GetAllowedCardActionsNames(card);
                if (cardType == CardType.Credit) Assert.Contains("ACTION5", actions);
                else Assert.DoesNotContain("ACTION5", actions);
            }
        }

        [TestMethod]
        public void IsAction6MappedCorrectlyForCardWithoutPin()
        {
            foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
            {
                var card = new CardDetails(
                                CardNumber: "6",
                                CardType: CardType.Debit,
                                CardStatus: cardStatus,
                                IsPinSet: false);

                var actions = service.GetAllowedCardActionsNames(card);
                Assert.DoesNotContain("ACTION6", actions);
            }
        }

        [TestMethod]
        public void IsAction6MappedCorrectlyForCardWithPin()
        {
            var blockedStatuses = new List<CardStatus>() { 
                CardStatus.Restricted,
                CardStatus.Expired, 
                CardStatus.Closed };

            foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
            {
                var card = new CardDetails(
                                CardNumber: "66",
                                CardType: CardType.Debit,
                                CardStatus: cardStatus,
                                IsPinSet: true);

                var actions = service.GetAllowedCardActionsNames(card);
                if (blockedStatuses.Contains(cardStatus)) Assert.DoesNotContain("ACTION6", actions);
                else Assert.Contains("ACTION6", actions);
            }
        }

        [TestMethod]
        public void IsAction7MappedCorrectlyForCardWithoutPin()
        {
            var blockedStatuses = new List<CardStatus>() {
                CardStatus.Restricted,
                CardStatus.Blocked,
                CardStatus.Expired,
                CardStatus.Closed };

            foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
            {
                var card = new CardDetails(
                                CardNumber: "7",
                                CardType: CardType.Debit,
                                CardStatus: cardStatus,
                                IsPinSet: false);

                var actions = service.GetAllowedCardActionsNames(card);
                if (blockedStatuses.Contains(cardStatus)) Assert.DoesNotContain("ACTION7", actions);
                else Assert.Contains("ACTION7", actions);
            }
        }

        [TestMethod]
        public void IsAction7MappedCorrectlyForCardWithtPin()
        {
            foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
            {
                var card = new CardDetails(
                                CardNumber: "77",
                                CardType: CardType.Debit,
                                CardStatus: cardStatus,
                                IsPinSet: true);

                var actions = service.GetAllowedCardActionsNames(card);
                if (cardStatus == CardStatus.Blocked) Assert.Contains("ACTION7", actions);
                else Assert.DoesNotContain("ACTION7", actions);
            }
        }
    }
}
