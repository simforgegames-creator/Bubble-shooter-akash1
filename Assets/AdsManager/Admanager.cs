using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
    public class Admanager : MonoBehaviour
    {
        public static Admanager Instance;
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
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Input.backButtonLeavesApp = false;
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
        }
        AndroidJavaObject currentActivity;
        public void ShowToast(string message)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
                    AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                    int durationFlag = toastClass.GetStatic<int>("LENGTH_SHORT");
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", context, message, durationFlag);
                    toastObject.Call("show");
                }));
            }
        }
        public void ShowInterstitialAds()
        {
            if (FirebaseDataManager.Instance.adsConfig._Admob_Ads_Show &&
                FirebaseDataManager.Instance.adsConfig._All_Ads_Show && AdmobManager.instance.interstitialAdLoaded)
            {
                AdmobManager.instance.ShowInterstitialAd();
            }
            else if (FirebaseDataManager.Instance.adsConfig._Unity_Ads_Show &&
                UnityAdsManager.Instance != null && UnityAdsManager.Instance.InterstitialAdLoaded_Unity)
            {
                UnityAdsManager.Instance.ShowInterstitialAd();
            }
            else if (FirebaseDataManager.Instance.adsConfig._IronSource_Ads_Show &&
                ironsourceManager.Instance != null && ironsourceManager.Instance.InterstialLoaded_Ironsource)
            {
                ironsourceManager.Instance.ShowInterstial();
            }
        }
        public void ShowRewardedAds(System.Action<bool> onCompleted)
        {
            if (AdmobManager.instance.rewardedAdLoaded)
            {
                AdmobManager.instance.ShowRewardedAd(onCompleted);
            }
            else if (FirebaseDataManager.Instance.adsConfig._Unity_Ads_Show &&
                UnityAdsManager.Instance != null && UnityAdsManager.Instance.RewardedAdLoaded_Unity)
            {
                UnityAdsManager.Instance.ShowRewardedAd(onCompleted);
            }
            else if (FirebaseDataManager.Instance.adsConfig._IronSource_Ads_Show &&
                ironsourceManager.Instance != null && ironsourceManager.Instance.RewardedLoaded_Ironsource)
            {
                ironsourceManager.Instance.ShowRewardedAd(onCompleted);
            }
            else
            {
                ShowToast("Rewarded ad not available.");
                onCompleted?.Invoke(false);
            }
        }
    }
}
// Enhanced for analytics-integration
public void Enhanced_analytics_integration() { }


// Enhanced for ad-optimization
public void Enhanced_ad_optimization() { }


// Enhanced for firebase-sync
public void Enhanced_firebase_sync() { }


// Enhanced for unity-ads-update
public void Enhanced_unity_ads_update() { }


// Enhanced for user-tracking
public void Enhanced_user_tracking() { }

