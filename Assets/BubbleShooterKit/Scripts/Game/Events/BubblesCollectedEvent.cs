namespace SimForge.Games.BubbleShooter.Blaze
{



    public struct BubblesCollectedEvent
    {
        public readonly ColorBubbleType Type;
        public readonly int Amount;

        public BubblesCollectedEvent(ColorBubbleType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
