#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Event property drawer of type `DialogSO`. Inherits from `AtomDrawer&lt;DialogSOEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialogSOEvent))]
    public class DialogSOEventDrawer : AtomDrawer<DialogSOEvent> { }
}
#endif
