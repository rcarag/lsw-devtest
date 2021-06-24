using System.Collections.Generic;
using System.Linq;
using UnityAtoms;
using UnityEditor;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/SpritesheetSO")]
    public class SpritesheetSO : ScriptableObject
    {
        [Header("Set in Inspector")]
        [SerializeField] private Texture2D _spritesheet = null;

        [Header("For Debug Only")]
        [ReadOnly] public List<Sprite> Sprites = new List<Sprite>();

        private void OnEnable()
        {
            InitializeSpriteDictionary();
        }

        private void OnValidate()
        {
            LoadSpritesFromTexture();
        }

        private void LoadSpritesFromTexture()
        {
            Sprites.Clear();
            
            if (_spritesheet == null)
                return;
            
            string spritesheetPath = AssetDatabase.GetAssetPath(_spritesheet);

            var sprites = AssetDatabase.LoadAllAssetsAtPath(spritesheetPath)
                .OfType<Sprite>();

            Sprites.AddRange(sprites);
        }

        private void InitializeSpriteDictionary()
        {
            _spritesDict = new Dictionary<string, Sprite>();

            foreach (var sprite in Sprites)
            {
                _spritesDict[sprite.name] = sprite;
            }
        }

        public bool FindSprite(string name, out Sprite sprite)
        {
            if (!_spritesDict.ContainsKey(name))
            {
                sprite = null;
                return false;
            }

            sprite = _spritesDict[name];
            return true;
        }

        private Dictionary<string, Sprite> _spritesDict;
    }
}