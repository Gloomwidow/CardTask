using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.BlockListed, CardStatus.Restricted, CardStatus.Expired, CardStatus.Closed)]
    [AllowCardStatusOnPinStatus(true, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Blocked)]
    public class CardAction6 : CardAction
    {
        public CardAction6() : base("ACTION6") { }
    }
}
