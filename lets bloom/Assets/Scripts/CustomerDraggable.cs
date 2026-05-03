using System.Collections.Generic;
using UnityEngine;

public class CustomerDraggable : MonoBehaviour {
    
    // For Drag and Drop
    private bool isDragging = false;
    private bool isLocked = false;
    private Vector3 dragOffset;
    
    // For Snapping
    [SerializeField] private float chairOffset = 0.7f;
    private Transform snapTarget;
    
    // For Queue
    private QueueManager queueManager;
    private bool isMovingToQueue = false;
    private Vector3 targetPosition;
    public float queueOffset;
    public float xOffset;
    
    // For Profile
    private CustomerProfile profile;

    private void Update() {
        if (isMovingToQueue && !isDragging) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.05f) {
                isMovingToQueue = false;
            }
        }
    }

    public void Drag(Vector3 worldPos) {
        if (!isDragging) return;

        transform.position = worldPos + dragOffset;
    }

    public bool CanDrag() {
        return !isLocked && !isMovingToQueue;
    }
    
    public void StartDrag(Vector3 worldPosition) {
        if (isLocked) return;

        isDragging = true;
        dragOffset = transform.position - worldPosition;
    }
    
    public void StopDrag() {
        isDragging = false;
        SnapToChair();
    }
    
    // Reference the Chair when hovering over it
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Chair")) {
            snapTarget = other.transform;
        }
    }
    
    // Dereference the Chair when hovering over it
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Chair")) {
            snapTarget = null;
        }
    }

    private void SnapToChair() {
        if (snapTarget != null) {
            
            ChairManager chair = snapTarget.GetComponent<ChairManager>();
            
            if (chair != null && !chair.IsOccupied()) {
                Vector3 snapPosition = snapTarget.position;
                snapPosition.y += chairOffset;
                
                transform.position = snapPosition;
                
                chair.Seat(gameObject);
                
                isLocked = true;

                if (queueManager != null) {
                    queueManager.Dequeue(this);
                }
                
                return;
            }
        }
        transform.position = targetPosition;
    }

    public void SetQueueManager(QueueManager manager) {
        queueManager = manager;
    }

    public void MoveTo(Vector3 position) {
        targetPosition = position;
        isMovingToQueue = true;
    }

    public void SetProfile(CustomerProfile customerProfile) {
        profile = customerProfile;
    }
}
