using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	[CreateAssetMenu(fileName = "LivesSystem", menuName = "Bubble Shooter Kit/Systems/Lives system", order = 0)]
	public class LivesSystem : ScriptableObject
    {
	    public void AddLife(GameConfiguration gameConfig)
	    {
		    var numLives = PlayerPrefs.GetInt("num_lives");
		    numLives += 1;
		    if (numLives > gameConfig.MaxLives)
			    numLives = gameConfig.MaxLives;
		    PlayerPrefs.SetInt("num_lives", numLives);
	    }

	    public void RemoveLife(GameConfiguration gameConfig)
	    {
		    var numLives = PlayerPrefs.GetInt("num_lives");
		    numLives -= 1;
		    if (numLives < 0)
			    numLives = 0;
		    PlayerPrefs.SetInt("num_lives", numLives);
	    }
	    
	    public void Refill(GameConfiguration gameConfig)
	    {
		    var amount = gameConfig.MaxLives;
		    PlayerPrefs.SetInt("num_lives", amount);
	    }
	}
}
