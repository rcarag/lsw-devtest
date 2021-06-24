using UnityEditor;
using UnityAtoms.Editor;
using Game;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Variable Inspector of type `DialogSO`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(DialogSOVariable))]
    public sealed class DialogSOVariableEditor : AtomVariableEditor<DialogSO, DialogSOPair> { }
}
