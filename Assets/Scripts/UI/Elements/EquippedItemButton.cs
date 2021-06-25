using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class EquippedItemButton : MonoBehaviour
    {
        [SerializeField] private CharacterInventorySO _inventory;
        [SerializeField] private StringConstant _equipSlotTag;

        [Header("UI Elements")]
        [SerializeField] private Image _itemIcon;

        [Header("Events")]
        [SerializeField] private VoidEvent _equippedItemsChangedEvent;
        
        // Set in Awake()
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
            _equippedItemsChangedEvent.Register(OnEquippedItemsChanged);
        }

        private void Start()
        {
            UpdateButton();
        }

        private void OnDestroy()
        {
            _equippedItemsChangedEvent.Unregister(OnEquippedItemsChanged);
        }

        private void UpdateButton()
        {
            if (_inventory.TryGetEquippedItem(_equipSlotTag, out var item))
            {
                SetEquippedItem(item);
                return;
            }
            
            SetUnequipped();
        }

        private void SetEquippedItem(ItemSO item)
        {
            _button.interactable = true;
            _itemIcon.enabled = true;
            _itemIcon.sprite = item.Icon;
        }

        private void SetUnequipped()
        {
            _button.interactable = false;
            _itemIcon.enabled = false;
        }

        private void OnEquippedItemsChanged()
        {
            UpdateButton();
        }

        private void OnButtonPressed()
        {
            _inventory.TryUnequipSlot(_equipSlotTag, out _);
        }
    }
}