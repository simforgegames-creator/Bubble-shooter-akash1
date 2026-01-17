using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class Fox : MonoBehaviour
	{
		Animator bodyAnimator;
		[SerializeField]
		Animator armsAnimator = null;

		void Awake()
		{
			bodyAnimator = GetComponent<Animator>();
		}
		
		public void PlayHappyAnimation()
		{
			bodyAnimator.SetTrigger("Happy");
		}

		public void PlaySadAnimation()
		{
			bodyAnimator.SetTrigger("Sad");
		}

		public void PlayShootingAnimation()
		{
			armsAnimator.SetTrigger("Shooting");
		}
	}
}
