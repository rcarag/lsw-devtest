using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class InventoryScreen : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Button _closeButton = null;
        [SerializeField] private RectTransform _inventoryItemGrid = null;

        [Header("Events")]
        [SerializeField] private VoidEvent _inventoryScreenClosedEvent = null;

        [Header("Others")]
        [SerializeField] private CharacterInventorySO _inventory = null;
        [SerializeField] private PrefabFactorySO _inventoryItemButtonFactory = null;
        
        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
        }

        private void OnCloseButtonPressed()
        {
            _inventoryScreenClosedEvent.Raise();
            ClearInventoryItems();
        }

        private void OnEnable()
        {
            InitializeInventoryItems();
        }

        private void OnDisable()
        {
            ClearInventoryItems();
        }

        private void InitializeInventoryItems()
        {
            foreach (var item in _inventory.Items)
            {
                _inventoryItemButtonFactory.Create(_inventoryItemGrid,
                    delegate(GameObject instance)
                    {
                        InventoryItemButton inventoryItemButton = instance.GetComponent<InventoryItemButton>();
                        inventoryItemButton.Initialize(item);
                    });
            }
        }

        private void ClearInventoryItems()
        {
            foreach (var child in _inventoryItemGrid.GetComponentsInChildren<RectTransform>())
            {
                if (child == _inventoryItemGrid)
                    continue;
                
                Destroy(child.gameObject);
            }
        }
    }
}