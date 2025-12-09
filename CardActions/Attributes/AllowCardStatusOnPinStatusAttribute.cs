using Cards.Enums;
using Cards.Models;

namespace CardActions.Attributes
{
    /// <summary>
    /// Allows action for card if card has one of the listed status and pin status is same as in this filter
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AllowCardStatusOnPinStatusAttribute : CardActionRuleAttribute
    {
        protected readonly bool IsPinSet;
        protected readonly CardStatus[] CardStatuses;

        public AllowCardStatusOnPinStatusAttribute(bool isPinSet, params CardStatus[] cardStatuses)
        {
            this.IsPinSet = isPinSet;
            this.CardStatuses = cardStatuses;
        }

        public override bool IsCardSatisfyingRequirements(CardDetails details)
        {
            if (!CardStatuses.Contains(details.CardStatus))
            {
                return true;
            }

            return details.IsPinSet == this.IsPinSet;
        }
    }
}
