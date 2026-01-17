using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public static class SoundPlayer
	{
		static SoundSystem soundSystem;
		
		public static void Initialize()
		{
			soundSystem = Object.FindObjectOfType<SoundSystem>();
			// Assert.IsNotNull(soundSystem);
		}

		public static void PlaySoundFx(string soundName)
		{
			soundSystem.PlaySoundFx(soundName);
		}
		
        public static void SetSoundEnabled(bool soundEnabled)
        {
	        soundSystem.SetSoundEnabled(soundEnabled);
        }

        public static void SetMusicEnabled(bool musicEnabled)
        {
	        soundSystem.SetMusicEnabled(musicEnabled);
        }
	}
}
