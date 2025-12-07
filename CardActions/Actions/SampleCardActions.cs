using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    // I assume that all those actions are not just structs for string, but real life operations
    // Like pay for something, chargeback, add $1B etc.
    // (I assume they would have some code logic behind each one)
    // therefore, I'm declaring them explicitely here

    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Active)]
    public class CardAction1 : CardAction
    {
        public CardAction1() : base("ACTION1") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Inactive)]
    public class CardAction2 : CardAction
    {
        public CardAction2() : base("ACTION2") { }
    }

    public class CardAction3 : CardAction
    {
        public CardAction3() : base("ACTION3") { }
    }

    public class CardAction4 : CardAction
    {
        public CardAction4() : base("ACTION4") { }
    }

    [CardTypeFilter(CardActionRuleFilterType.BlockListed, CardType.Prepaid, CardType.Debit)]
    public class CardAction5 : CardAction
    {
        public CardAction5() : base("ACTION5") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.BlockListed, CardStatus.Restricted, CardStatus.Expired, CardStatus.Closed)]
    [AllowCardStatusOnPinStatus(true, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Blocked)]
    public class CardAction6 : CardAction
    {
        public CardAction6() : base("ACTION6") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.BlockListed, CardStatus.Restricted, CardStatus.Expired, CardStatus.Closed)]
    [AllowCardStatusOnPinStatus(false, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    [AllowCardStatusOnPinStatus(true, CardStatus.Blocked)]
    public class CardAction7 : CardAction
    {
        public CardAction7() : base("ACTION7") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.BlockListed, CardStatus.Restricted, CardStatus.Expired, CardStatus.Closed)]
    public class CardAction8 : CardAction
    {
        public CardAction8() : base("ACTION8") { }
    }

    public class CardAction9 : CardAction
    {
        public CardAction9() : base("ACTION9") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction10 : CardAction
    {
        public CardAction10() : base("ACTION10") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction11 : CardAction
    {
        public CardAction11() : base("ACTION11") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction12 : CardAction
    {
        public CardAction12() : base("ACTION12") { }
    }

    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction13 : CardAction
    {
        public CardAction13() : base("ACTION13") { }
    }
}
