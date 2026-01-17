using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class PausePopup : Popup
	{
		[SerializeField]
		AnimatedButton musicButton = null;
		
		[SerializeField]
		AnimatedButton soundButton = null;

		protected override void Awake()
		{
			base.Awake();
			Assert.IsNotNull(musicButton);
			Assert.IsNotNull(soundButton);
		}

		protected override void Start()
		{
			base.Start();
			var currentMusic = PlayerPrefs.GetInt("music_enabled");
			if (currentMusic == 0)
				musicButton.GetComponent<SpriteSwapper>().SwapSprite();
			var currentSound = PlayerPrefs.GetInt("sound_enabled");
			if (currentSound == 0)
				soundButton.GetComponent<SpriteSwapper>().SwapSprite();
		}

		public void OnContinueButtonPressed()
		{
			var gameScreen = ParentScreen as GameScreen;
			if (gameScreen != null)
				gameScreen.UnlockInput();
			Close();
		}

		public void OnRestartButtonPressed()
		{
			Admanager.Instance.ShowInterstitialAds();
			ParentScreen.OpenPopup<ConfirmationPopup>("Popups/ConfirmationPopup", popup =>
			{
				popup.SetInfo("Do you really want to restart the game?", "(You will lose a life)", () =>
				{
					var gameScreen = ParentScreen as GameScreen;
					if (gameScreen != null)
					{
						gameScreen.UnlockInput();
						gameScreen.PenalizePlayer();
						gameScreen.GameLogic.RestartGame();
					}
					
					popup.Close();
					Close();
				});
			});
		}

		public void OnQuitButtonPressed()
		{
			ParentScreen.OpenPopup<ConfirmationPopup>("Popups/ConfirmationPopup", popup =>
			{
				popup.SetInfo("Do you really want to quit the game?", "(You will lose a life)", () =>
				{
					var gameScreen = ParentScreen as GameScreen;
					if (gameScreen != null)
						gameScreen.PenalizePlayer();
					
					GetComponent<ScreenTransition>().PerformTransition();
				});
			});
		}

		public void OnMusicButtonPressed()
		{
			Admanager.Instance.ShowInterstitialAds();
			var currentMusic = PlayerPrefs.GetInt("music_enabled");
			currentMusic = 1 - currentMusic;	
            SoundPlayer.SetMusicEnabled(currentMusic == 1);
            PlayerPrefs.SetInt("music_enabled", currentMusic);
		}

		public void OnSoundButtonPressed()
		{
			Admanager.Instance.ShowInterstitialAds();
			var currentSound = PlayerPrefs.GetInt("sound_enabled");
			currentSound = 1 - currentSound;	
            SoundPlayer.SetSoundEnabled(currentSound == 1);
            PlayerPrefs.SetInt("sound_enabled", currentSound);
		}
	}
}
