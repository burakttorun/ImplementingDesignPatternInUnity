using UnityEngine;

public class TimeoutObject : MonoBehaviour
{
    [SerializeField] private float timeout = 2;
    // Saving enable time to calculate when to destroy itself
    private float startTime;

    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        // Waiting for timeout
        if (Time.time - startTime > timeout)
        {
            // Destroying object
            Destroy(gameObject);
        }
    }
}
