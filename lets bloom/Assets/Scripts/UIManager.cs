using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour {
    
    private UIDocument uiDocument;
    
    private VisualElement root;
    private Image card;
    private Label profileDesc;
    private Label preferDesc;

    private void Awake() {
        uiDocument = GetComponent<UIDocument>();
        
        root = uiDocument.rootVisualElement;
        
        card = root.Q<Image>("SeatCard");
        profileDesc = root.Q<Label>("ProfileDescription");
        preferDesc = root.Q<Label>("PreferDescription");
        
        Hide();
    }

    public void Hide() {
        card.style.bottom = -425;
    }

    public void Show(CustomerProfile profile) {
        profileDesc.text = profile.GetProfileDescription();
        preferDesc.text = profile.GetPreferDescription();
        card.style.bottom = -70;
    }
}
