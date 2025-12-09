using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction12 : CardAction
    {
        public CardAction12() : base("ACTION12") { }
    }
}
