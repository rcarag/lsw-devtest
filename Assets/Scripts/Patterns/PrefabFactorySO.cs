using UnityEngine;


namespace Game
{
    [CreateAssetMenu(menuName = "Game/PrefabFactorySO")]
    public class PrefabFactorySO : ScriptableObject
    {
        [SerializeField] private GameObject _prefab = null;

        public GameObject Create(Transform parent, OnCreateDelegate onCreate)
        {
            var instance = Instantiate(_prefab, parent);
            
            onCreate(instance);

            return instance;
        }
        
        public delegate void OnCreateDelegate(GameObject instance);
    }
}