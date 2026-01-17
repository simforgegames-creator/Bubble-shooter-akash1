using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class EndGamePopup : Popup
	{
        [SerializeField]
        TextMeshProUGUI scoreText = null;

        [SerializeField]
        GameObject goalGroup = null;

	    [SerializeField]
	    GameObject endGameGoalWidgetPrefab = null;
	    
        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(scoreText);
            Assert.IsNotNull(goalGroup);
            Assert.IsNotNull(endGameGoalWidgetPrefab);
        }

	    protected override void Start()
	    {
	        base.Start();
	        if (PlayerPrefs.GetInt("sound_enabled") == 1)
    	        GetComponent<AudioSource>().Play();
	    }

	    public void OnCloseButtonPressed()
	    {
	        GetComponent<ScreenTransition>().PerformTransition();
	    }

        public void OnReplayButtonPressed()
        {
            var gameScreen = ParentScreen as GameScreen;
            if (gameScreen != null)
            {
                var numLives = PlayerPrefs.GetInt("num_lives");
                if (numLives > 0)
                {
                    gameScreen.GameLogic.RestartGame();
                    gameScreen.CloseTopCanvas();
                    Close();
                }
                else
                {
                    gameScreen.OpenPopup<BuyLivesPopup>("Popups/BuyLivesPopup");
                }
            }
        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void SetGoals(List<LevelGoal> goals, GameState gameState, LevelGoalsWidget goalsWidget)
        {
            var i = 0;
            foreach (var goal in goals)
            {
                var goalObject = Instantiate(endGameGoalWidgetPrefab);
                goalObject.transform.SetParent(goalGroup.transform, false);
                goalObject.GetComponent<EndGameGoalWidget>().Initialize(
                    goal.IsComplete(gameState),
                    goalsWidget.transform.GetChild(i).GetComponent<LevelGoalWidget>());
                ++i;
            }
        }
	}
}
