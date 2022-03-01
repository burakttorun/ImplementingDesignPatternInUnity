using Base.Factory;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRatePerMinute = 30;
    // Current spawn count
    private int currentCount = 0;
    // Reference to used factory
    [SerializeField] private TimedObjectFactory factory;
   
    private void Update()
    {
        var targetCount = Time.time * (spawnRatePerMinute / 60);
        while (targetCount > currentCount)
        {
            var inst = factory.GetNewInstance();
            inst.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-5.0f, 5.0f), 0);
            currentCount++;
        }
    }
}
