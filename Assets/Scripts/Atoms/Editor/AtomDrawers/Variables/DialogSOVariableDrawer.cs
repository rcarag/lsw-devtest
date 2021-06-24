#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Variable property drawer of type `DialogSO`. Inherits from `AtomDrawer&lt;DialogSOVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialogSOVariable))]
    public class DialogSOVariableDrawer : VariableDrawer<DialogSOVariable> { }
}
#endif
