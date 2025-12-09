using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Inactive)]
    public class CardAction2 : CardAction
    {
        public CardAction2() : base("ACTION2") { }
    }
}
