using System;
using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour {
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private QueueManager queueManager;

    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 5f;

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
        GameObject obj = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
        CustomerDraggable customer = obj.GetComponent<CustomerDraggable>();
        customer.SetQueueManager(queueManager);
        queueManager.Enqueue(customer);
    }
}
