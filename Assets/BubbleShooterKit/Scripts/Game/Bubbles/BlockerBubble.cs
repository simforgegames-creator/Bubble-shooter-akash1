namespace SimForge.Games.BubbleShooter.Blaze
{
	public class BlockerBubble : Bubble
	{
		public BlockerBubbleType Type;
		
		public override void ShowExplosionFx(FxPool fxPool)
		{
			var fx = fxPool.GetBlockerBubbleParticlePool(Type).GetObject();
			fx.transform.position = transform.position;
		}

		public override bool CanBeDestroyed()
		{
			return Type != BlockerBubbleType.IronBubble;
		}
	}
}
