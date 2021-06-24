using UnityAtoms.BaseAtoms;
using UnityAtoms.Game;
using UnityEngine;

namespace Game
{
    public class UIController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private RectTransform _inventoryScreen = null;
        [SerializeField] private RectTransform _dialogScreen = null;
        

        [Header("Events")]
        [SerializeField] private DialogSOEvent _dialogScreenOpenedEvent = null;
        [SerializeField] private VoidEvent _dialogScreenClosedEvent = null;
        [SerializeField] private VoidEvent _inventoryScreenOpenedEvent = null;
        [SerializeField] private VoidEvent _inventoryScreenClosedEvent = null;
        [SerializeField] private BoolEvent _setPlayerInputEnabledEvent = null;

        private void Awake()
        {   
            _inventoryScreen.gameObject.SetActive(false);
            _dialogScreen.gameObject.SetActive(false);

            _dialogScreenOpenedEvent.Register(OnDialogScreenOpened);
            _dialogScreenClosedEvent.Register(OnDialogScreenClosed);
            _inventoryScreenOpenedEvent.Register(OnInventoryScreenOpened);
            _inventoryScreenClosedEvent.Register(OnInventoryScreenClosed);
        }

        private void OnInventoryScreenOpened()
        {
            _setPlayerInputEnabledEvent.Raise(false);
            _inventoryScreen.gameObject.SetActive(true);
        }

        private void OnInventoryScreenClosed()
        {
            _inventoryScreen.gameObject.SetActive(false);
            _setPlayerInputEnabledEvent.Raise(true);
        }

        private void OnDialogScreenOpened()
        {
            _setPlayerInputEnabledEvent.Raise(false);
            _dialogScreen.gameObject.SetActive(true);
        }

        private void OnDialogScreenClosed()
        {
            _dialogScreen.gameObject.SetActive(false);
            _setPlayerInputEnabledEvent.Raise(true);
        }
    }
}