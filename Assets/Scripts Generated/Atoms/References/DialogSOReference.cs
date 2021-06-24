using System;
using UnityAtoms.BaseAtoms;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Reference of type `DialogSO`. Inherits from `AtomReference&lt;DialogSO, DialogSOPair, DialogSOConstant, DialogSOVariable, DialogSOEvent, DialogSOPairEvent, DialogSODialogSOFunction, DialogSOVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class DialogSOReference : AtomReference<
        DialogSO,
        DialogSOPair,
        DialogSOConstant,
        DialogSOVariable,
        DialogSOEvent,
        DialogSOPairEvent,
        DialogSODialogSOFunction,
        DialogSOVariableInstancer>, IEquatable<DialogSOReference>
    {
        public DialogSOReference() : base() { }
        public DialogSOReference(DialogSO value) : base(value) { }
        public bool Equals(DialogSOReference other) { return base.Equals(other); }
        protected override bool ValueEquals(DialogSO other)
        {
            throw new NotImplementedException();
        }
    }
}
