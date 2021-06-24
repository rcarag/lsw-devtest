using UnityEngine;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Event Reference Listener of type `DialogSOPair`. Inherits from `AtomEventReferenceListener&lt;DialogSOPair, DialogSOPairEvent, DialogSOPairEventReference, DialogSOPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/DialogSOPair Event Reference Listener")]
    public sealed class DialogSOPairEventReferenceListener : AtomEventReferenceListener<
        DialogSOPair,
        DialogSOPairEvent,
        DialogSOPairEventReference,
        DialogSOPairUnityEvent>
    { }
}
