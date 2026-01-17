using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	[RequireComponent(typeof(AudioSource))]
	public class SoundFx : MonoBehaviour
	{
		AudioSource audioSource;

		void Awake()
		{
			audioSource = GetComponent<AudioSource>();
		}

		public void Play(AudioClip clip)
		{
			if (clip != null)
			{
				audioSource.clip = clip;
				audioSource.Play();
				Invoke(nameof(KillSoundFx), clip.length + 0.1f);
			}
		}

		void KillSoundFx()
		{
			GetComponent<PooledObject>().Pool.ReturnObject(gameObject);
		}
	}
}
