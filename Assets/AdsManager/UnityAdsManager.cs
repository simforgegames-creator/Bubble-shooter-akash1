using System;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine;
namespace SimForge.Games.BubbleShooter.Blaze
{
    public class UnityAdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public static UnityAdsManager Instance;
        public bool InterstitialAdLoaded_Unity;
        public bool RewardedAdLoaded_Unity;
        private Action<bool> onRewardedCompleted;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        void Start()
        {
            Initialize();
        }
        public void Initialize()
        {
            if (Advertisement.isSupported)
            {
                Debug.Log(Application.platform + " supported by Advertisement");
            }
            Advertisement.Initialize("6022652", false, this);
        }
        public void LoadRewardedAd()
        {
            Advertisement.Load("Rewarded_Android", this);
        }

        public void ShowRewardedAd(Action<bool> onCompleted)
        {
            onRewardedCompleted = onCompleted;
            Advertisement.Show("Rewarded_Android", this);
        }

        public void Load_Interstitial_Ad()
        {
            Advertisement.Load("Interstitial_Android", this);
        }

        public void ShowInterstitialAd()
        {
            Advertisement.Show("Interstitial_Android", this);
        }
        public void OnInitializationComplete()
        {
            Debug.Log("Init Success");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Init Failed: [{error}]: {message}");
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            Debug.Log($"Load Success: {placementId}");
            if (placementId == "Interstitial_Android")
            {
                InterstitialAdLoaded_Unity = true;
            }
            else if (placementId == "Rewarded_Android")
            {
                RewardedAdLoaded_Unity = true;
            }
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Load Failed: [{error}:{placementId}] {message}");
            if (placementId == "Interstitial_Android")
            {
                InterstitialAdLoaded_Unity = false;
            }
            else if (placementId == "Rewarded_Android")
            {
                RewardedAdLoaded_Unity = false;
            }
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.Log($"OnUnityAdsShowFailure: [{error}]: {message}");

            if (placementId == "Interstitial_Android")
            {
                InterstitialAdLoaded_Unity = false;
            }
            else if (placementId == "Rewarded_Android")
            {
                RewardedAdLoaded_Unity = false;
                onRewardedCompleted?.Invoke(false);
                onRewardedCompleted = null;
            }
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            Debug.Log($"OnUnityAdsShowStart: {placementId}");
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            Debug.Log($"OnUnityAdsShowClick: {placementId}");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            Debug.Log($"OnUnityAdsShowComplete: [{showCompletionState}]: {placementId}");
            if (placementId == "Interstitial_Android")
            {
                InterstitialAdLoaded_Unity = false;
            }
            else if (placementId == "Rewarded_Android")
            {
                RewardedAdLoaded_Unity = false;
                bool rewarded = showCompletionState == UnityAdsShowCompletionState.COMPLETED;
                onRewardedCompleted?.Invoke(rewarded);
                onRewardedCompleted = null;
            }
        }
    }
}