using CardActions.Enums;
using Cards.Enums;
using Cards.Models;

namespace CardActions.Attributes
{
    /// <summary>
    /// Allows (or disallows) action for card with statuses listed in this filter
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CardStatusFilterAttribute : CardActionRuleAttribute
    {
        protected readonly CardActionRuleFilterType FilterType;
        protected readonly CardStatus[] CardStatuses;

        public CardStatusFilterAttribute(CardActionRuleFilterType filterType, params CardStatus[] cardStatuses)
        {
            this.FilterType = filterType;
            this.CardStatuses = cardStatuses.Distinct().ToArray();
        }

        public override bool IsCardSatysfyingRequirements(CardDetails details)
        {
            switch (FilterType)
            {
                case CardActionRuleFilterType.AllowOnlyListed:
                    return CardStatuses.Contains(details.CardStatus);
                case CardActionRuleFilterType.BlockListed:
                    return !CardStatuses.Contains(details.CardStatus);
                default:
                    return false;
            }
        }
    }
}
