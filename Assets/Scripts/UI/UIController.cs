using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Game
{
    public class UIController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField]
        private RectTransform _inventoryScreen = null;

        [Header("Events")]
        [SerializeField] private VoidEvent _inventoryScreenOpenedEvent = null;
        [SerializeField] private VoidEvent _inventoryScreenClosedEvent = null;
        [SerializeField] private BoolEvent _setPlayerInputEnabledEvent = null;

        private void Awake()
        {   
            _inventoryScreen.gameObject.SetActive(false);
            
            _inventoryScreenOpenedEvent.Register(InventoryScreenOpened);
            _inventoryScreenClosedEvent.Register(InventoryScreenClosed);
        }

        private void InventoryScreenOpened()
        {
            _setPlayerInputEnabledEvent.Raise(false);
            _inventoryScreen.gameObject.SetActive(true);
        }

        private void InventoryScreenClosed()
        {
            _inventoryScreen.gameObject.SetActive(false);
            _setPlayerInputEnabledEvent.Raise(true);
        }
    }
}