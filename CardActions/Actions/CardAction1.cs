using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Active)]
    public class CardAction1 : CardAction
    {
        public CardAction1() : base("ACTION1") { }
    }
}
