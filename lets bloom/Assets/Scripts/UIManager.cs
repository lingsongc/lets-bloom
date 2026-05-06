using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour {
    
    private UIDocument uiDocument;
    
    private VisualElement root;
    
    private Image seatCard;
    private Label seatProfileDesc;
    private Label seatPreferDesc;
    
    private Image queueCard;
    private Label queueProfileDesc;
    private Label queuePreferDesc;

    private void Awake() {
        uiDocument = GetComponent<UIDocument>();
        
        root = uiDocument.rootVisualElement;
        
        seatCard = root.Q<Image>("SeatCard");
        seatProfileDesc = root.Q<Label>("SeatProfileDescription");
        seatPreferDesc = root.Q<Label>("SeatPreferDescription");
        
        queueCard = root.Q<Image>("QueueCard");
        queueProfileDesc = root.Q<Label>("QueueProfileDescription");
        queuePreferDesc = root.Q<Label>("QueuePreferDescription");
        
        HideAll();
    }

    public void HideAll() {
        seatCard.style.bottom = -425;
        queueCard.style.bottom = -425;
    }

    public void ShowSeat(CustomerProfile profile) {
        seatProfileDesc.text = profile.GetProfileDescription();
        seatPreferDesc.text = profile.GetPreferDescription();
        seatCard.style.bottom = -70;
    }
    
    public void ShowQueue(CustomerProfile profile) {
        queueProfileDesc.text = profile.GetProfileDescription();
        queuePreferDesc.text = profile.GetPreferDescription();
        queueCard.style.bottom = -70;
    }
}
