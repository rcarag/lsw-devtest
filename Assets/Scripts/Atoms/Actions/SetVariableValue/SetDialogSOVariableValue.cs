using UnityEngine;
using UnityAtoms.BaseAtoms;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Set variable value Action of type `DialogSO`. Inherits from `SetVariableValue&lt;DialogSO, DialogSOPair, DialogSOVariable, DialogSOConstant, DialogSOReference, DialogSOEvent, DialogSOPairEvent, DialogSOVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/DialogSO", fileName = "SetDialogSOVariableValue")]
    public sealed class SetDialogSOVariableValue : SetVariableValue<
        DialogSO,
        DialogSOPair,
        DialogSOVariable,
        DialogSOConstant,
        DialogSOReference,
        DialogSOEvent,
        DialogSOPairEvent,
        DialogSODialogSOFunction,
        DialogSOVariableInstancer>
    { }
}
