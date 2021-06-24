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

        private void OnValidate()
        {
            ValidateEquippedItems();
        }

        private void ValidateEquippedItems()
        {
            for (int i = _equippedItems.Count - 1; i >= 0; i--)
            {
                if (!EquippedItemIsValid(_equippedItems[i]))
                {
                    _equippedItems.RemoveAt(i);
                }
            }
        }

        private bool EquippedItemIsValid(ItemSO item)
        {
            if (item == null) return true;
            
            return HasItem(item) && CanEquipItem(item);
        }

        public bool HasItem(ItemSO item)
        {
            return _inventoryItems.Contains(item);
        }

        public bool CanEquipItem(ItemSO item)
        {
            foreach (var requiredSlot in item.RequiredEquipSlots)
            {
                if (requiredSlot == null)
                    continue;

                if (!_equipSlots.Contains(requiredSlot))
                    return false;
            }

            return true;
        }
    }
}