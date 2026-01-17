namespace SimForge.Games.BubbleShooter.Blaze
{
	public class CollectableBubble : Bubble
	{
		public CollectableBubbleType Type;

		public override void ShowExplosionFx(FxPool fxPool)
		{
			var fx = fxPool.GetCollectableBubbleParticlePool(Type).GetObject();
			fx.transform.position = transform.position;
		}
	}
}
