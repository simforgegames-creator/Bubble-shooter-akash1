using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class CloudCover : BubbleCover
	{
		FxPool destructionFxPool;

		SpriteRenderer spriteRenderer;
		Sprite originalSprite;
		
		void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			originalSprite = spriteRenderer.sprite;
		}

		void OnDisable()
		{
			spriteRenderer.sprite = originalSprite;
			spriteRenderer.sortingOrder = 2;
		}
	}
}
