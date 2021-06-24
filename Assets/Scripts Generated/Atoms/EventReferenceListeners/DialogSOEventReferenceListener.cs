using UnityEngine;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Event Reference Listener of type `DialogSO`. Inherits from `AtomEventReferenceListener&lt;DialogSO, DialogSOEvent, DialogSOEventReference, DialogSOUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/DialogSO Event Reference Listener")]
    public sealed class DialogSOEventReferenceListener : AtomEventReferenceListener<
        DialogSO,
        DialogSOEvent,
        DialogSOEventReference,
        DialogSOUnityEvent>
    { }
}
