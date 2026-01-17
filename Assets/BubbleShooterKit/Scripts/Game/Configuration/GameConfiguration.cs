using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	[Serializable]
	[CreateAssetMenu(fileName = "GameConfiguration", menuName = "Bubble Shooter Kit/Game configuration", order = 0)]
	public class GameConfiguration : ScriptableObject
	{
		public int DefaultBubbleScore;

		public int MaxLives;
		public int TimeToNextLife;
		public int LivesRefillCost;

		public int InitialCoins;

		public int SuperAimBoosterAmount;
		public int SuperAimBoosterPrice;
		public int RainbowBubbleBoosterAmount;
		public int RainbowBubbleBoosterPrice;
		public int HorizontalBombBoosterAmount;
		public int HorizontalBombBoosterPrice;
		public int CircleBombBoosterAmount;
		public int CircleBombBoosterPrice;

		public int NumExtraBubbles;
		public int ExtraBubblesCost;

        public string AdsGameIdIos;
        public string AdsGameIdAndroid;
        public bool AdsTestMode;
        public int RewardedAdCoins;
		public List<IapItem> IapItems;
	}
}
