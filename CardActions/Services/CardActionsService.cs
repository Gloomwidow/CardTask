using CardActions.Actions;
using CardActions.Attributes;
using CardActions.Services.Interfaces;
using Cards.Models;

namespace CardActions.Services
{
    public class CardActionsService : ICardActionsService
    {
        public Dictionary<string, CardActionRuleAttribute[]> ActionRules = PreloadActionRules();

        public List<string> GetAllowedCardActionsNames(CardDetails details)
        {
            var result = new List<string>();

            foreach (var actionRules in ActionRules)
            {
                bool isActionAllowed = true;
                foreach (var rule in actionRules.Value)
                {
                    if (!rule.IsCardSatysfyingRequirements(details))
                    {
                        isActionAllowed = false;
                        break;
                    }
                }

                if (isActionAllowed)
                {
                    result.Add(actionRules.Key);
                }
            }

            return result;
        }

        private static Dictionary<string, CardActionRuleAttribute[]> PreloadActionRules()
        {
            var result = new Dictionary<string, CardActionRuleAttribute[]>();
            var actionsList = AppDomain.CurrentDomain.GetAssemblies()
             .SelectMany(domainAssembly => domainAssembly.GetTypes())
             .Where(type => typeof(CardAction).IsAssignableFrom(type) && !type.IsAbstract).ToArray();

            foreach (var action in actionsList)
            {
                var attributeList = new List<CardActionRuleAttribute>();
                var actionInstance = Activator.CreateInstance(action) as CardAction;

                if (actionInstance == null)
                {
                    throw new ArgumentNullException($"Could not cache {nameof(action)}");
                }

                var filterAttributes = action.GetCustomAttributes(typeof(CardActionRuleAttribute), true);

                foreach (var filterAttribute in filterAttributes)
                {
                    var cardRule = filterAttribute as CardActionRuleAttribute;
                    if (cardRule != null)
                    {
                        attributeList.Add(cardRule);
                    }
                }

                result.Add(actionInstance.Name, attributeList.ToArray());
            }

            return result;
        }
    }
}
