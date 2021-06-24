using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ShopScreen : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Button _closeButton = null;

        [Header("Events")]
        [SerializeField] private VoidEvent _shopScreenClosedEvent = null;
        
        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
        }

        private void OnCloseButtonPressed()
        {
            _shopScreenClosedEvent.Raise();
        }
    }

}