using CardActions.Attributes;
using CardActions.Enums;
using Cards.Enums;

namespace CardActions.Actions
{
    [CardTypeFilter(CardActionRuleFilterType.BlockListed, CardType.Prepaid, CardType.Debit)]
    public class CardAction5 : CardAction
    {
        public CardAction5() : base("ACTION5") { }
    }
}
