using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class BombBoosterBubble : PurchasableBoosterBubble
	{
		public override List<Bubble> Resolve(Level level, Bubble shotBubble, Bubble touchedBubble)
		{
			var bubblesToExplode = new List<Bubble>();
			bubblesToExplode.AddRange(LevelUtils.GetNeighbours(level, this));
			bubblesToExplode.Add(this);
			return bubblesToExplode;
		}
	}
}
