using UnityEngine;
using System;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Variable of type `DialogSO`. Inherits from `AtomVariable&lt;DialogSO, DialogSOPair, DialogSOEvent, DialogSOPairEvent, DialogSODialogSOFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/DialogSO", fileName = "DialogSOVariable")]
    public sealed class DialogSOVariable : AtomVariable<DialogSO, DialogSOPair, DialogSOEvent, DialogSOPairEvent, DialogSODialogSOFunction>
    {
        protected override bool ValueEquals(DialogSO other)
        {
            throw new NotImplementedException();
        }
    }
}
