using UnityEngine;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Event of type `DialogSO`. Inherits from `AtomEvent&lt;DialogSO&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/DialogSO", fileName = "DialogSOEvent")]
    public sealed class DialogSOEvent : AtomEvent<DialogSO>
    {
    }
}
