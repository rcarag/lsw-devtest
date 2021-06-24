#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Constant property drawer of type `DialogSO`. Inherits from `AtomDrawer&lt;DialogSOConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialogSOConstant))]
    public class DialogSOConstantDrawer : VariableDrawer<DialogSOConstant> { }
}
#endif
