using System.Collections.Generic;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class InGameBoostersWidget : MonoBehaviour
	{
		[SerializeField]
		GameScreen gameScreen = null;
		
		[SerializeField]
		List<Sprite> boosterSprites = null;
			
		[SerializeField]
		List<InGameBoosterButton> buttons = null;

		public void Initialize(GameConfiguration gameConfig, LevelInfo levelInfo)
		{
			buttons[0].Initialize(gameScreen, gameScreen.PlayerBubbles, boosterSprites[0], PlayerPrefs.GetInt("num_boosters_0"), levelInfo.IsSuperAimAvailable);
			buttons[1].Initialize(gameScreen, gameScreen.PlayerBubbles, boosterSprites[1], PlayerPrefs.GetInt("num_boosters_1"), levelInfo.IsRainbowBombAvailable);
			buttons[2].Initialize(gameScreen, gameScreen.PlayerBubbles, boosterSprites[2], PlayerPrefs.GetInt("num_boosters_2"), levelInfo.IsHorizontalBombAvailable);
			buttons[3].Initialize(gameScreen, gameScreen.PlayerBubbles, boosterSprites[3], PlayerPrefs.GetInt("num_boosters_3"), levelInfo.IsCircleBombAvailable);
		}
	}
}
