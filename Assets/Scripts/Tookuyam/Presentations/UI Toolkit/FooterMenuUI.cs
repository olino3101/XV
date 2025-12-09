using UnityEngine;
using UnityEngine.UIElements;

namespace Tookuyam
{
    public class FooterMenuUI : MonoBehaviour
    {
        [SerializeField]
        private ConstructionModeFacade modeFacade;

        public void OnClickConstructionButton(ClickEvent evt)
        {
            modeFacade.ChangeMode(EConstructionModes.Select);
        }
    }
}
