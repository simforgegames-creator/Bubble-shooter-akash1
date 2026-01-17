using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{
    public class HorizontalBombBubble : BoosterBubble
    {
        public override List<Bubble> Resolve(Level level, Bubble shotBubble)
        {
	        var bubblesToExplode = new List<Bubble>();

	        for (var i = 0; i < level.Tiles[Row].Count; i++)
	        {
		        var bubble = level.Tiles[Row][i];
		        if (bubble != null)
			        bubblesToExplode.Add(bubble);
	        }

	        return bubblesToExplode;
        }
    }
}
