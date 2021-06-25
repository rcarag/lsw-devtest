using System;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/CharacterInventorySO")]
    public class CharacterInventorySO : ScriptableObject
    {
        [Header("See tooltips for more info")]
        [Tooltip("The equip slots that are available for this inventory")]
        [SerializeField] private List<StringConstant> _equipSlots = new List<StringConstant>();
        
        [Tooltip("Drag ItemSOs to set as initial inventory contents here")]
        [SerializeField] private List<ItemSO> _inventoryItems = new List<ItemSO>();
        
        [Tooltip("Drag ItemSOs to set as initial equipped items here (must exist in inventory and be equippable)")]
        [SerializeField] private List<ItemSO> _equippedItems = new List<ItemSO>();
        
        public IReadOnlyCollection<ItemSO> Items => _inventoryItems.AsReadOnly();
        public IReadOnlyCollection<ItemSO> EquippedItems => _equippedItems.AsReadOnly();

        private void OnValidate()
        {
            ValidateEquippedItems();
        }

        private void ValidateEquippedItems()
        {
            for (int i = _equippedItems.Count - 1; i >= 0; i--)
            {
                if (!CanEquipItem(_equippedItems[i]))
                {
                    _equippedItems.RemoveAt(i);
                }
            }
        }

        public bool CanEquipItem(ItemSO item)
        {
            return HasItem(item) && HasAllRequiredEquipSlots(item);
        }

        public bool HasItem(ItemSO item)
        {
            if (item == null) return false;
            
            return _inventoryItems.Contains(item);
        }

        public bool HasAllRequiredEquipSlots(ItemSO item)
        {
            if (item == null) return false;
            
            foreach (var requiredSlot in item.RequiredEquipSlots)
            {
                if (requiredSlot == null)
                    continue;

                if (!_equipSlots.Contains(requiredSlot))
                    return false;
            }

            return true;
        }

        public bool TryEquipItem(ItemSO item)
        {
            if (!CanEquipItem(item))
                return false;
            
            Debug.Log("Equipping item: " + item.ItemName);

            throw new NotImplementedException();
        }
    }
}