using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomerDraggable : MonoBehaviour {
    
    private Camera mainCamera;
    
    private bool isDragging = false;
    
    // For Drag and Drop
    private Vector3 offset;
    private Vector2 origin;
    private Vector2 pointerPosition;
    
    // For Snapping
    private Transform snapTarget;
    private GameObject chair;

    private void Start() {
        mainCamera = Camera.main;
        origin = transform.position;
    }

    private void Update() {
        if (isDragging) {
            transform.position = GetWorldPosition() + offset;
        }
    }

    // Retrieve the coords of Pointer
    private Vector3 GetWorldPosition() {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(pointerPosition);
        worldPos.z = 0f;
        return worldPos;
    }

    private void OnPoint(InputValue value) {
        pointerPosition = value.Get<Vector2>();
    }

    private void OnClick(InputValue value) {
        if (value.isPressed) {
            StartDrag();
        } else {
            StopDrag();
        }
    }

    private void StartDrag() {
        Vector3 worldPosition = GetWorldPosition();

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject) {
            isDragging = true;
            offset = transform.position - worldPosition;
        }
    }
    
    private void StopDrag() {
        isDragging = false;

        if (snapTarget != null) {
            transform.position = snapTarget.position;
            chair = snapTarget.gameObject;
        } else {
            transform.position = origin;
            chair = null;
        }
        
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
}
