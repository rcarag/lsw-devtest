#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Game;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Event property drawer of type `DialogSOPair`. Inherits from `AtomEventEditor&lt;DialogSOPair, DialogSOPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(DialogSOPairEvent))]
    public sealed class DialogSOPairEventEditor : AtomEventEditor<DialogSOPair, DialogSOPairEvent> { }
}
#endif
