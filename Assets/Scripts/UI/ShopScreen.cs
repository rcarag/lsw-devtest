using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ShopScreen : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Button _closeButton = null;
        [SerializeField] private RectTransform _playerInventoryItemsGrid;
        [SerializeField] private RectTransform _shopInventoryItemsGrid;

        [Header("Events")]
        [SerializeField] private VoidEvent _shopScreenOpenedEvent = null;
        [SerializeField] private VoidEvent _shopScreenClosedEvent = null;
        [SerializeField] private VoidEvent _shopTransactionOccurredEvent = null;

        [Header("Factories")]
        [SerializeField] private PrefabFactorySO _shopBuyButtonFactory = null;
        [SerializeField] private PrefabFactorySO _shopSellButtonFactory = null;
        
        [Header("Model")]
        [SerializeField] private CharacterInventorySO _playerInventory = null;
        [SerializeField] private CharacterInventorySO _shopInventory = null;
        
        private void Awake()
        {
            _shopScreenOpenedEvent.Register(OnShopScreenOpened);
            _shopTransactionOccurredEvent.Register(OnShopTransactionOccurred);
            
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
        }

        private void OnDestroy()
        {
            _shopScreenOpenedEvent.Unregister(OnShopScreenOpened);
            _shopTransactionOccurredEvent.Unregister(OnShopTransactionOccurred);
        }

        private void OnCloseButtonPressed()
        {
            _shopScreenClosedEvent.Raise();
            ClearShopItems();
        }

        private void OnShopScreenOpened()
        {
            InitializeShopItems();
        }

        private void InitializeShopItems()
        {
            foreach (var item in _playerInventory.Items)
            {
                if (_playerInventory.EquippedItems.Contains(item))
                    continue;

                _shopSellButtonFactory.Create(_playerInventoryItemsGrid, delegate(GameObject instance)
                {
                    var txButton = instance.GetComponent<ShopTransactionButton>();
                    txButton.Initialize(item, ShopTransactionButton.TransactionType.Sell);
                });
            }
            
            foreach (var item in _shopInventory.Items)
            {
                _shopBuyButtonFactory.Create(_shopInventoryItemsGrid, delegate(GameObject instance)
                {
                    var txButton = instance.GetComponent<ShopTransactionButton>();
                    txButton.Initialize(item, ShopTransactionButton.TransactionType.Buy);
                });
            }
        }

        private void ClearShopItems()
        {
            foreach (var child in _playerInventoryItemsGrid.GetComponentsInChildren<RectTransform>())
            {
                if (child == _playerInventoryItemsGrid)
                    continue;
                
                Destroy(child.gameObject);
            }
            
            foreach (var child in _shopInventoryItemsGrid.GetComponentsInChildren<RectTransform>())
            {
                if (child == _shopInventoryItemsGrid)
                    continue;
                
                Destroy(child.gameObject);
            }
        }

        private void OnShopTransactionOccurred()
        {
            ClearShopItems();
            InitializeShopItems();
        }
    }

}