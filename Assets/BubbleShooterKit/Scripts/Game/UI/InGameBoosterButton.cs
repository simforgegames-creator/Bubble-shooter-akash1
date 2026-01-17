using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class InGameBoosterButton : MonoBehaviour
	{
		[SerializeField]
		PurchasableBoosterBubbleType boosterBubbleType = PurchasableBoosterBubbleType.HorizontalBomb;

		[SerializeField]
		Image normalBackgroundImage = null;

		[SerializeField]
		Image lockedBackgroundImage = null;

		[SerializeField]
		Image boosterImage = null;

		[SerializeField]
		Image moreImage = null;

		[SerializeField]
		Image amountImage = null;

		[SerializeField]
		TextMeshProUGUI amountText = null;

		GameScreen gameScreen;
		PlayerBubbles playerBubbles;

		bool isAvailable;

		public void Initialize(GameScreen screen, PlayerBubbles bubbles, Sprite boosterSprite, int amount, bool available)
		{
			gameScreen = screen;
			playerBubbles = bubbles;

			isAvailable = available;

			if (isAvailable)
			{
				boosterImage.sprite = boosterSprite;
				normalBackgroundImage.gameObject.SetActive(true);
				lockedBackgroundImage.gameObject.SetActive(false);
				if (amount > 0)
				{
					amountText.text = PlayerPrefs.GetInt($"num_boosters_{(int) boosterBubbleType}").ToString();
					amountImage.gameObject.SetActive(true);
					amountText.gameObject.SetActive(true);
					moreImage.gameObject.SetActive(false);
				}
				else
				{
					amountImage.gameObject.SetActive(false);
					amountText.gameObject.SetActive(false);
					moreImage.gameObject.SetActive(true);
				}
			}
			else
			{
				normalBackgroundImage.gameObject.SetActive(false);
				lockedBackgroundImage.gameObject.SetActive(true);
				boosterImage.gameObject.SetActive(false);
				moreImage.gameObject.SetActive(false);
				amountImage.gameObject.SetActive(false);
			}
		}

		public void OnButtonPressed()
		{
			if (!isAvailable)
				return;

			if (playerBubbles.IsPlayingEndGameSequence())
				return;

			if (boosterBubbleType == PurchasableBoosterBubbleType.SuperAim &&
			    gameScreen.Shooter.IsSuperAimEnabled())
				return;

			var amount = PlayerPrefs.GetInt($"num_boosters_{(int)boosterBubbleType}");
			if (amount > 0)
			{
				Admanager.Instance.ShowInterstitialAds();
				if (!playerBubbles.IsSpecialBubbleActive)
				{
					amountImage.gameObject.SetActive(true);
					moreImage.gameObject.SetActive(false);
					gameScreen.ApplyBooster(boosterBubbleType);
					amount -= 1;
					if (amount == 0)
					{
						amountImage.gameObject.SetActive(false);
						amountText.gameObject.SetActive(false);
						moreImage.gameObject.SetActive(true);
					}

					PlayerPrefs.SetInt($"num_boosters_{(int) boosterBubbleType}", amount);
					amountText.text = amount.ToString();
				}
			}
			else
			{
			Admanager.Instance.ShowInterstitialAds();
				amountImage.gameObject.SetActive(false);
				amountText.gameObject.SetActive(false);
				moreImage.gameObject.SetActive(true);
				gameScreen.OpenPopup<BuyBoostersPopup>("Popups/BuyBoostersPopup",
					popup => { popup.Initialize(boosterBubbleType, this); });
			}
		}

		public void UpdateAmount(int newAmount)
		{
			if (newAmount > 0)
			{
				amountImage.gameObject.SetActive(true);
				moreImage.gameObject.SetActive(false);
				amountText.gameObject.SetActive(true);
				amountText.text = newAmount.ToString();
			}
			else
			{
				amountImage.gameObject.SetActive(false);
				amountText.gameObject.SetActive(false);
				moreImage.gameObject.SetActive(true);
			}
		}
	}
}
