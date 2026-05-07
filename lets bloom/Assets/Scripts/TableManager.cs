using System.Collections;
using UnityEngine;

public class TableManager : MonoBehaviour {
    
    [SerializeField] private ChairManager[] chairs = new ChairManager[2];
    [SerializeField] private TraitDatabase traitDatabase;
    private CustomerDraggable customerA;
    private CustomerDraggable customerB;
    
    private int numChairFilled = 0;

    public void FillChair() {
        numChairFilled++;
        if (IsFull()) {
            customerA = chairs[0].GetCustomer()?.GetComponent<CustomerDraggable>();
            customerB = chairs[1].GetCustomer()?.GetComponent<CustomerDraggable>();
            ClearUI();
            
            StartCoroutine(DateSequence());
        }
    }

    private IEnumerator DateSequence() {
        yield return new WaitForSeconds(2f); 
        
        CalculateScore();
        
        yield return new WaitForSeconds(2f);
        
        ResetTable();
    }

    private void CalculateScore() {
        if (customerA == null || customerB == null) return;
        
        int score = traitDatabase.GetScore(customerA.GetProfile(), customerB.GetProfile());
        GameManager.Instance.AddScore(score);
        Debug.Log(score);
        UpdateCustomerSprite(score);
    }

    private void UpdateCustomerSprite(int score) {
        if (score <= 5) {
            customerA.GetProfile().SetSad();
            customerB.GetProfile().SetSad();
        } else if (score >= 15) {
            customerA.GetProfile().SetHappy();
            customerB.GetProfile().SetHappy();
        }
        customerA.UpdateSprite();
        customerB.UpdateSprite();
    }

    private void ResetTable() {
        numChairFilled = 0;
        foreach (var chair in chairs) {
            chair.ClearSeat();
        }
        customerA = null;
        customerB = null;
    }

    private bool IsFull() {
        return numChairFilled >= 2;
    }

    private void ClearUI() {
        DragManager.Instance.ClearSelection();
        customerA?.Deselect();
        customerB?.Deselect();
    }
}
