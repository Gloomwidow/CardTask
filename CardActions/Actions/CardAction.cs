namespace CardActions.Actions
{
    // I assume that Actions are not just strings, but could be real life actions on cards
    // Hence the class declaration
    public abstract class CardAction
    {
        public readonly string Name;

        public CardAction(string name)
        {
            this.Name = name;
        }
    }
}
