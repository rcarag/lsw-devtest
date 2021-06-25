using System;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class CharacterCustomizationHandler
    {
        [SerializeField] private PrefabFactorySO _characterSpriteFactory = null;

        [Tooltip("When equipment sprites are created, they will be instantiated as a child of this Transform.")]
        [SerializeField] private Transform _characterSpriteParent = null;

        [Tooltip("Set to the SpriteRenderer that will be used as the reference for the current animation frame.")]
        [SerializeField] private SpriteRenderer _baseSpriteRenderer = null;

        public void WearAll(IReadOnlyCollection<ItemSO> equippedItems)
        {
            DestroyExistingGraphics();
            
            foreach (var item in equippedItems)
            {
                if (!item.HasCharacterSprite)
                    continue;

                var graphic = _characterSpriteFactory.Create(_characterSpriteParent,
                    delegate(GameObject instance)
                    {
                        instance.name = "Character Sprite: " + item.ItemName;
                        var characterSpriteFacade = instance.GetComponent<CharacterSprite>();
                        characterSpriteFacade.Initialize(_baseSpriteRenderer, item);
                        
                        _graphics.Add(instance);
                    });
            }
        }

        private void DestroyExistingGraphics()
        {
            foreach (var graphic in _graphics)
            {
                GameObject.Destroy(graphic);                
            }
            
            _graphics.Clear();
        }
        
        private readonly HashSet<GameObject> _graphics = new HashSet<GameObject>();
    }
}