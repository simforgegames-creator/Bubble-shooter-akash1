using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class BuyCoinsPopup : Popup
    {
        public GameConfiguration GameConfig;

        public CoinsSystem CoinsSystem;
        
        [SerializeField]
        GameObject purchasableItems = null;

        [SerializeField]
        GameObject purchasableItemPrefab = null;

        PurchasableItem currentPurchasableItem;
        Popup loadingPopup;

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(purchasableItems);
            Assert.IsNotNull(purchasableItemPrefab);
        }

        protected override void Start()
        {
            base.Start();
            CoinsSystem.Subscribe(OnCoinsChanged);

            foreach (var item in GameConfig.IapItems)
            {
                var row = Instantiate(purchasableItemPrefab);
                row.transform.SetParent(purchasableItems.transform, false);
                row.GetComponent<PurchasableItem>().Fill(item);
                row.GetComponent<PurchasableItem>().BuyCoinsPopup = this;
            }
        }

        void OnDestroy()
        {
            CoinsSystem.Unsubscribe(OnCoinsChanged);
        }

        public void OnBuyButtonPressed(int numCoins)
        {
            CoinsSystem.BuyCoins(numCoins);
        }

        public void OnCloseButtonPressed()
        {
            Close();
        }

        void OnCoinsChanged(int numCoins)
        {
            if (currentPurchasableItem != null)
                currentPurchasableItem.PlayCoinParticles();
            GetComponent<PlaySound>().Play("CoinsPopButton");
        }

        public void OpenLoadingPopup()
        {
            #if UNITY_IOS
            ParentScreen.OpenPopup<LoadingPopup>("Popups/LoadingPopup",
                popup => { loadingPopup = popup; });
            #endif
        }

        public void CloseLoadingPopup()
        {
            #if UNITY_IOS
            if (loadingPopup != null)
            {
                loadingPopup.Close();
            }
            #endif
        }

        public void SetCurrentPurchasableItem(PurchasableItem item)
        {
            currentPurchasableItem = item;
        }
    }
}
