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
        public Texture2D ReskinTexture;
        public List<Sprite> ReskinSprites;

        // Set in Awake()
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            foreach (var sprite in ReskinSprites)
            {
                _spritesDict[sprite.name] = sprite;
            }
        }

        private void LateUpdate()
        {
            var spriteName = _spriteRenderer.sprite.name;
            
            if (!_spritesDict.ContainsKey(spriteName))
                return;

            _spriteRenderer.sprite = _spritesDict[spriteName];
        }

        private void OnValidate()
        {
            if (ReskinTexture == null)
                return;
            
            string spritesheetPath = AssetDatabase.GetAssetPath(ReskinTexture);
            
            ReskinSprites.Clear();

            var sprites = AssetDatabase.LoadAllAssetsAtPath(spritesheetPath)
                .OfType<Sprite>();

            ReskinSprites.AddRange(sprites);    ;
        }

        private readonly Dictionary<string, Sprite> _spritesDict = new Dictionary<string, Sprite>();
    }
}