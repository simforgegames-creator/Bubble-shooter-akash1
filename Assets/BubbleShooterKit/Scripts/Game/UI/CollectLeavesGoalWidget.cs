namespace SimForge.Games.BubbleShooter.Blaze
{
	public class CollectLeavesGoalWidget : LevelGoalWidget, IEventListener<LeavesCollectedEvent>
	{
		int numLeaves;
		
		void Start()
		{
			EventManager.RegisterListener(this);
		}
		
		void OnDestroy()
		{
			EventManager.UnregisterListener(this);
		}

		public void Initialize(int amount)
		{
			numLeaves = amount;
			TickImage.enabled = false;
		}
		
		public void HandleEvent(LeavesCollectedEvent evt)
		{
			numLeaves -= evt.Amount;
			if (numLeaves <= 0)
			{
				if (!TickImage.enabled)
					SoundPlayer.PlaySoundFx("ReachedGoal");
				TickImage.enabled = true;
				numLeaves = 0;
			}
			Text.text = numLeaves.ToString();
		}
	}
}
