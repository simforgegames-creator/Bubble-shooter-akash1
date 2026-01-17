using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	[Serializable]
	public class LevelRow : ScriptableObject
	{
		public List<TileInfo> Tiles;
	}
}
