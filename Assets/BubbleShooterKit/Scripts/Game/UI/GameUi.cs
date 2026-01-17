using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class GameUi : MonoBehaviour
	{
		public ScoreWidget ScoreWidget;

		public void UpdateScore(int score)
		{
			ScoreWidget.UpdateProgressBar(score);
		}
	}
}
