using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Api.AdManager;
using GoogleMobileAds.Common;
using UnityEngine;
namespace SimForge.Games.BubbleShooter.Blaze
{
    public class AdmobManager : MonoBehaviour
    {
        public static AdmobManager instance;
        InterstitialAd interstitialAd;
        RewardedAd rewardedAd;
        public bool interstitialAdLoaded;
        public bool rewardedAdLoaded;
        private Action<bool> onRewardedCompleted;
        private AppOpenAd appOpenAd;
        private DateTime appOpenAdLoadTime;
        private bool isAppOpenAdLoading;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
        }
        void OnDestroy()
        {
            AppStateEventNotifier.AppStateChanged -= OnAppStateChanged;
        }
        void OnAppStateChanged(AppState state)
        {
            Debug.Log("App State is " + state);
            if (state == AppState.Foreground)
            {
                if (FirebaseDataManager.Instance.adsConfig._Admob_Ads_Show && FirebaseDataManager.Instance.adsConfig._All_Ads_Show)
                    ShowAppOpenAdIfAvailable();
            }
        }
        public void LoadAppOpenAd()
        {
            if (isAppOpenAdLoading) return;

            // Clean up the old ad before loading a new one.
            if (appOpenAd != null)
            {
                appOpenAd.Destroy();
                appOpenAd = null;
            }

            Debug.Log("Loading the app open ad...");

            var adRequest = new AdManagerAdRequest();

            AppOpenAd.Load(FirebaseDataManager.Instance.adsConfig._Admob_AppOpen_ID, adRequest,
                (AppOpenAd ad, LoadAdError error) =>
                {
                    if (error != null || ad == null)
                    {
                        isAppOpenAdLoading = false;
                        Debug.LogError("App open ad failed to load with error : " + error);
                        return;
                    }

                    Debug.Log("App open ad loaded with response : " + ad.GetResponseInfo());

                    appOpenAd = ad;
                    appOpenAdLoadTime = DateTime.UtcNow;
                    RegisterAppOpenAdEvents(ad);
                    isAppOpenAdLoading = true;
                });
        }

        public void ShowAppOpenAdIfAvailable()
        {
            isAppOpenAdLoading = false;
            if (appOpenAd != null && appOpenAd.CanShowAd())
            {
                if ((DateTime.UtcNow - appOpenAdLoadTime).TotalHours < 4)
                {
                    Debug.Log("Showing app open ad.");
                    appOpenAd.Show();
                }
                else
                {
                    Debug.Log("App open ad expired.");
                    LoadAppOpenAd();
                }
            }
            else
            {
                Debug.Log("App open ad is not ready yet.");
                LoadAppOpenAd();
            }
        }

        private void RegisterAppOpenAdEvents(AppOpenAd ad)
        {
            ad.OnAdFullScreenContentClosed += () =>
            {
                isAppOpenAdLoading = false;
                Debug.Log("App Open Ad full screen content closed.");
                LoadAppOpenAd();
            };
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                isAppOpenAdLoading = false;
                Debug.LogError("App Open Ad failed to open full screen content " + "with error : " + error);
                LoadAppOpenAd();
            };
        }

        void Start()
        {
            MobileAds.Initialize((InitializationStatus initstatus) =>
            {
                if (initstatus == null)
                {
                    Debug.LogError("Google Mobile Ads initialization failed.");
                    return;
                }

                Debug.Log("Google Mobile Ads initialization complete.");
            });
        }
        public void Load_Interstitial_Ad()
        {
            interstitialAdLoaded = false;
            var adRequest = new AdRequest();
            InterstitialAd.Load(FirebaseDataManager.Instance.adsConfig._Admob_Interstitial_ID
                , adRequest, (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Debug.LogError("Failed to load interstitial ad: " + error.GetMessage());
                    return;
                }
                interstitialAdLoaded = true;
                // The ad loaded successfully.
                interstitialAd = ad;
                ListenToAdEvents(interstitialAd);
            });
        }
        public void ShowInterstitialAd()
        {
            if (interstitialAd != null && interstitialAd.CanShowAd())
            {
                interstitialAd.Show();
            }
        }
        void ListenToAdEvents(InterstitialAd interstitialAd)
        {
            interstitialAd.OnAdFullScreenContentOpened += () => { };
            interstitialAd.OnAdFullScreenContentClosed += () =>
            {
                interstitialAdLoaded = false;
                Load_Interstitial_Ad();
            };
            interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
            {
                interstitialAdLoaded = false;
                Load_Interstitial_Ad();
            };
        }
        public void Load_Rewarded_Ad()
        {
            rewardedAdLoaded = false;
            var adRequest = new AdRequest();
            RewardedAd.Load(FirebaseDataManager.Instance.adsConfig._Admob_Rewarded_Id
                , adRequest, (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Debug.LogError("Failed to load rewarded ad: " + error.GetMessage());
                    return;
                }
                // The ad loaded successfully.
                rewardedAd = ad;
                rewardedAdLoaded = true;
                ListenToRewardedAdEvents(rewardedAd);
            });
        }
        void ListenToRewardedAdEvents(RewardedAd rewardedAd)
        {
            rewardedAd.OnAdFullScreenContentOpened += () => { };
            rewardedAd.OnAdFullScreenContentClosed += () =>
            {
                rewardedAdLoaded = false;
                Load_Rewarded_Ad();
            };
            rewardedAd.OnAdFullScreenContentFailed += (AdError error) =>
            {
                rewardedAdLoaded = false;
                Load_Rewarded_Ad();
                onRewardedCompleted?.Invoke(false);
                onRewardedCompleted = null;
            };
        }
        public void ShowRewardedAd(Action<bool> onCompleted)
        {
            if (rewardedAd != null && rewardedAd.CanShowAd())
            {
                onRewardedCompleted = onCompleted;
                rewardedAd.Show((Reward reward) =>
                {
                    onRewardedCompleted?.Invoke(true);
                    onRewardedCompleted = null;
                });
            }
            else
            {
                onCompleted?.Invoke(false);
            }
        }
    }
}
// Enhanced for analytics-integration
public void Enhanced_analytics_integration() { }


// Enhanced for ad-optimization
public void Enhanced_ad_optimization() { }

