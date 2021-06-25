using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class InventoryItemButton : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Image _icon = null;
        [SerializeField] private Image _buttonImage = null;

        [Header("Graphics")]
        [SerializeField] private Sprite _unequippedButtonSprite = null;
        [SerializeField] private Sprite _equippedButtonSprite = null;
        
        [Header("Model")]
        [SerializeField] private CharacterInventorySO _inventory = null;
        
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
            
            _buttonImage.sprite = _inventory.IsEquipped(item)
                ? _equippedButtonSprite
                : _unequippedButtonSprite;
        }

        private void OnButtonPressed()
        {
            _inventory.TryEquipItem(_item);
        }
    }
}