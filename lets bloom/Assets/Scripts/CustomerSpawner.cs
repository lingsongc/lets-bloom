using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerSpawner : MonoBehaviour {
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private QueueManager queueManager;

    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 5f;

    [SerializeField] private float spawnRange = 0.5f;
    
    private void Start() {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop() {
        while (true) {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));

            if (!queueManager.IsFull()) {
                SpawnCustomer();
            }
        }
    }

    private void SpawnCustomer() {
        // Vary the x-axis of Customer
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.x += Random.Range(-spawnRange, spawnRange);
        
        // Create a new instance of Customer
        GameObject obj = Instantiate(customerPrefab, spawnPosition, Quaternion.identity);
        CustomerDraggable customer = obj.GetComponent<CustomerDraggable>();
        
        customer.SetQueueManager(queueManager);
        queueManager.Enqueue(customer);
    }
}
