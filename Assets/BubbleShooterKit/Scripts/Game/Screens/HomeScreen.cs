using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class HomeScreen : BaseScreen
	{
#pragma warning disable 649
		[SerializeField]
		GameObject bgMusicPrefab;
		
		[SerializeField]
		GameObject purchaseManagerPrefab;
#pragma warning restore 649
		
		protected override void Start()
		{
			base.Start();
			
			var bgMusic = FindAnyObjectByType<BackgroundMusic>();
			if (bgMusic == null)
				Instantiate(bgMusicPrefab);
			
#if BUBBLE_SHOOTER_ENABLE_IAP
			var purchaseManager = FindAnyObjectByType<PurchaseManager>();
			if (purchaseManager == null)
				Instantiate(purchaseManagerPrefab);
#endif
		}
		
        public void OnSettingsButtonPressed()
        {
			Admanager.Instance.ShowInterstitialAds();
            OpenPopup<SettingsPopup>("Popups/SettingsPopup");
        }
	}
}
