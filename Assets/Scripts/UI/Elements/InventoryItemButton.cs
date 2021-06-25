using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class InventoryItemButton : MonoBehaviour
    {
        [SerializeField] private CharacterInventorySO _inventory = null;

        [Header("UI Elements")]
        [SerializeField] private Image _icon = null;
        
        // Set in Awake
        private Button _button = null;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
        }
        
        // Set in Initialize
        private ItemSO _item = null;

        public void Initialize(ItemSO item)
        {
            _item = item;
            _icon.sprite = item.Icon;
        }

        private void OnButtonPressed()
        {
            _inventory.TryEquipItem(_item);
        }
    }
}