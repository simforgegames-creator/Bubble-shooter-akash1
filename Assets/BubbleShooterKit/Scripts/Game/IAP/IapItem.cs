using System;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
#endif

namespace SimForge.Games.BubbleShooter.Blaze
{



    public enum CoinIcon
    {
        VerySmall,
        Small,
        MediumSmall,
        MediumLarge,
        Large,
        VeryLarge
    }



    [Serializable]
    public class IapItem
    {
        public string StoreId;
        public int NumCoins;
        public int Discount;
        public bool MostPopular;
        public bool BestValue;
        public CoinIcon CoinIcon;

#if UNITY_EDITOR



        public void Draw()
        {
            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Store id");
            StoreId = EditorGUILayout.TextField(StoreId, GUILayout.Width(300));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Coins");
            NumCoins = EditorGUILayout.IntField(NumCoins, GUILayout.Width(70));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Discount");
            Discount = EditorGUILayout.IntField(Discount, GUILayout.Width(70));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Most popular");
            MostPopular = EditorGUILayout.Toggle(MostPopular);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Best value");
            BestValue = EditorGUILayout.Toggle(BestValue);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Coin icon");
            CoinIcon = (CoinIcon)EditorGUILayout.EnumPopup(CoinIcon, GUILayout.Width(100));
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }
#endif
    }
}
