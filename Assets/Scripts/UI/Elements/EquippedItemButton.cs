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
        
        // Set in Awake()
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
    }
}