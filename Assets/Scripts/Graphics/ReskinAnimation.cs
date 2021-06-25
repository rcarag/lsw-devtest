using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Based on https://youtu.be/rMCLWt1DuqI?t=1316
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ReskinAnimation : MonoBehaviour
    {
        public SpritesheetSO Spritesheet = null;

        // Set in Awake()
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void LateUpdate()
        {
            ReskinSprite();
        }

        private void ReskinSprite()
        {
            if (Spritesheet == null)
                return;

            var spriteName = ReferenceSprite.sprite.name;

            if (Spritesheet.FindSprite(spriteName, out var reskinSprite))
            {
                _spriteRenderer.sprite = reskinSprite;
            }
        }

        private SpriteRenderer _otherSpriteRenderer = null;

        public SpriteRenderer ReferenceSprite
        {
            get => _otherSpriteRenderer == null ? _spriteRenderer : _otherSpriteRenderer;

            set => _otherSpriteRenderer = value;
        }
    }
}