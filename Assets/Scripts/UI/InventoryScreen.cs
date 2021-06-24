using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class InventoryScreen : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Button _closeButton = null;

        [Header("Events")]
        [SerializeField] private VoidEvent _inventoryScreenClosedEvent = null;
        
        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
        }

        private void OnCloseButtonPressed()
        {
            _inventoryScreenClosedEvent.Raise();
        }
    }
}