using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{
    public class LevelButton : MonoBehaviour
    {
        public int NumLevel;
        [SerializeField]
        Sprite currentButtonSprite = null;
        [SerializeField]
        Sprite playedButtonSprite = null;
        [SerializeField]
        Sprite lockedButtonSprite = null;
        [SerializeField]
        Sprite yellowStarSprite = null;
        [SerializeField]
        Image buttonImage = null;
        [SerializeField]
        TextMeshProUGUI numLevelTextBlue = null;
        [SerializeField]
        TextMeshProUGUI numLevelTextPink = null;
        [SerializeField]
        GameObject star1 = null;
        [SerializeField]
        GameObject star2 = null;
        [SerializeField]
        GameObject star3 = null;
        void Awake()
        {
            Assert.IsNotNull(currentButtonSprite);
            Assert.IsNotNull(playedButtonSprite);
            Assert.IsNotNull(lockedButtonSprite);
            Assert.IsNotNull(yellowStarSprite);
            Assert.IsNotNull(buttonImage);
            Assert.IsNotNull(numLevelTextBlue);
            Assert.IsNotNull(numLevelTextPink);
            Assert.IsNotNull(star1);
            Assert.IsNotNull(star2);
            Assert.IsNotNull(star3);
        }
        void Start()
        {
            numLevelTextBlue.text = NumLevel.ToString();
            numLevelTextPink.text = NumLevel.ToString();
            var nextLevel = PlayerPrefs.GetInt("next_level");
            if (nextLevel == 0)
            {
                nextLevel = 1;
            }

            if (NumLevel == nextLevel)
            {
                buttonImage.sprite = currentButtonSprite;
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                numLevelTextBlue.gameObject.SetActive(false);
            }
            else if (NumLevel < nextLevel)
            {
                buttonImage.sprite = playedButtonSprite;
                numLevelTextPink.gameObject.SetActive(false);
                var stars = PlayerPrefs.GetInt("level_stars_" + NumLevel);
                switch (stars)
                {
                    case 1:
                        star1.GetComponent<Image>().sprite = yellowStarSprite;
                        break;

                    case 2:
                        star1.GetComponent<Image>().sprite = yellowStarSprite;
                        star2.GetComponent<Image>().sprite = yellowStarSprite;
                        break;

                    default:
                        star1.GetComponent<Image>().sprite = yellowStarSprite;
                        star2.GetComponent<Image>().sprite = yellowStarSprite;
                        star3.GetComponent<Image>().sprite = yellowStarSprite;
                        break;
                }
            }
            else
            {
                buttonImage.sprite = lockedButtonSprite;
                numLevelTextBlue.gameObject.SetActive(false);
                numLevelTextPink.gameObject.SetActive(false);
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
            }
        }
        public void OnButtonPressed()
        {
            if (buttonImage.sprite == lockedButtonSprite)
                return;

            var screen = GameObject.Find("LevelScreen").GetComponent<LevelScreen>();
            if (screen != null)
            {
                var numLives = PlayerPrefs.GetInt("num_lives");
                if (numLives > 0)
                {
                    if (!FileUtils.FileExists("Levels/" + NumLevel))
                    {
                        screen.OpenPopup<StartGamePopup>("Popups/StartGamePopup", popup =>
                        {
                            popup.LoadLevelData(Random.Range(1, 33));
                        });
                    }
                    else
                    {
                        screen.OpenPopup<StartGamePopup>("Popups/StartGamePopup", popup =>
                        {
                            popup.LoadLevelData(NumLevel);
                        });
                    }
                }
                else
                {
                    screen.OpenPopup<BuyLivesPopup>("Popups/BuyLivesPopup");
                }
            }
        }
    }
}
