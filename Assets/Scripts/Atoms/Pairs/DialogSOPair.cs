using System;
using UnityEngine;
using Game;
namespace UnityAtoms.Game
{
    /// <summary>
    /// IPair of type `&lt;DialogSO&gt;`. Inherits from `IPair&lt;DialogSO&gt;`.
    /// </summary>
    [Serializable]
    public struct DialogSOPair : IPair<DialogSO>
    {
        public DialogSO Item1 { get => _item1; set => _item1 = value; }
        public DialogSO Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private DialogSO _item1;
        [SerializeField]
        private DialogSO _item2;

        public void Deconstruct(out DialogSO item1, out DialogSO item2) { item1 = Item1; item2 = Item2; }
    }
}