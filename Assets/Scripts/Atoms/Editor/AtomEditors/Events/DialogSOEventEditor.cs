#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Game;

namespace UnityAtoms.Game.Editor
{
    /// <summary>
    /// Event property drawer of type `DialogSO`. Inherits from `AtomEventEditor&lt;DialogSO, DialogSOEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(DialogSOEvent))]
    public sealed class DialogSOEventEditor : AtomEventEditor<DialogSO, DialogSOEvent> { }
}
#endif
