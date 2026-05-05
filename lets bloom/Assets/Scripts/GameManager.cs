using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance {get; private set;}
    private int totalScore = 0;
    
    [SerializeField] private UIDocument uiDocument;
    private Label scoreText;
    
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    private void Start() {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    }

    public void AddScore(int score) {
        totalScore += score;
        scoreText.text = "Score: " + totalScore;
    }
}
