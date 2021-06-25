using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    [CreateAssetMenu(menuName = "Game/CharacterSpriteSO")]
    public class CharacterSpriteSO : ScriptableObject
    {
        [SerializeField] private SpritesheetSO _spritesheet = null;
        [SerializeField] private int _sortingOrder = 0;

        public SpritesheetSO Spritesheet => _spritesheet;
        public int SortingOrder => _sortingOrder;
    }
}