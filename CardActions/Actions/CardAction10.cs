using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction10 : CardAction
    {
        public CardAction10() : base("ACTION10") { }
    }
}
