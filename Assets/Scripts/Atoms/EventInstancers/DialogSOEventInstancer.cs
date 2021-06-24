using UnityEngine;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Event Instancer of type `DialogSO`. Inherits from `AtomEventInstancer&lt;DialogSO, DialogSOEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/DialogSO Event Instancer")]
    public class DialogSOEventInstancer : AtomEventInstancer<DialogSO, DialogSOEvent> { }
}
