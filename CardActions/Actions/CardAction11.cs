using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.AllowOnlyListed, CardStatus.Inactive, CardStatus.Active)]
    public class CardAction11 : CardAction
    {
        public CardAction11() : base("ACTION11") { }
    }
}
