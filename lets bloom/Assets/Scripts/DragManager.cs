using UnityEngine;
using UnityEngine.InputSystem;

public class DragManager : MonoBehaviour {
    
    private Camera mainCamera;
    private CustomerDraggable current;
    private Vector2 pointerPosition;
    private bool isDragging;
    
    [SerializeField] private UIManager uiManager;
    
    private void Start() {
        mainCamera = Camera.main;
    }
    
    private void Update() {
        if (current != null) {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(pointerPosition);
            worldPosition.z = 0f;

            current.Drag(worldPosition);
        }
    }
    
    private void OnPoint(InputValue value) {
        pointerPosition = value.Get<Vector2>();
    }

    private void OnClick(InputValue value) {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(pointerPosition);
        worldPosition.z = 0f;

        if (value.isPressed) {
            Select(worldPosition);
            StartDrag(worldPosition);
        } else {
            StopDrag();
        }
    }
    
    // Check if grabbing onto a Customer and Drag it
    private void StartDrag(Vector3 worldPosition) {
        if (current != null) return;

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null) {
            CustomerDraggable draggable = hit.collider.GetComponent<CustomerDraggable>();

            if (draggable != null && draggable.CanDrag()) {
                current = draggable;
                current.StartDrag(worldPosition);
            }
        }
    }
    
    private void StopDrag() {
        if (current != null) {
            current.StopDrag();
            current = null;
        }
    }

    private void Select(Vector3 worldPosition) {
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        CustomerDraggable customer = null;
        
        if (hit.collider != null) customer = hit.collider.GetComponent<CustomerDraggable>();

        if (customer != null) {
            if (customer.IsSeating()) {
                uiManager.ShowSeat(customer.GetProfile());
            } else {
                uiManager.ShowQueue(customer.GetProfile());
            }
        } else {
            uiManager.HideAll();
        }
    }
}
