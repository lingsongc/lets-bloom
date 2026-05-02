using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour {
    
    // Parameters
    [SerializeField] private int queueMaxSize = 5;
    [SerializeField] private float queueSpacing = 1.5f;
    [SerializeField] private float queueVariation = 0.3f;
    [SerializeField] private Transform queueStartPoint;
    
    private Vector2 queueDirection = Vector2.down;
    
    private List<CustomerDraggable> queue = new List<CustomerDraggable>();
    
    public bool IsFull() {
        return queue.Count >= queueMaxSize;
    }

    public void Enqueue(CustomerDraggable customer) {
        if (IsFull()) return;
        
        customer.queueOffset = Random.Range(-queueVariation, queueVariation);
        queue.Add(customer);
        UpdateQueue();
    }

    public void Dequeue(CustomerDraggable customer) {
        int index = queue.IndexOf(customer);
        
        if (queue.Remove(customer)) {
            // Jiggle the Customers around
            for (int i = index; i < queue.Count; i++) {
                queue[i].queueOffset = Random.Range(-queueVariation, queueVariation);
                queue[i].xOffset = Random.Range(-CustomerSpawner.spawnRange, CustomerSpawner.spawnRange);
            }
            
            UpdateQueue();
        }
    }

    private void UpdateQueue() {
        float offsetSum = 0f;

        foreach (var customer in queue) {
            float spacing = queueSpacing + customer.queueOffset;
            
            Vector3 position = queueStartPoint.position + (Vector3) (offsetSum * queueDirection.normalized);
            position.x = queueStartPoint.position.x + customer.xOffset;
            customer.MoveTo(position);
            
            offsetSum += spacing;
        }
    }
}
