using UnityEngine;

namespace Base.Simple
{

    public class SimpleFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;


        public GameObject GetNewInstance()
        {
            return Instantiate(_prefab);
        }
    }
}
