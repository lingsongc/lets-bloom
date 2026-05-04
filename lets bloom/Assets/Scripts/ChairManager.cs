using UnityEngine;

public class ChairManager : MonoBehaviour {
    private bool isOccupied = false;
    private GameObject customer;
    
    [SerializeField] private TableManager tableManager;

    public bool IsOccupied() {
        return isOccupied;
    }

    public void Seat(GameObject other) {
        customer = other;
        isOccupied = true;
        
        tableManager.FillChair();
    }

    public void ClearSeat() {
        customer = null;
        isOccupied = false;
    }

    public GameObject GetCustomer() {
        return customer;
    }
}
