using UnityEngine;
using UnityEngine.UIElements;

public class FooterMenuUI : MonoBehaviour
{
    [SerializeField]
    private UIDocument constructionUIDocument;

    public void OnClickConstructionButton(ClickEvent evt)
    {
        constructionUIDocument.gameObject.SetActive(true);
    }
}
