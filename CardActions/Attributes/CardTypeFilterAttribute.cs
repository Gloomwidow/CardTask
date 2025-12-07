using CardActions.Enums;
using Cards.Enums;
using Cards.Models;

namespace CardActions.Attributes
{
    /// <summary>
    /// Allows (or disallows) action for card types listed in this filter
    /// </summary>
    public class CardTypeFilterAttribute : CardActionRuleAttribute
    {
        protected readonly CardActionRuleFilterType FilterType;
        protected readonly CardType[] CardTypes;

        public CardTypeFilterAttribute(CardActionRuleFilterType filterType, params CardType[] cardTypes)
        {
            this.FilterType = filterType;
            this.CardTypes = cardTypes.Distinct().ToArray();
        }

        public override bool IsCardSatysfyingRequirements(CardDetails details)
        {
            switch (FilterType)
            {
                case CardActionRuleFilterType.AllowOnlyListed:
                    return CardTypes.Contains(details.CardType);
                case CardActionRuleFilterType.BlockListed: 
                    return !CardTypes.Contains(details.CardType);
                default:
                    return false;
            }
        }
    }
}
