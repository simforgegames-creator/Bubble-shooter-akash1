namespace SimForge.Games.BubbleShooter.Blaze
{



    public struct LeavesCollectedEvent
    {
        public readonly int Amount;

        public LeavesCollectedEvent(int amount)
        {
            Amount = amount;
        }
    }
}
