using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class CharacterCustomizationHandler
    {
        [SerializeField] private PrefabFactorySO _characterSpriteFactory = null;

        [SerializeField] private Transform _characterSpriteParent = null;

        public void WearAll(IReadOnlyCollection<ItemSO> equippedItems)
        {   
            foreach (var item in equippedItems)
            {
                if (!item.HasCharacterSprite)
                    continue;

                var graphic = _characterSpriteFactory.Create(_characterSpriteParent,
                    delegate(GameObject instance)
                    {
                        instance.name = "Character Sprite: " + item.ItemName;
                        var characterSpriteFacade = instance.GetComponent<CharacterSprite>();
                        characterSpriteFacade.Initialize(item.CharacterSprite);
                        
                        _graphics.Add(instance);
                    });
            }
        }
        
        private readonly HashSet<GameObject> _graphics = new HashSet<GameObject>();
    }
}