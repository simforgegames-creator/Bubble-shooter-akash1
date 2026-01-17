using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class BuyCoinsWidget : MonoBehaviour
    {
        public GameConfiguration GameConfig;
        public CoinsSystem CoinsSystem;
        
        [SerializeField]
        TextMeshProUGUI numCoinsText = null;

        void Awake()
        {
            Assert.IsNotNull(numCoinsText);
        }

        void Start()
        {
            if (!PlayerPrefs.HasKey("num_coins"))
                PlayerPrefs.SetInt("num_coins", GameConfig.InitialCoins);
            var numCoins = PlayerPrefs.GetInt("num_coins");
            numCoinsText.text = numCoins.ToString("n0");
            CoinsSystem.Subscribe(OnCoinsChanged);
        }

        void OnDestroy()
        {
            CoinsSystem.Unsubscribe(OnCoinsChanged);
        }

        public void OnBuyButtonPressed()
        {
            var scene = FindObjectOfType<BaseScreen>();
            var buyCoinsPopup = FindObjectOfType<BuyCoinsPopup>();
            if (scene != null && buyCoinsPopup == null)
                scene.OpenPopup<BuyCoinsPopup>("Popups/BuyCoinsPopup");
        }

        void OnCoinsChanged(int numCoins)
        {
            numCoinsText.text = numCoins.ToString("n0");
        }
    }
}
