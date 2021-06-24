using System;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Event Reference of type `DialogSO`. Inherits from `AtomEventReference&lt;DialogSO, DialogSOVariable, DialogSOEvent, DialogSOVariableInstancer, DialogSOEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class DialogSOEventReference : AtomEventReference<
        DialogSO,
        DialogSOVariable,
        DialogSOEvent,
        DialogSOVariableInstancer,
        DialogSOEventInstancer>, IGetEvent 
    { }
}
