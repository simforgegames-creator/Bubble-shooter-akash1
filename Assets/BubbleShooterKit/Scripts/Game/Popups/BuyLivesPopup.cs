using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class BuyLivesPopup : Popup
    {
        public GameConfiguration GameConfig;

        [SerializeField]
        TextMeshProUGUI refillCostText = null;

        [SerializeField]
        AnimatedButton refillButton = null;

        [SerializeField]
        Image refillButtonImage = null;

        [SerializeField]
        Sprite refillButtonDisabledSprite = null;

        [SerializeField]
        ParticleSystem livesParticles = null;

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(refillCostText);
            Assert.IsNotNull(refillButton);
            Assert.IsNotNull(refillButtonImage);
            Assert.IsNotNull(refillButtonDisabledSprite);
            Assert.IsNotNull(livesParticles);
        }

        protected override void Start()
        {
            base.Start();
            var maxLives = GameConfig.MaxLives;
            var numLives = PlayerPrefs.GetInt("num_lives");
            if (numLives >= maxLives)
                DisableRefillButton();
            refillCostText.text = GameConfig.LivesRefillCost.ToString();
        }

        public void OnRefillButtonPressed()
        {
            var numCoins = PlayerPrefs.GetInt("num_coins");
            if (numCoins >= GameConfig.LivesRefillCost)
            {
                var freeLivesChecker = FindObjectOfType<CheckForFreeLives>();
                if (freeLivesChecker != null)
                {
                    freeLivesChecker.RefillLives();
                    livesParticles.Play();

                    DisableRefillButton();
                }
            }
            else
            {
                var screen = ParentScreen;
                if (screen != null)
                {
                    screen.CloseCurrentPopup();

                    screen.OpenPopup<BuyCoinsPopup>("Popups/BuyCoinsPopup",
                        popup =>
                        {
                            popup.OnClose.AddListener(
                                () =>
                                {
                                    screen.OpenPopup<BuyLivesPopup>("Popups/BuyLivesPopup");
                                });
                        });
                }
            }
        }

        void DisableRefillButton()
        {
            refillButtonImage.sprite = refillButtonDisabledSprite;
            refillButton.Interactable = false;
        }
    }
}
