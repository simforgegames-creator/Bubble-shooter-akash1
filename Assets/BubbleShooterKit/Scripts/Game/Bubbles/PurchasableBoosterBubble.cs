using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public abstract class PurchasableBoosterBubble : Bubble
	{
		public PurchasableBoosterBubbleType Type;

		public abstract List<Bubble> Resolve(Level level, Bubble shotBubble, Bubble touchedBubble);
	}
}


