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

        private void Start()
        {
            InitializeCharacterItems();
        }

        private void InitializeCharacterItems()
        {
            _customizationHandler.WearAll(Inventory.EquippedItems);
        }
    }
}
