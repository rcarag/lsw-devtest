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

        [SerializeField] private Transform _characterSpriteParent = null;

        [SerializeField] private SpriteRenderer _baseSpriteRenderer;

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