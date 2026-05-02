using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour {
    
    [SerializeField] private int queueMaxSize = 5;
    [SerializeField] private Vector2 queueDirection = Vector2.up;
    [SerializeField] private float queueSpacing = 1.5f;
    [SerializeField] private Transform queueStartPoint;
    
    private List<CustomerDraggable> queue = new List<CustomerDraggable>();
    
    public bool IsFull() {
        return queue.Count >= queueMaxSize;
    }

    public void Enqueue(CustomerDraggable customer) {
        if (IsFull()) return;
        
        queue.Add(customer);
    }

    public void Dequeue(CustomerDraggable customer) {
        if (queue.Remove(customer)) {
            
        }
    }

    private void UpdateQueue() {
        for (int i = 0; i < queue.Count; i++) {
            Vector3 position = queueStartPoint.position + (Vector3) (queueDirection.normalized * queueSpacing * i);
            queue[i].MoveTo(position);
        }
    }
    
}
