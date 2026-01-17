using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class BuyLivesWidget : MonoBehaviour
    {
        public GameConfiguration GameConfig;
        
        [SerializeField]
        Sprite enabledLifeSprite = null;

        [SerializeField]
        Sprite disabledLifeSprite = null;

        [SerializeField]
        Image lifeImage = null;

        [SerializeField]
        TextMeshProUGUI numLivesText = null;

        [SerializeField]
        TextMeshProUGUI timeToNextLifeText = null;

        [SerializeField]
        Image buttonImage = null;

        [SerializeField]
        Sprite enabledButtonSprite = null;

        [SerializeField]
        Sprite disabledButtonSprite = null;

        CheckForFreeLives freeLivesChecker;

        void Awake()
        {
            Assert.IsNotNull(enabledLifeSprite);
            Assert.IsNotNull(disabledLifeSprite);
            Assert.IsNotNull(lifeImage);
            Assert.IsNotNull(numLivesText);
            Assert.IsNotNull(timeToNextLifeText);
            Assert.IsNotNull(buttonImage);
            Assert.IsNotNull(enabledButtonSprite);
            Assert.IsNotNull(disabledButtonSprite);
        }

        void Start()
        {
            freeLivesChecker = FindObjectOfType<CheckForFreeLives>();
            
            var numLives = PlayerPrefs.GetInt("num_lives");
            var maxLives = GameConfig.MaxLives;
            numLivesText.text = numLives.ToString();
            buttonImage.sprite = numLives == maxLives ? disabledButtonSprite : enabledButtonSprite;
            freeLivesChecker.Subscribe(OnLivesCountdownUpdated, OnLivesCountdownFinished);
        }

        void OnDestroy()
        {
           freeLivesChecker.Unsubscribe(OnLivesCountdownUpdated, OnLivesCountdownFinished);
        }

        public void OnBuyButtonPressed()
        {
			Admanager.Instance.ShowInterstitialAds();
            var numLives = PlayerPrefs.GetInt("num_lives");
            var maxLives = GameConfig.MaxLives;
            if (numLives < maxLives)
            {
                var scene = FindObjectOfType<BaseScreen>();
                var buyLivesPopup = FindObjectOfType<BuyLivesPopup>();
                if (scene != null && buyLivesPopup == null)
                    scene.OpenPopup<BuyLivesPopup>("Popups/BuyLivesPopup");
            }
        }

        void OnLivesCountdownUpdated(TimeSpan timeSpan, int lives)
        {
            timeToNextLifeText.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
            numLivesText.text = lives.ToString();
            lifeImage.sprite = lives == 0 ? disabledLifeSprite : enabledLifeSprite;
            var maxLives = GameConfig.MaxLives;
            buttonImage.sprite = lives == maxLives ? disabledButtonSprite : enabledButtonSprite;
        }

        void OnLivesCountdownFinished(int lives)
        {
            timeToNextLifeText.text = "Full";
            numLivesText.text = lives.ToString();
            lifeImage.sprite = lives == 0 ? disabledLifeSprite : enabledLifeSprite;
            buttonImage.sprite = disabledButtonSprite;
        }
    }
}
