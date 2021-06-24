using System;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityAtoms.Game;
using UnityEngine;

namespace Game
{
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Game/Actions/TalkToShopkeeper")]
    public class TalkToShopkeeperAction : AtomAction
    {
        [Header("Events")]
        [SerializeField] private BoolEvent _setPlayerInputEnabledEvent = null;
        [SerializeField] private DialogSOEvent _dialogScreenOpenedEvent = null;
        [SerializeField] private BoolEvent _dialogScreenNextEvent = null;
        [SerializeField] private VoidEvent _dialogScreenClosedEvent = null;
        [SerializeField] private VoidEvent _shopScreenOpenedEvent = null;
        [SerializeField] private VoidEvent _shopScreenClosedEvent = null;

        [Header("Dialogs")]
        [SerializeField] private DialogSO _helloDialog = null;
        [SerializeField] private DialogSO _goodbyeDialog = null;

        public override void Do()
        {
            _state = State.Hello;
            _setPlayerInputEnabledEvent.Raise(false);
            _dialogScreenNextEvent.Register(OnDialogScreenNext);
            _dialogScreenOpenedEvent.Raise(_helloDialog);
        }

        private void OnDialogScreenNext(bool response)
        {
            if (_state == State.Hello)
            {
                _state = State.Shop;
                _dialogScreenClosedEvent.Raise();
                _shopScreenOpenedEvent.Raise();
                _shopScreenClosedEvent.Register(OnShopScreenClosed);
                return;
            }

            if (_state == State.Goodbye)
            {
                _dialogScreenNextEvent.Unregister(OnDialogScreenNext);
                _dialogScreenClosedEvent.Raise();
                
                _setPlayerInputEnabledEvent.Raise(true);
                return;
            }

            throw new NotImplementedException();
        }

        private void OnShopScreenClosed()
        {
            _state = State.Goodbye;
            _shopScreenClosedEvent.Unregister(OnShopScreenClosed);
            _dialogScreenOpenedEvent.Raise(_goodbyeDialog);
        }

        private State _state;
        
        private enum State
        {
            Hello,
            Shop,
            Goodbye
        }
    }
}