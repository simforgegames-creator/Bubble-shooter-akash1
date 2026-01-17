using UnityEngine;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class EndGameGoalWidget : MonoBehaviour
	{
		public Image Image;
		public Image TickImage;
		public Image CrossImage;

		public void Initialize(bool completed, LevelGoalWidget widget)
		{
			Image.sprite = widget.Image.sprite;
			TickImage.enabled = completed;
			CrossImage.enabled = !completed;
		}
	}
}
