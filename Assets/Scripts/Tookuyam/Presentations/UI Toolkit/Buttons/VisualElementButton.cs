using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class VisualElementButton : MonoBehaviour
{
    public UnityEvent<ClickEvent> onClick = new();

    [SerializeField]
    private string buttonName;
    [SerializeField]
    private UIDocument uiDocument;
    private VisualElement buttonElement;


    void OnEnable()
    {
        buttonElement = uiDocument.rootVisualElement.Q<VisualElement>(buttonName);
        buttonElement.RegisterCallback<ClickEvent>(OnButtonClick);
    }

    void OnDisable()
    {
        if (buttonElement == null)
            return;
        buttonElement.UnregisterCallback<ClickEvent>(OnButtonClick);
    }

    void OnButtonClick(ClickEvent evt)
    {
        onClick?.Invoke(evt);
    }
}
