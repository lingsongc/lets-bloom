using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomerDraggable : MonoBehaviour {
    
    // For Drag and Drop
    private bool isDragging = false;
    private bool isLocked = false;
    
    private Vector3 dragOffset;
    
    private Vector2 origin;
    
    // For Snapping
    [SerializeField] private float chairOffset = 0.7f;
    private Transform snapTarget;
    private GameObject chair;
    
    // For Queue
    private QueueManager queueManager;
    private bool isMovingToQueue = false;
    private Vector3 targetPosition;

    private void Start() {
        origin = transform.position;
    }

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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Chair")) {
            snapTarget = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Chair")) {
            snapTarget = other.transform;
        }
    }

    private void SnapToChair() {
        if (snapTarget != null) {
            
            ChairManager slot = snapTarget.GetComponent<ChairManager>();
            
            Debug.Log(slot != null && !slot.IsOccupied());
            
            if (slot != null && !slot.IsOccupied()) {
                Vector3 snapPosition = snapTarget.position;
                snapPosition.y += chairOffset;
                
                transform.position = snapPosition;
                
                chair = snapTarget.gameObject;
                slot.Seat(gameObject);
                
                isLocked = true;

                if (queueManager != null) {
                    queueManager.Dequeue(this);
                }
                
                return;
            }
        }
        transform.position = origin;
        chair = null;
    }

    public void SetQueueManager(QueueManager manager) {
        queueManager = manager;
    }

    public void MoveTo(Vector3 position) {
        targetPosition = position;
        isMovingToQueue = true;
    }
}
