using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    private void OnEnable()
    {
        var uiDoc = GetComponent<UIDocument>();

        VisualElement root = uiDoc.rootVisualElement;

        Button optionsTabButton = root.Q<Button>("OptionsTabButton");

        optionsTabButton.clicked += OnOptionsTabButtonClicked;
    }

    private void OnOptionsTabButtonClicked()
    {
        Debug.Log("Button clicked!");
        
    }
}
