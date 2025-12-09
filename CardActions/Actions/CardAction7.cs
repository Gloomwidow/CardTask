using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardStatusFilter(CardActionRuleFilterType.BlockListed, CardStatus.Restricted, CardStatus.Expired, CardStatus.Closed)]
    [AllowCardStatusOnPinStatus(false, CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active)]
    [AllowCardStatusOnPinStatus(true, CardStatus.Blocked)]
    public class CardAction7 : CardAction
    {
        public CardAction7() : base("ACTION7") { }
    }
}
