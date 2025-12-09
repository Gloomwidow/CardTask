using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.BlockListed, CardStatus.Restricted, CardStatus.Expired, CardStatus.Closed)]
    public class CardAction8 : CardAction
    {
        public CardAction8() : base("ACTION8") { }
    }
}
