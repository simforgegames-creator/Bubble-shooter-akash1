using DG.Tweening;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class LevelScreen : BaseScreen
    {
        [SerializeField]
        ScrollRect scrollRect = null;

        [SerializeField]
        GameObject scrollView = null;

        [SerializeField]
        GameObject avatarPrefab = null;

        public GameConfiguration gameConfig;
        public CoinsSystem coinsSystem;
        void Awake()
        {
            Assert.IsNotNull(scrollRect);
            Assert.IsNotNull(scrollView);
            Assert.IsNotNull(avatarPrefab);
        }
        public void ShowRewardAds()
        {
            Admanager.Instance.ShowRewardedAds(success =>
                        {
                            if (success)
                            {
                                CompleteReward();
                            }
                        });
        }
        public void CompleteReward()
        {
            var rewardCoins = gameConfig.RewardedAdCoins;
            coinsSystem.BuyCoins(rewardCoins);
            OpenPopup<AlertPopup>("Popups/AlertPopup", popup => { popup.SetText($"You earned {rewardCoins} coins!"); });
        }
        protected override void Start()
        {
            base.Start();

            scrollRect.vertical = false;

            var avatar = Instantiate(avatarPrefab, scrollView.transform, false);

            var nextLevel = PlayerPrefs.GetInt("next_level");
            if (nextLevel == 0)
                nextLevel = 1;

            LevelButton currentButton = null;
            var levelButtons = scrollView.GetComponentsInChildren<LevelButton>();
            foreach (var button in levelButtons)
            {
                if (button.NumLevel != nextLevel)
                    continue;
                currentButton = button;
                break;
            }

            if (currentButton == null)
                currentButton = levelButtons[levelButtons.Length - 1];

            var newPos = scrollView.GetComponent<RectTransform>().anchoredPosition;
            newPos.y =
                scrollRect.transform.InverseTransformPoint(scrollView.GetComponent<RectTransform>().position).y -
                scrollRect.transform.InverseTransformPoint(currentButton.transform.position).y;
            newPos.y += Canvas.GetComponent<RectTransform>().rect.height / 2.0f;
            if (newPos.y < scrollView.GetComponent<RectTransform>().anchoredPosition.y)
                scrollView.GetComponent<RectTransform>().anchoredPosition = newPos;

            var targetPos = currentButton.transform.position + new Vector3(0, 1.0f, 0);

            LevelButton prevButton = null;
            if (PlayerPrefs.GetInt("unlocked_next_level") == 1)
            {
                foreach (var button in scrollView.GetComponentsInChildren<LevelButton>())
                {
                    if (button.NumLevel != PlayerPrefs.GetInt("last_selected_level"))
                        continue;
                    prevButton = button;
                    break;
                }
            }

            if (prevButton != null)
            {
                avatar.transform.position = prevButton.transform.position + new Vector3(0, 1.0f, 0);
                var sequence = DOTween.Sequence();
                sequence.AppendInterval(0.5f);
                sequence.Append(avatar.transform.DOMove(targetPos, 0.8f));
                sequence.AppendCallback(() => avatar.GetComponent<LevelAvatar>().StartFloatingAnimation());
                sequence.AppendCallback(() => scrollRect.vertical = true);
            }
            else
            {
                avatar.transform.position = targetPos;
                avatar.GetComponent<LevelAvatar>().StartFloatingAnimation();
                scrollRect.vertical = true;
            }
        }
    }
}
