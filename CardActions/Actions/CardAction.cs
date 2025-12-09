namespace CardActions.Actions
{
    public abstract class CardAction
    {
        public string Name { get; private set; }

        public CardAction(string name)
        {
            this.Name = name;
        }
    }
}
