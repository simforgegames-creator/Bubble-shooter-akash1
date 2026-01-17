using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class ColorBombBubble : BoosterBubble
	{
		public override List<Bubble> Resolve(Level level, Bubble shotBubble)
		{
	        var bubblesToExplode = new List<Bubble>();

			if (shotBubble.GetComponent<ColorBubble>() != null)
			{
				foreach (var row in level.Tiles)
				{
					foreach (var bubble in row)
					{
						if (bubble != null &&
						    bubble.GetComponent<ColorBubble>() != null &&
						    bubble.GetComponent<ColorBubble>().Visible &&
						    bubble.GetComponent<ColorBubble>().Type == shotBubble.GetComponent<ColorBubble>().Type)
						{
							bubblesToExplode.Add(bubble);
						}
					}
				}
			}

			bubblesToExplode.Add(this);
			
			return bubblesToExplode;
		}
	}
}
