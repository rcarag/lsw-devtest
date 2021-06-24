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
        [SerializeField] private SpritesheetSO _spritesheet = null;

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
            if (_spritesheet == null)
                return;

            var spriteName = _spriteRenderer.sprite.name;

            if (_spritesheet.FindSprite(spriteName, out var reskinSprite))
            {
                _spriteRenderer.sprite = reskinSprite;
            }
        }
    }
}