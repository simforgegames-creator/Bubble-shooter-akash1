using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class GoalItem : MonoBehaviour
	{
		[SerializeField]
		Image bubbleImage = null;

		[SerializeField]
		TextMeshProUGUI amountText = null;

		public void Initialize(Sprite sprite, int amount)
		{
			bubbleImage.sprite = sprite;
			amountText.text = amount.ToString();
		}
	}
}
