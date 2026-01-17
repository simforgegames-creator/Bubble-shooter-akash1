using UnityEngine;
#if BUBBLE_SHOOTER_ENABLE_IAP
using UnityEngine.Purchasing;
#endif

namespace SimForge.Games.BubbleShooter.Blaze
{



#if BUBBLE_SHOOTER_ENABLE_IAP
    public class PurchaseManager : MonoBehaviour, IStoreListener
    #else
    public class PurchaseManager : MonoBehaviour
#endif
    {
        public GameConfiguration GameConfig;
        public CoinsSystem CoinsSystem;
        
#if BUBBLE_SHOOTER_ENABLE_IAP
        public IStoreController Controller { get; set; }

        void Start()
        {
            DontDestroyOnLoad(gameObject);
            
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            foreach (var item in GameConfig.IapItems)
                builder.AddProduct(item.StoreId, ProductType.Consumable);
            UnityPurchasing.Initialize(this, builder);
        }



        public void OnInitialized(IStoreController storeController, IExtensionProvider extensionProvider)
        {
            Controller = storeController;
        }



        public void OnInitializeFailed(InitializationFailureReason error)
        {
        }



        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
        {
            var purchasedProductId = e.purchasedProduct.definition.id;
            var catalogProduct =
                GameConfig.IapItems.Find(x => x.StoreId == purchasedProductId);
            if (catalogProduct != null)
            {
                CoinsSystem.BuyCoins(catalogProduct.NumCoins);
			    var shopPopup = FindObjectOfType<BuyCoinsPopup>();
                if (shopPopup != null)
                {
                    shopPopup.GetComponent<BuyCoinsPopup>().CloseLoadingPopup();
                    shopPopup.GetComponent<BuyCoinsPopup>().ParentScreen.OpenPopup<AlertPopup>("Popups/AlertPopup",
                        popup =>
                        {
                            popup.SetText($"You purchased {catalogProduct.NumCoins} coins!");
                        });
                }
            }
            return PurchaseProcessingResult.Complete;
        }



        public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
        {
            var shopPopup = FindObjectOfType<BuyCoinsPopup>();
            if (shopPopup != null)
            {
                shopPopup.GetComponent<BuyCoinsPopup>().CloseLoadingPopup();
                shopPopup.GetComponent<BuyCoinsPopup>().ParentScreen.OpenPopup<AlertPopup>("Popups/AlertPopup",
                    popup =>
                    {
                        popup.SetText(
                            $"There was an error when purchasing {product.metadata.localizedTitle}: {GetPurchaseFailureReasonString(reason)}");
                    });
            }
        }
        public void OnInitializeFailed(InitializationFailureReason error, string a)
        {
        }



        string GetPurchaseFailureReasonString(PurchaseFailureReason reason)
        {
            switch (reason)
            {
                case PurchaseFailureReason.DuplicateTransaction:
                    return "Duplicate transaction.";

                case PurchaseFailureReason.ExistingPurchasePending:
                    return "Existing purchase pending.";

                case PurchaseFailureReason.PaymentDeclined:
                    return "Payment was declined.";

                case PurchaseFailureReason.ProductUnavailable:
                    return "Product is not available.";

                case PurchaseFailureReason.PurchasingUnavailable:
                    return "Purchasing is not available.";

                case PurchaseFailureReason.SignatureInvalid:
                    return "Invalid signature.";

                case PurchaseFailureReason.Unknown:
                    return "Unknown error.";

                case PurchaseFailureReason.UserCancelled:
                    return "User cancelled.";

            }

            return "Unknown error.";
        }
        #endif
    }
}
