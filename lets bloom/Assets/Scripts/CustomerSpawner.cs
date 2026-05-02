using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerSpawner : MonoBehaviour {
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private QueueManager queueManager;

    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 5f;

    [SerializeField] public static float spawnRange = 0.5f;
    
    private void Start() {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            if (!queueManager.IsFull()) {
                SpawnCustomer();
            }
        }
    }

    private void SpawnCustomer() {
        // Vary the x-axis of Customer
        Vector3 spawnPosition = spawnPoint.position;
        float xOffset = Random.Range(-spawnRange, spawnRange);
        spawnPosition.x += xOffset;
        
        // Create a new instance of Customer
        GameObject obj = Instantiate(customerPrefab, spawnPosition, Quaternion.identity);
        CustomerDraggable customer = obj.GetComponent<CustomerDraggable>();
        customer.xOffset = xOffset;
        
        customer.SetQueueManager(queueManager);
        queueManager.Enqueue(customer);
    }
}
