using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(ReskinAnimation))]
    public class CharacterSprite : MonoBehaviour
    {
        // Set in Awake()
        private SpriteRenderer _spriteRenderer;
        private ReskinAnimation _reskinAnimation;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _reskinAnimation = GetComponent<ReskinAnimation>();
        }

        public void Initialize(SpriteRenderer referenceSprite, ItemSO item)
        {
            _reskinAnimation.ReferenceSprite = referenceSprite;
            _reskinAnimation.Spritesheet = item.CharacterSpritesheet;
            _spriteRenderer.sortingOrder = item.CharacterSpriteSortingLayer;
        }
    }
}