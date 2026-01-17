using System.Collections.Generic;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	[CreateAssetMenu(fileName = "SoundCollection", menuName = "Bubble Shooter Kit/Sound collection", order = 2)]
	public class SoundCollection : ScriptableObject
	{
		public List<AudioClip> Sounds;
	}
}
