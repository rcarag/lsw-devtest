using UnityEngine;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Event of type `DialogSOPair`. Inherits from `AtomEvent&lt;DialogSOPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/DialogSOPair", fileName = "DialogSOPairEvent")]
    public sealed class DialogSOPairEvent : AtomEvent<DialogSOPair>
    {
    }
}
