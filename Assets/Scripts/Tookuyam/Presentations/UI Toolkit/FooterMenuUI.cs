using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Tookuyam
{
    public class FooterMenuUI : MonoBehaviour
    {
        [SerializeField] UnityEvent<ClickEvent> onClickConstructionButton;

        public void OnClickConstructionButton(ClickEvent evt)
        {
            onClickConstructionButton.Invoke(evt);
        }
    }
}
