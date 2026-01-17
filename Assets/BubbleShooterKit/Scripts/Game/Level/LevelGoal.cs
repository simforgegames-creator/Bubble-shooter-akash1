using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public abstract class LevelGoal : ScriptableObject
	{
		public abstract bool IsComplete(GameState state);
		
#if UNITY_EDITOR
		public abstract void Draw();
#endif
	}
}
