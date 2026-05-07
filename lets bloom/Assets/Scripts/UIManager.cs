using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour {
    
    public static UIManager Instance { get; private set; }
    
    private VisualElement root;
    
    private Label scoreText;
    
    private Image seatCard;
    private Label seatProfileDesc;
    private Label seatPreferDesc;
    
    private Image queueCard;
    private Label queueProfileDesc;
    private Label queuePreferDesc;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        scoreText = root.Q<Label>("ScoreLabel");
        
        seatCard = root.Q<Image>("SeatCard");
        seatProfileDesc = root.Q<Label>("SeatProfileDescription");
        seatPreferDesc = root.Q<Label>("SeatPreferDescription");
        
        queueCard = root.Q<Image>("QueueCard");
        queueProfileDesc = root.Q<Label>("QueueProfileDescription");
        queuePreferDesc = root.Q<Label>("QueuePreferDescription");
        
        HideAll();
    }

    public void UpdateScore(int score) {
        scoreText.text = "Score: " + score;
    }

    public void HideAll() {
        ToggleSeat(false);
        ToggleQueue(false);
    }
    
    public void ToggleSeat(bool state) {
        Debug.Log("off");
        if (state) {
            seatCard.style.bottom = -70;
        } else {
            seatCard.style.bottom = -425;
        }
    }
    
    public void ToggleQueue(bool state) {
        if (state) {
            queueCard.style.bottom = -70;
        } else {
            queueCard.style.bottom = -425;
        }
    }

    public void ShowSeat(CustomerProfile profile) {
        seatProfileDesc.text = profile.GetProfileDescription();
        seatPreferDesc.text = profile.GetPreferDescription();
        ToggleSeat(true);
    }
    
    public void ShowQueue(CustomerProfile profile) {
        queueProfileDesc.text = profile.GetProfileDescription();
        queuePreferDesc.text = profile.GetPreferDescription();
        ToggleQueue(true);
    }

    public void SwapToSeat(CustomerProfile profile) {
        ShowSeat(profile);
        ToggleQueue(false);
    }
}
