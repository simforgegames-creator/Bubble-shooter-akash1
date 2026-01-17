namespace SimForge.Games.BubbleShooter.Blaze
{



    public struct CollectablesCollectedEvent
    {
        public readonly CollectableBubbleType Type;
        public readonly int Amount;

        public CollectablesCollectedEvent(CollectableBubbleType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
