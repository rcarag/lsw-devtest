using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Game
{
    public class CharacterInventory : MonoBehaviour
    {
        public CharacterInventorySO Inventory;
        
        [SerializeField] private CharacterCustomizationHandler _customizationHandler = new CharacterCustomizationHandler();

        [Header("Events")]
        [SerializeField] private VoidEvent _equippedItemsChangedEvent;

        private void Awake()
        {
            _equippedItemsChangedEvent.Register(OnEquippedItemsChanged);
        }

        private void OnDestroy()
        {
            _equippedItemsChangedEvent.Unregister(OnEquippedItemsChanged);
        }

        private void Start()
        {
            InitializeCharacterItems();
        }

        private void InitializeCharacterItems()
        {
            _customizationHandler.WearAll(Inventory.EquippedItems);
        }

        private void OnEquippedItemsChanged()
        {
            _customizationHandler.WearAll(Inventory.EquippedItems);
        }
    }
}
