using UnityEngine;
using UnityAtoms.BaseAtoms;
using Game;

namespace UnityAtoms.Game
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type DialogSO to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync DialogSO Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncDialogSOVariableInstancerToCollection : SyncVariableInstancerToCollection<DialogSO, DialogSOVariable, DialogSOVariableInstancer> { }
}
