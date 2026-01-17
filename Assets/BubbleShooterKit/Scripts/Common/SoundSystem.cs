using System.Collections.Generic;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class SoundSystem : MonoBehaviour
	{
		public List<SoundCollection> Collections;

		ObjectPool soundFxPool;
		readonly Dictionary<string, AudioClip> nameToSound = new Dictionary<string, AudioClip>();

		void Awake()
		{
			if (!PlayerPrefs.HasKey("sound_enabled"))
				PlayerPrefs.SetInt("sound_enabled", 1);
			
			if (!PlayerPrefs.HasKey("music_enabled"))
				PlayerPrefs.SetInt("music_enabled", 1);
			
			soundFxPool = GetComponent<ObjectPool>();
			foreach (var collection in Collections)
				foreach (var sound in collection.Sounds)
					nameToSound.Add(sound.name, sound);
		}

		void Start()
		{
			soundFxPool.Initialize();
		}

		public void PlaySoundFx(string soundName)
		{
			var clip = nameToSound[soundName];
			if (clip != null)
				PlaySoundFx(clip);
		}

		void PlaySoundFx(AudioClip clip)
		{
            var sound = PlayerPrefs.GetInt("sound_enabled");
			if (sound == 1 && clip != null)
                soundFxPool.GetObject().GetComponent<SoundFx>().Play(clip);
		}
		
        public void SetSoundEnabled(bool soundEnabled)
        {
            PlayerPrefs.SetInt("sound_enabled", soundEnabled ? 1 : 0);
        }

        public void SetMusicEnabled(bool musicEnabled)
        {
            PlayerPrefs.SetInt("music_enabled", musicEnabled ? 1 : 0);
			var bgMusic = FindObjectOfType<BackgroundMusic>();
	        if (bgMusic != null)
	            bgMusic.GetComponent<AudioSource>().mute = !musicEnabled;
        }
	}
}
