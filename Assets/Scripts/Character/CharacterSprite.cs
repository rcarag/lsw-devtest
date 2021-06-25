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

        public void Initialize(CharacterSpriteSO characterSprite)
        {
            _reskinAnimation.Spritesheet = characterSprite.Spritesheet;
            _spriteRenderer.sortingOrder = characterSprite.SortingOrder;
        }
    }
}