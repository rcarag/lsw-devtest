#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Value List property drawer of type `DialogSO`. Inherits from `AtomDrawer&lt;DialogSOValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialogSOValueList))]
    public class DialogSOValueListDrawer : AtomDrawer<DialogSOValueList> { }
}
#endif
