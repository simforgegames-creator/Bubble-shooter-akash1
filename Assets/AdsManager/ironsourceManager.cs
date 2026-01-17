using UnityEngine;
using Unity.Services.LevelPlay;
using System;
namespace SimForge.Games.BubbleShooter.Blaze
{
    public class ironsourceManager : MonoBehaviour
    {
        public static ironsourceManager Instance;
        public bool InterstialLoaded_Ironsource;
        public bool RewardedLoaded_Ironsource;
        private LevelPlayInterstitialAd interstitialAd;
        private LevelPlayRewardedAd rewardedAd;
        private Action<bool> onRewardedAdCompleted;
        public bool Initialized_Ironsource;
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
            Initialized_Ironsource = false;
            LevelPlay.ValidateIntegration();

            Debug.Log($"[LevelPlaySample] Unity version {LevelPlay.UnityVersion}");
            LevelPlay.OnInitSuccess += SdkInitializationCompletedEvent;
            LevelPlay.OnInitFailed += SdkInitializationFailedEvent;

            Debug.Log("[LevelPlaySample] LevelPlay SDK initialization");
            LevelPlay.Init("24dad8165");
        }
        void SdkInitializationCompletedEvent(LevelPlayConfiguration config) => Initialized_Ironsource = true;
        void SdkInitializationFailedEvent(LevelPlayInitError error) => Debug.Log($"[LevelPlaySample] Received SdkInitializationFailedEvent with Error: {error}");
        public void EnableAds()
        {
            LevelPlay.OnImpressionDataReady += ImpressionDataReadyEvent;

            // Initialize Interstitial Ad
            interstitialAd = new LevelPlayInterstitialAd(FirebaseDataManager.Instance.adsConfig._IronSource_Interstitial_ID);
            interstitialAd.OnAdLoaded += InterstitialOnAdLoadedEvent;
            interstitialAd.OnAdLoadFailed += InterstitialOnAdLoadFailedEvent;
            interstitialAd.OnAdClosed += InterstitialOnAdClosedEvent;
            interstitialAd.LoadAd();

            // Initialize Rewarded Ad
            rewardedAd = new LevelPlayRewardedAd(FirebaseDataManager.Instance.adsConfig._IronSource_Rewarded_Id);
            rewardedAd.OnAdLoaded += RewardedOnAdLoadedEvent;
            rewardedAd.OnAdLoadFailed += RewardedOnAdLoadFailedEvent;
            rewardedAd.OnAdDisplayed += RewardedOnAdDisplayedEvent;
            rewardedAd.OnAdDisplayFailed += RewardedOnAdDisplayFailedEvent;
            rewardedAd.OnAdClosed += RewardedOnAdClosedEvent;
            rewardedAd.OnAdRewarded += RewardedOnAdRewardedEvent;
            rewardedAd.LoadAd();
        }

        void ImpressionDataReadyEvent(LevelPlayImpressionData impressionData) { }
        void InterstitialOnAdLoadedEvent(LevelPlayAdInfo adInfo)
        {
            InterstialLoaded_Ironsource = true;
        }
        void InterstitialOnAdLoadFailedEvent(LevelPlayAdError error)
        {
            InterstialLoaded_Ironsource = false;
            interstitialAd.LoadAd();
        }
        void InterstitialOnAdClosedEvent(LevelPlayAdInfo adInfo)
        {
            InterstialLoaded_Ironsource = false;
            interstitialAd.LoadAd();
        }

        public void ShowInterstial() => interstitialAd.ShowAd();

        // Rewarded Ad Event Handlers
        void RewardedOnAdLoadedEvent(LevelPlayAdInfo adInfo)
        {
            RewardedLoaded_Ironsource = true;
            Debug.Log("[LevelPlaySample] Rewarded ad loaded");
        }

        void RewardedOnAdLoadFailedEvent(LevelPlayAdError error)
        {
            RewardedLoaded_Ironsource = false;
            Debug.Log($"[LevelPlaySample] Rewarded ad load failed: {error}");
            rewardedAd.LoadAd();
        }

        void RewardedOnAdDisplayedEvent(LevelPlayAdInfo adInfo)
        {
            Debug.Log("[LevelPlaySample] Rewarded ad displayed");
        }

        void RewardedOnAdDisplayFailedEvent(LevelPlayAdInfo adInfo, LevelPlayAdError error)
        {
            Debug.Log($"[LevelPlaySample] Rewarded ad display failed: {error}");
            RewardedLoaded_Ironsource = false;
            rewardedAd.LoadAd();
            onRewardedAdCompleted?.Invoke(false);
            onRewardedAdCompleted = null;
        }

        void RewardedOnAdClosedEvent(LevelPlayAdInfo adInfo)
        {
            Debug.Log("[LevelPlaySample] Rewarded ad closed");
            RewardedLoaded_Ironsource = false;
            rewardedAd.LoadAd();
        }

        void RewardedOnAdRewardedEvent(LevelPlayAdInfo adInfo, LevelPlayReward reward)
        {
            Debug.Log($"[LevelPlaySample] Rewarded ad rewarded: {reward.Amount} {reward.Name}");
            onRewardedAdCompleted?.Invoke(true);
            onRewardedAdCompleted = null;
        }

        // Public method to show rewarded ad
        public void ShowRewardedAd(Action<bool> onCompleted)
        {
            if (RewardedLoaded_Ironsource)
            {
                onRewardedAdCompleted = onCompleted;
                rewardedAd.ShowAd();
            }
            else
            {
                Debug.Log("[LevelPlaySample] Rewarded ad not ready");
                onCompleted?.Invoke(false);
            }
        }

        public bool IsRewardedAdReady() => RewardedLoaded_Ironsource;
    }
}