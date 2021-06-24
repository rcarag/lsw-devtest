using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class DialogScreen : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Button _positiveButton = null;
        [SerializeField] private Button _negativeButton = null;

        [Header("Events")]
        [SerializeField] private VoidEvent _dialogScreenPositive = null;
        [SerializeField] private VoidEvent _dialogScreenNegative = null;

        private void Awake()
        {
            _positiveButton.onClick.AddListener(OnPositiveButtonPressed);
            _negativeButton.onClick.AddListener(OnNegativeButtonPressed);
        }

        private void OnPositiveButtonPressed()
        {
            _dialogScreenPositive.Raise();
        }

        private void OnNegativeButtonPressed()
        {
            _dialogScreenNegative.Raise();
        }
    }
}
