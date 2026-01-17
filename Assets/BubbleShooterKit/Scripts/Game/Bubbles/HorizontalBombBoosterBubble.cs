using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class HorizontalBombBoosterBubble : PurchasableBoosterBubble
	{
        public override List<Bubble> Resolve(Level level, Bubble shotBubble, Bubble touchedBubble)
        {
	        var bubblesToExplode = new List<Bubble>();
	        
	        for (var i = 0; i < level.Tiles[touchedBubble.Row].Count; i++)
	        {
		        var bubble = level.Tiles[touchedBubble.Row][i];
		        if (bubble != null)
			        bubblesToExplode.Add(bubble);
	        }

	        return bubblesToExplode;
        }
	}
}
