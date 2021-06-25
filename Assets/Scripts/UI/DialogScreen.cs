using UnityAtoms.BaseAtoms;
using UnityAtoms.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class DialogScreen : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Button _positiveButton = null;
        [SerializeField] private Button _negativeButton = null;
        [SerializeField] private RectTransform _namePlate = null;
        [SerializeField] private Text _nameText = null;
        [SerializeField] private Text _bodyText = null;
        [SerializeField] private Text _positiveButtonText = null;
        [SerializeField] private Text _negativeButtonText = null;

        [Header("Events")]
        [SerializeField] private DialogSOEvent _dialogScreenOpenedEvent = null;
        [SerializeField] private BoolEvent _dialogScreenNextEvent = null;

        private void Awake()
        {
            _dialogScreenOpenedEvent.Register(OnDialogScreenOpened);
            
            _positiveButton.onClick.AddListener(OnPositiveButtonPressed);
            _negativeButton.onClick.AddListener(OnNegativeButtonPressed);
        }

        private void OnDialogScreenOpened(DialogSO content)
        {
            _nameText.text = content.Name;
            _bodyText.text = content.Body;
            _positiveButtonText.text = content.PositiveButtonLabel;
            _negativeButtonText.text = content.NegativeButtonLabel;
            
            _namePlate.gameObject.SetActive(content.NameVisible);
            _positiveButton.gameObject.SetActive(content.PositiveButtonVisible);
            _negativeButton.gameObject.SetActive(content.NegativeButtonVisible);
        }
        
        private void OnPositiveButtonPressed()
        {
            _dialogScreenNextEvent.Raise(true);
        }

        private void OnNegativeButtonPressed()
        {
            _dialogScreenNextEvent.Raise(false);
        }
    }
}
