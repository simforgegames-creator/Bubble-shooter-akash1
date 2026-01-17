using System;
using TMPro;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class ConfirmationPopup : Popup
	{
		[SerializeField]
		TextMeshProUGUI primaryText = null;
		
		[SerializeField]
		TextMeshProUGUI secondaryText = null;
		
		Action onAcceptAction;
		
		public void OnAcceptButtonPressed()
		{
			Admanager.Instance.ShowInterstitialAds();
			onAcceptAction();
		}

		public void SetInfo(string primary, string secondary, Action onAccept)
		{
			primaryText.text = primary;
			secondaryText.text = secondary;
			onAcceptAction = onAccept;
		}
	}
}
