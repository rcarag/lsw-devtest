using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Text))]
    public class PrefixedIntText : MonoBehaviour
    {
        [SerializeField] private StringConstant _prefix = null;
        [SerializeField] private IntVariable _value = null;
        
        // Set in Awake()
        private Text _text;

        private Text TextComponent
        {
            get
            {
                if (_text == null)
                {
                    _text = GetComponent<Text>();
                }

                return _text;
            }
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            SetText(_value.Value);
        }

        public void SetText(int value)
        {
            TextComponent.text = $"{_prefix.Value}{value}";
        }
    }
}