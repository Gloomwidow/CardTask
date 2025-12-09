using Cards.Models;

namespace CardActions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class CardActionRuleAttribute : Attribute
    {
        /// <summary>
        /// Checks if card satisfies rules for the action connected to
        /// If all rules for action return true, then the action is allowed for tested card
        /// </summary>
        public abstract bool IsCardSatisfyingRequirements(CardDetails details);
    }
}
