
namespace Tookuyam
{
    public class SelectMode : IConstructionMode
    {
        ConstructionSelectionUI selectionUI;

        public SelectMode(
            ConstructionSelectionUI selectionUI
        )
        {
            this.selectionUI = selectionUI;
        }

        public void Enter()
        {
            selectionUI.gameObject.SetActive(true);
        }

        public void Exit()
        {
            selectionUI.gameObject.SetActive(false);
        }
    }
}