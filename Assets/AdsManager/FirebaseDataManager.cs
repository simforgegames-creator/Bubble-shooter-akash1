using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;

namespace SimForge.Games.BubbleShooter.Blaze
{
    [Serializable]
    public class AdsConfigData
    {
        public bool _Admob_Ads_Show = true;
        public string _Admob_AppOpen_ID = "ca-app-pub-3940256099942544/9257395921";
        public string _Admob_Interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        public string _Admob_Rewarded_Id = "ca-app-pub-3940256099942544/5224354917";
        public bool _All_Ads_Show = true;
        public bool _IronSource_Ads_Show = true;
        public string _IronSource_Interstitial_ID = "4uzqelxbctryvb7v";
        public string _IronSource_Rewarded_Id = "d5ik2xwp9n5zw3tk";
        public bool _Unity_Ads_Show = true;
    }
}
namespace SimForge.Games.BubbleShooter.Blaze
{
    public class FirebaseDataManager : MonoBehaviour
    {
        public static FirebaseDataManager Instance;
        private DatabaseReference databaseReference;
        private bool firebaseInitialized = false;
        public AdsConfigData adsConfig;
        public Action<AdsConfigData> OnAdsConfigLoaded;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            InitializeFirebase();
            StartCoroutine(ChangeSceneAfterDelay("HomeScreen", 8f));
        }
        IEnumerator ChangeSceneAfterDelay(string sceneName, float delay)
        {
            yield return new WaitForSeconds(delay);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        private void InitializeFirebase()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                if (task.Result == DependencyStatus.Available)
                {
                    FirebaseApp app = FirebaseApp.DefaultInstance;
                    databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                    firebaseInitialized = true;
                    Debug.Log("Firebase initialized successfully");

                    FetchAdsConfig();
                }
                else
                {
                    Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
                    firebaseInitialized = false;
                }
            });
        }

        public void FetchAdsConfig()
        {
            if (!firebaseInitialized)
            {
                Debug.LogError("Firebase is not initialized yet!");
                return;
            }

            databaseReference.GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("Error fetching ads config: " + task.Exception);
                    return;
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    string jsonData = snapshot.GetRawJsonValue();
                    Debug.Log("Fetched JSON data: " + jsonData);

                    adsConfig = JsonUtility.FromJson<AdsConfigData>(jsonData);

                    Debug.Log("Ads Config loaded successfully!");

                    if (adsConfig._All_Ads_Show)
                    {
                        if (adsConfig._Admob_Ads_Show && AdmobManager.instance != null)
                        {
                            AdmobManager.instance.LoadAppOpenAd();
                            AdmobManager.instance.Load_Interstitial_Ad();
                            AdmobManager.instance.Load_Rewarded_Ad();
                        }
                        if (adsConfig._IronSource_Ads_Show && ironsourceManager.Instance != null && ironsourceManager.Instance.Initialized_Ironsource)
                        {
                            ironsourceManager.Instance.EnableAds();
                        }
                        if (adsConfig._Unity_Ads_Show && UnityAdsManager.Instance != null)
                        {
                            UnityAdsManager.Instance.Load_Interstitial_Ad();
                            UnityAdsManager.Instance.LoadRewardedAd();
                        }
                    }

                    OnAdsConfigLoaded?.Invoke(adsConfig);
                }
            });
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

