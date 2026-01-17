using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class RainbowBoosterBubble : PurchasableBoosterBubble
	{
		public override List<Bubble> Resolve(Level level, Bubble shotBubble, Bubble touchedBubble)
		{
			var bubblesToExplode = new List<Bubble>();
			var touchedColorBubble = touchedBubble.GetComponent<ColorBubble>();
			if (touchedColorBubble != null)
				bubblesToExplode.AddRange(LevelUtils.GetMatches(level, touchedColorBubble));
			bubblesToExplode.Add(this);
			return bubblesToExplode;
		}
	}
}
