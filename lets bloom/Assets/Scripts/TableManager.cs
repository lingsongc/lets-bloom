using System.Collections;
using UnityEngine;

public class TableManager : MonoBehaviour {
    
    [SerializeField] private ChairManager[] chairs = new ChairManager[2];
    [SerializeField] private TraitDatabase traitDatabase;
    
    private int numChairFilled = 0;

    public void FillChair() {
        numChairFilled++;
        if (numChairFilled == 2) {
            CalculateScore();
            StartCoroutine(DateDelay());
        }
    }

    public void CalculateScore() {
        CustomerDraggable customerA = chairs[0].GetCustomer()?.GetComponent<CustomerDraggable>();
        CustomerDraggable customerB = chairs[1].GetCustomer()?.GetComponent<CustomerDraggable>();

        if (customerA == null || customerB == null) return;
        
        int score = traitDatabase.GetScore(customerA.GetProfile(), customerB.GetProfile());
        GameManager.Instance.AddScore(score);
        Debug.Log(score);
    }

    private IEnumerator DateDelay() {
        yield return new WaitForSeconds(2f);
        ResetTable();
    }

    private void ResetTable() {
        foreach (var chair in chairs) {
            chair.ClearSeat();
        }
    }
}
