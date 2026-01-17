using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class SettingsPopup : Popup
	{
        [SerializeField]
        Slider soundSlider = null;

        [SerializeField]
        Slider musicSlider = null;

        [SerializeField]
        AnimatedButton resetProgressButton = null;

        [SerializeField]
        Image resetProgressImage = null;

        [SerializeField]
        Sprite resetProgressDisabledSprite = null;

        int currentSound;
        int currentMusic;

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(soundSlider);
            Assert.IsNotNull(musicSlider);



        }

        protected override void Start()
        {
            base.Start();
            soundSlider.value = PlayerPrefs.GetInt("sound_enabled");
            musicSlider.value = PlayerPrefs.GetInt("music_enabled");
        }

        public void OnResetProgressButtonPressed()
        {
            PlayerPrefs.SetInt("last_selected_level", 0);
            PlayerPrefs.SetInt("next_level", 0);
            for (var i = 1; i <= 30; i++)
            {
                PlayerPrefs.DeleteKey($"level_stars_{i}");
            }
            resetProgressImage.sprite = resetProgressDisabledSprite;
            resetProgressButton.Interactable = false;
        }

        public void OnSoundSliderValueChanged()
        {
            currentSound = (int)soundSlider.value;
            SoundPlayer.SetSoundEnabled(currentSound == 1);
            PlayerPrefs.SetInt("sound_enabled", currentSound);
        }

        public void OnMusicSliderValueChanged()
        {
            currentMusic = (int)musicSlider.value;
            SoundPlayer.SetMusicEnabled(currentMusic == 1);
            PlayerPrefs.SetInt("music_enabled", currentMusic);
        }
	}
}
