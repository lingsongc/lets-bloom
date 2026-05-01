using UnityEngine;

public class ChairManager : MonoBehaviour {
    private bool isOccupied = false;
    private GameObject customer;

    public bool IsOccupied() {
        return isOccupied;
    }

    public void Seat(GameObject other) {
        customer = other;
        isOccupied = true;
    }
}
