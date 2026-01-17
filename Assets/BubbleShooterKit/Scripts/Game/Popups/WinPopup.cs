using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class WinPopup : EndGamePopup
	{
		[SerializeField]
        Image star1 = null;

        [SerializeField]
        Image star2 = null;

        [SerializeField]
        Image star3 = null;

        [SerializeField]
        ParticleSystem star1Particles = null;

        [SerializeField]
        ParticleSystem star2Particles = null;

        [SerializeField]
        ParticleSystem star3Particles = null;

        [SerializeField]
        Sprite disabledStarSprite = null;

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(star1);
            Assert.IsNotNull(star2);
            Assert.IsNotNull(star3);
            Assert.IsNotNull(star1Particles);
            Assert.IsNotNull(star2Particles);
            Assert.IsNotNull(star3Particles);
            Assert.IsNotNull(disabledStarSprite);
        }

        public void SetStars(int stars)
        {
            if (stars == 0)
            {
                star1.sprite = disabledStarSprite;
                star2.sprite = disabledStarSprite;
                star3.sprite = disabledStarSprite;
                star1Particles.gameObject.SetActive(false);
                star2Particles.gameObject.SetActive(false);
                star3Particles.gameObject.SetActive(false);
            }
            else if (stars == 1)
            {
                star2.sprite = disabledStarSprite;
                star3.sprite = disabledStarSprite;
                star2Particles.gameObject.SetActive(false);
                star3Particles.gameObject.SetActive(false);
            }
            else if (stars == 2)
            {
                star3.sprite = disabledStarSprite;
                star3Particles.gameObject.SetActive(false);
            }
        }
	}
}
