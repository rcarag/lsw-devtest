using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/ItemSO")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private string _itemName = "Shirt";
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private int _buyPrice = 1;
        [SerializeField] private int _sellPrice = 1;
        [SerializeField] private List<StringConstant> _requiredEquipSlots = new List<StringConstant>();

        public string ItemName => _itemName;
        public Sprite Icon => _icon;
        public int BuyPrice => _buyPrice;
        public int SellPrice => _sellPrice;
        public IReadOnlyCollection<StringConstant> RequiredEquipSlots => _requiredEquipSlots.AsReadOnly();
    }
}