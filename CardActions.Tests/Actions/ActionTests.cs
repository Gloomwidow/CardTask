using CardActions.Services;
using Cards.Enums;
using Cards.Models;

namespace CardActions.Tests.Actions
{
    [TestClass]
    public class ActionTests()
    {
        private readonly bool[] pinSetValues = [true, false];
        private CardActionsService service = new CardActionsService();

        [TestMethod]
        public void IsAction1MappedCorrectlyForCardsTypes()
        {
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (var isPinSet in pinSetValues)
                {
                    var card = new CardDetails(
                                CardNumber: "1",
                                CardType: cardType,
                                CardStatus: CardStatus.Active,
                                IsPinSet: isPinSet);

                    var actions = service.GetAllowedCardActionsNames(card);
                    Assert.Contains("ACTION1", actions);
                }
            }
        }

        [TestMethod]
        public void IsAction1MappedCorrectlyForCardStatuses()
        {
            foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
            {
                foreach (var isPinSet in pinSetValues)
                {
                    var card = new CardDetails(
                                CardNumber: "11",
                                CardType: CardType.Debit,
                                CardStatus: cardStatus,
                                IsPinSet: isPinSet);

                    var actions = service.GetAllowedCardActionsNames(card);
                    if (cardStatus == CardStatus.Active) Assert.Contains("ACTION1", actions);
                    else Assert.DoesNotContain("ACTION1", actions);
                }
            }
        }

        [TestMethod]
        public void IsAction2MappedCorrectlyForAnyCard()
        {
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "2",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        if (cardStatus == CardStatus.Inactive) Assert.Contains("ACTION2", actions);
                        else Assert.DoesNotContain("ACTION2", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction3MappedCorrectlyForAnyCard()
        {

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "3",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        Assert.Contains("ACTION3", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction4MappedCorrectlyForAnyCard()
        {

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "4",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        Assert.Contains("ACTION4", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction5MappedCorrectlyForCardTypes()
        {
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                CardNumber: "5",
                                CardType: cardType,
                                CardStatus: cardStatus,
                                IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        if (cardType == CardType.Credit) Assert.Contains("ACTION5", actions);
                        else Assert.DoesNotContain("ACTION5", actions);
                    }
                }
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
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    var card = new CardDetails(
                                    CardNumber: "66",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: true);

                    var actions = service.GetAllowedCardActionsNames(card);
                    if (blockedStatuses.Contains(cardStatus)) Assert.DoesNotContain("ACTION6", actions);
                    else Assert.Contains("ACTION6", actions);
                }
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
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    var card = new CardDetails(
                                    CardNumber: "7",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: false);

                    var actions = service.GetAllowedCardActionsNames(card);
                    if (blockedStatuses.Contains(cardStatus)) Assert.DoesNotContain("ACTION7", actions);
                    else Assert.Contains("ACTION7", actions);
                }
            }
        }

        [TestMethod]
        public void IsAction7MappedCorrectlyForCardWithPin()
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

        [TestMethod]
        public void IsAction8MappedCorrectlyForAnyCard()
        {
            var blockedStatuses = new List<CardStatus>() {
                CardStatus.Restricted,
                CardStatus.Expired,
                CardStatus.Closed };

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "8",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        if (blockedStatuses.Contains(cardStatus)) Assert.DoesNotContain("ACTION8", actions);
                        else Assert.Contains("ACTION8", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction9MappedCorrectlyForAnyCard()
        {

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "9",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        Assert.Contains("ACTION9", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction10MappedCorrectlyForAnyCard()
        {
            var allowedStatuses = new List<CardStatus>() {
                CardStatus.Ordered,
                CardStatus.Inactive,
                CardStatus.Active };

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "10",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        if (allowedStatuses.Contains(cardStatus)) Assert.Contains("ACTION10", actions);
                        else Assert.DoesNotContain("ACTION10", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction11MappedCorrectlyForAnyCard()
        {
            var allowedStatuses = new List<CardStatus>() {
                CardStatus.Inactive,
                CardStatus.Active };

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "11",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        if (allowedStatuses.Contains(cardStatus)) Assert.Contains("ACTION11", actions);
                        else Assert.DoesNotContain("ACTION11", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction12MappedCorrectlyForAnyCard()
        {
            var allowedStatuses = new List<CardStatus>() {
                CardStatus.Ordered,
                CardStatus.Inactive,
                CardStatus.Active };

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "12",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        if (allowedStatuses.Contains(cardStatus)) Assert.Contains("ACTION12", actions);
                        else Assert.DoesNotContain("ACTION12", actions);
                    }
                }
            }
        }

        [TestMethod]
        public void IsAction13MappedCorrectlyForAnyCard()
        {
            var allowedStatuses = new List<CardStatus>() {
                CardStatus.Ordered,
                CardStatus.Inactive,
                CardStatus.Active };
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    foreach (var isPinSet in pinSetValues)
                    {
                        var card = new CardDetails(
                                    CardNumber: "13",
                                    CardType: cardType,
                                    CardStatus: cardStatus,
                                    IsPinSet: isPinSet);

                        var actions = service.GetAllowedCardActionsNames(card);
                        if (allowedStatuses.Contains(cardStatus)) Assert.Contains("ACTION13", actions);
                        else Assert.DoesNotContain("ACTION13", actions);
                    }
                }
            }
        }
    }
}
