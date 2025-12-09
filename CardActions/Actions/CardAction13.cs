using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction13 : CardAction
    {
        public CardAction13() : base("ACTION13") { }
    }
}
