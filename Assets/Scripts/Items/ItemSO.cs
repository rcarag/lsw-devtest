using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/ItemSO")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _buyPrice;
        [SerializeField] private int _sellPrice;

        public string ItemName => _itemName;
        public Sprite Icon => _icon;
        public int BuyPrice => _buyPrice;
        public int SellPrice => _sellPrice;
    }
}