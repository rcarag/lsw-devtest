#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Event property drawer of type `DialogSOPair`. Inherits from `AtomDrawer&lt;DialogSOPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(DialogSOPairEvent))]
    public class DialogSOPairEventDrawer : AtomDrawer<DialogSOPairEvent> { }
}
#endif
