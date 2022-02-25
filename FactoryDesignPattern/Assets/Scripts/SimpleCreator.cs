using UnityEngine;

namespace Base.Simple
{

    public class SimpleCreator : MonoBehaviour
    {
        [SerializeField] SimpleFactory _simpleFactory;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject gameObject = _simpleFactory.GetNewInstance();
                gameObject.transform.position = this.transform.position + (Vector3.up * 3);
            }
        }
    }
}