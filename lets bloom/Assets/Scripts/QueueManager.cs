using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class QueueManager : MonoBehaviour {
    
    [SerializeField] private int queueMaxSize = 5;
    [SerializeField] private float queueSpacing = 1.5f;
    [SerializeField] private Transform queueStartPoint;
    
    private Vector2 queueDirection = Vector2.down;
    
    private List<CustomerDraggable> queue = new List<CustomerDraggable>();
    
    public bool IsFull() {
        return queue.Count >= queueMaxSize;
    }

    public void Enqueue(CustomerDraggable customer) {
        if (IsFull()) return;
        
        queue.Add(customer);
        UpdateQueue();
    }

    public void Dequeue(CustomerDraggable customer) {
        if (queue.Remove(customer)) {
            UpdateQueue();
        }
    }

    private void UpdateQueue() {
        for (int i = 0; i < queue.Count; i++) {
            Vector3 position = queueStartPoint.position + (Vector3) (queueSpacing * i * queueDirection.normalized);
            queue[i].MoveTo(position);
            Debug.Log("Queue index " + i + " position: " + position);
        }
    }
    
}
