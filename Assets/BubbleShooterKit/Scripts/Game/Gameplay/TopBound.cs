using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class TopBound : MonoBehaviour
	{
		GameScreen gameScreen;

		void Start()
		{
			gameScreen = GameObject.Find("GameScreen").GetComponent<GameScreen>();
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			var bubble = other.GetComponent<Bubble>();
			if (bubble != null && !bubble.CollidingWithAnotherBubble && gameScreen != null)
			{
				gameScreen.GameLogic.HandleTopRowMatches(bubble);
			}
		}
	}
}
