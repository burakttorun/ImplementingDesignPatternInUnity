using UnityEngine;

namespace Base.Utility
{
    public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;

        public T GetNewInstance()
        {
            return Instantiate(_prefab);
        }
    }
}
