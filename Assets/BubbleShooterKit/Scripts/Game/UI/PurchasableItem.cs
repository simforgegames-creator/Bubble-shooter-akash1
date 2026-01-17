using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{
    public class PurchasableItem : MonoBehaviour
    {
        [HideInInspector]
        public BuyCoinsPopup BuyCoinsPopup;

        [SerializeField]
        GameObject mostPopular = null;
        [SerializeField]
        GameObject bestValue = null;
        [SerializeField]
        GameObject discount = null;
        [SerializeField]
        TextMeshProUGUI discountText = null;
        [SerializeField]
        TextMeshProUGUI numCoinsText = null;
        [SerializeField]
        Text priceText = null;
        [SerializeField]
        Image coinsImage = null;
        [SerializeField]
        List<Sprite> coinIcons = null;
        [SerializeField]
        ParticleSystem coinsParticles = null;

        IapItem cachedItem;

        void Awake()
        {
            Assert.IsNotNull(mostPopular);
            Assert.IsNotNull(bestValue);
            Assert.IsNotNull(discount);
            Assert.IsNotNull(discountText);
            Assert.IsNotNull(numCoinsText);
            Assert.IsNotNull(priceText);
            Assert.IsNotNull(coinsImage);
            Assert.IsNotNull(coinsParticles);
        }

        public void Fill(IapItem item)
        {
            cachedItem = item;

            numCoinsText.text = item.NumCoins.ToString("n0");
            if (item.Discount > 0)
                discountText.text = $"{item.Discount}%";
            else
                discount.SetActive(false);

            if (item.MostPopular)
            {
                bestValue.SetActive(false);
            }
            else if (item.BestValue)
            {
                mostPopular.SetActive(false);
            }
            else
            {
                mostPopular.SetActive(false);
                bestValue.SetActive(false);
            }

            coinsImage.sprite = coinIcons[(int)item.CoinIcon];
            coinsImage.SetNativeSize();

#if BUBBLE_SHOOTER_ENABLE_IAP
            var storeController = FindAnyObjectByType<PurchaseManager>().Controller;
            if (storeController != null)
            {
                Debug.Log("Filling IAP item price for " + item.StoreId);
                var product = storeController.products.WithID(item.StoreId);
                if (product != null)
                    priceText.text = product.metadata.localizedPriceString;
            }
#else
            priceText.text = "$5,99";
#endif
        }

        public void OnPurchaseButtonPressed()
        {
#if BUBBLE_SHOOTER_ENABLE_IAP
            var storeController = FindAnyObjectByType<PurchaseManager>().Controller;
            if (storeController != null)
            {
                storeController.InitiatePurchase(cachedItem.StoreId);
                BuyCoinsPopup.SetCurrentPurchasableItem(this);
                BuyCoinsPopup.OpenLoadingPopup();
            }
#else
            BuyCoinsPopup.SetCurrentPurchasableItem(this);
            BuyCoinsPopup.CoinsSystem.BuyCoins(cachedItem.NumCoins);
#endif
        }

        public void PlayCoinParticles()
        {
            coinsParticles.Play();
        }
    }
}
