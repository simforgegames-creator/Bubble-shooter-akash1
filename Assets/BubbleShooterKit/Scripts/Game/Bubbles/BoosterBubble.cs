using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public abstract class BoosterBubble : Bubble
	{
		public BoosterBubbleType Type;

		public abstract List<Bubble> Resolve(Level level, Bubble shotBubble);
		
		public override void ShowExplosionFx(FxPool fxPool)
		{
			var fx = fxPool.GetBoosterBubbleParticlePool(Type).GetObject();
			fx.transform.position = transform.position;
		}
	}
}
