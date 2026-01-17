using System;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	[CreateAssetMenu(fileName = "CoinsSystem", menuName = "Bubble Shooter Kit/Systems/Coins system", order = 1)]
	public class CoinsSystem : ScriptableObject
    {
        public GameConfiguration GameConfig;

		Action<int> onCoinsUpdated;

        public void BuyCoins(int amount)
        {
            if (!PlayerPrefs.HasKey("num_coins"))
                PlayerPrefs.SetInt("num_coins", GameConfig.InitialCoins);

            var numCoins = PlayerPrefs.GetInt("num_coins");
            numCoins += amount;
            PlayerPrefs.SetInt("num_coins", numCoins);
            onCoinsUpdated?.Invoke(numCoins);
        }

        public void SpendCoins(int amount)
        {
            if (!PlayerPrefs.HasKey("num_coins"))
                PlayerPrefs.SetInt("num_coins", GameConfig.InitialCoins);

            var numCoins = PlayerPrefs.GetInt("num_coins");
            numCoins -= amount;
            if (numCoins < 0)
                numCoins = 0;
            PlayerPrefs.SetInt("num_coins", numCoins);
            onCoinsUpdated?.Invoke(numCoins);
        }

        public void Subscribe(Action<int> callback)
        {
            onCoinsUpdated += callback;
        }

        public void Unsubscribe(Action<int> callback)
        {
            if (onCoinsUpdated != null)
                onCoinsUpdated -= callback;
        }
	}
}
