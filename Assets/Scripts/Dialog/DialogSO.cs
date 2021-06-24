using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/DialogSO")]
    public class DialogSO : ScriptableObject
    {
        [Tooltip("Set to empty string to hide the name label")]
        [SerializeField] private string _name = "John";
        [SerializeField] private string _body = "Hello World";
        
        [Tooltip("Set to empty string to hide the positive button")]
        [SerializeField] private string _positiveButtonLabel = "Yes";
        [Tooltip("Set to empty string to hide the negative button")]
        [SerializeField] private string _negativeButtonLabel = "No";

        public string Name => _name;
        public string Body => _body;
        public string PositiveButtonLabel => _positiveButtonLabel;
        public string NegativeButtonLabel => _negativeButtonLabel;
        
        public bool NameVisible => _name.Length > 0;
        public bool PositiveButtonVisible => _positiveButtonLabel.Length > 0;
        public bool NegativeButtonVisible => _negativeButtonLabel.Length > 0;
    }
}