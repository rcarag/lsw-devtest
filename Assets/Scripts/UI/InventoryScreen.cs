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

        private void Start()
        {
            InitializeInventoryItems();
        }

        private void OnCloseButtonPressed()
        {
            _inventoryScreenClosedEvent.Raise();
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
    }
}