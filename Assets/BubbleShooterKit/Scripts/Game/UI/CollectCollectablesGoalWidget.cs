namespace SimForge.Games.BubbleShooter.Blaze
{
	public class CollectCollectablesGoalWidget : LevelGoalWidget, IEventListener<CollectablesCollectedEvent>
	{
		CollectableBubbleType collectableType;
		int numBubbles;
		
		void Start()
		{
			EventManager.RegisterListener(this);
		}
		
		void OnDestroy()
		{
			EventManager.UnregisterListener(this);
		}

		public void Initialize(CollectableBubbleType type, int amount)
		{
			collectableType = type;	
			numBubbles = amount;
			TickImage.enabled = false;
		}
		
		public void HandleEvent(CollectablesCollectedEvent evt)
		{
			if (evt.Type == collectableType)
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


