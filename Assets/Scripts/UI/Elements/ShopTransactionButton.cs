using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
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

        [Header("Events")]
        [SerializeField] private IntEvent _playerCoinsChangedEvent = null;
        [SerializeField] private VoidEvent _shopTransactionOccurredEvent = null;
        
        [Header("Model")]
        [SerializeField] private IntVariable _playerCoins = null;
        [SerializeField] private CharacterInventorySO _playerInventory = null;
        [SerializeField] private CharacterInventorySO _shopInventory = null;

        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
            _playerCoinsChangedEvent.Register(UpdateInteractableStatus);
        }

        private void OnDestroy()
        {
            _playerCoinsChangedEvent.Unregister(UpdateInteractableStatus);
        }

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

        private void Start()
        {
            UpdateInteractableStatus();
        }

        private int GetPrice()
        {
            if (_transactionType == TransactionType.Buy)
                return _item.BuyPrice;

            if (_transactionType == TransactionType.Sell)
                return _item.SellPrice;

            throw new NotImplementedException();
        }

        private void UpdateInteractableStatus()
        {
            if (_transactionType == TransactionType.Sell)
            {
                _button.interactable = true;
                return;
            }
            
            if (_transactionType == TransactionType.Buy)
            {
                _button.interactable = _playerCoins.Value >= GetPrice();
                return;
            }

            throw new NotImplementedException();
        }

        private void OnButtonPressed()
        {
            if (_transactionType == TransactionType.Buy)
            {
                BuyItem();
                return;
            }

            if (_transactionType == TransactionType.Sell)
            {
                SellItem();
                return;
            }

            throw new NotImplementedException();
        }

        private void BuyItem()
        {
            _playerCoins.Value -= _item.BuyPrice;
            _shopInventory.TryRemoveItem(_item);
            _playerInventory.AddItem(_item);
            _shopTransactionOccurredEvent.Raise();
        }
        
        private void SellItem()
        {
            _playerCoins.Value += _item.SellPrice;
            _playerInventory.TryRemoveItem(_item);
            _shopInventory.AddItem(_item);
            _shopTransactionOccurredEvent.Raise();
        }

        public enum TransactionType
        {
            Buy,
            Sell
        }
    }
}