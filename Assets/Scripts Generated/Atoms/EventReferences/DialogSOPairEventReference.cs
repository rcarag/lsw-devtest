using System;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Event Reference of type `DialogSOPair`. Inherits from `AtomEventReference&lt;DialogSOPair, DialogSOVariable, DialogSOPairEvent, DialogSOVariableInstancer, DialogSOPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class DialogSOPairEventReference : AtomEventReference<
        DialogSOPair,
        DialogSOVariable,
        DialogSOPairEvent,
        DialogSOVariableInstancer,
        DialogSOPairEventInstancer>, IGetEvent 
    { }
}
