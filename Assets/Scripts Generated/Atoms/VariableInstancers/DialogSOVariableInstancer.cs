using UnityEngine;
using UnityAtoms.BaseAtoms;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Variable Instancer of type `DialogSO`. Inherits from `AtomVariableInstancer&lt;DialogSOVariable, DialogSOPair, DialogSO, DialogSOEvent, DialogSOPairEvent, DialogSODialogSOFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/DialogSO Variable Instancer")]
    public class DialogSOVariableInstancer : AtomVariableInstancer<
        DialogSOVariable,
        DialogSOPair,
        DialogSO,
        DialogSOEvent,
        DialogSOPairEvent,
        DialogSODialogSOFunction>
    { }
}
