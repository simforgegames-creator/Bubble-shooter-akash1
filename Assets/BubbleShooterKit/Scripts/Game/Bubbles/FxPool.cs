using System.Collections.Generic;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class FxPool : MonoBehaviour
	{
		public List<ObjectPool> ColorBubbleParticlePools;
		public List<ObjectPool> BlockerBubbleParticlePools;
		public List<ObjectPool> BoosterBubbleParticlePools;
		public List<ObjectPool> CollectableBubbleParticlePools;
		public List<ObjectPool> CoverParticlePools;
		public ObjectPool LeafParticlePool;
		public ObjectPool EnergyBubblePool;

		public ObjectPool GetColorBubbleParticlePool(ColorBubbleType type)
		{
			return ColorBubbleParticlePools[(int)type];
		}
		
		public ObjectPool GetBlockerBubbleParticlePool(BlockerBubbleType type)
		{
			return BlockerBubbleParticlePools[(int)type];
		}
		
		public ObjectPool GetBoosterBubbleParticlePool(BoosterBubbleType type)
		{
			return BoosterBubbleParticlePools[(int)type];
		}
		
		public ObjectPool GetCollectableBubbleParticlePool(CollectableBubbleType type)
		{
			return CollectableBubbleParticlePools[(int)type];
		}
		
		public ObjectPool GetCoverParticlePool(CoverType type)
		{
			return CoverParticlePools[(int)type];
		}
	}
}
