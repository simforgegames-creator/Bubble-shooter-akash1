using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class OutOfBubblesPopup : Popup
	{
		public GameConfiguration GameConfig;
		public CoinsSystem CoinsSystem;
		
		[SerializeField]
		TextMeshProUGUI numBubblesText = null;
		
		[SerializeField]
		TextMeshProUGUI questionText = null;
		
		[SerializeField]
		TextMeshProUGUI priceText = null;
		
		[SerializeField]
		TextMeshProUGUI priceBorderText = null;

		GameScreen gameScreen;

		protected override void Awake()
		{
			base.Awake();
			Assert.IsNotNull(numBubblesText);
			Assert.IsNotNull(questionText);
			Assert.IsNotNull(priceText);
			Assert.IsNotNull(priceBorderText);
		}

		public void SetInfo(GameScreen screen)
		{
			gameScreen = screen;
			numBubblesText.text = $"+ {GameConfig.NumExtraBubbles}";
			questionText.text = $"Add {GameConfig.NumExtraBubbles} bubbles to continue?";
			priceText.text = GameConfig.ExtraBubblesCost.ToString();
			priceBorderText.text = priceText.text;
		}
		
		public void OnQuitButtonPressed()
		{
			Close();
			gameScreen.StartCoroutine(gameScreen.OpenLosePopupAsync());
		}
		
		public void OnBuyButtonPressed()
		{
			var numCoins = PlayerPrefs.GetInt("num_coins");
			var cost = GameConfig.ExtraBubblesCost;
			if (numCoins >= cost)
			{
				CoinsSystem.SpendCoins(cost);



				Close();
				gameScreen.GameLogic.ContinueGame();
			}
			else
			{

				gameScreen.OpenCoinsPopup();
			}
		}
	}
}
