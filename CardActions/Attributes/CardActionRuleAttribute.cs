using Cards.Models;

namespace CardActions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class CardActionRuleAttribute : Attribute
    {
        public abstract bool IsCardSatysfyingRequirements(CardDetails details);
    }
}
