namespace SimForge.Games.BubbleShooter.Blaze
{
	public class CollectBubblesGoalWidget : LevelGoalWidget, IEventListener<BubblesCollectedEvent>
	{
		ColorBubbleType colorBubbleType;
		int numBubbles;
		
		void Start()
		{
			EventManager.RegisterListener(this);
		}

		void OnDestroy()
		{
			EventManager.UnregisterListener(this);
		}

		public void Initialize(ColorBubbleType type, int amount)
		{
			colorBubbleType = type;	
			numBubbles = amount;
			TickImage.enabled = false;
		}
		
		public void HandleEvent(BubblesCollectedEvent evt)
		{
			if (evt.Type == colorBubbleType)
			{
				numBubbles -= evt.Amount;
				if (numBubbles <= 0)
				{
					if (!TickImage.enabled)
						SoundPlayer.PlaySoundFx("ReachedGoal");
					TickImage.enabled = true;
					numBubbles = 0;
				}
				Text.text = numBubbles.ToString();
			}
		}
	}
}
