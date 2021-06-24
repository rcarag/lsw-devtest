using UnityEngine;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Value List of type `DialogSO`. Inherits from `AtomValueList&lt;DialogSO, DialogSOEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/DialogSO", fileName = "DialogSOValueList")]
    public sealed class DialogSOValueList : AtomValueList<DialogSO, DialogSOEvent> { }
}
