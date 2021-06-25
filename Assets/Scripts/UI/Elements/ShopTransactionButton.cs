using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class ShopTransactionButton : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Image _iconImage = null;
        [SerializeField] private Text _priceText = null;

        // Set in Initialize()
        private ItemSO _item;
        private TransactionType _transactionType;
        
        public void Initialize(ItemSO item, TransactionType transactionType)
        {
            _item = item;
            _transactionType = transactionType;
            
            _iconImage.sprite = item.Icon;
            _priceText.text = "$" + GetPrice();
        }

        private int GetPrice()
        {
            if (_transactionType == TransactionType.Buy)
                return _item.BuyPrice;

            if (_transactionType == TransactionType.Sell)
                return _item.SellPrice;

            throw new NotImplementedException();
        }

        public enum TransactionType
        {
            Buy,
            Sell
        }
    }
}