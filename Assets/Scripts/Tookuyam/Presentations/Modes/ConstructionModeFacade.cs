using Tookuyam;
using UnityEngine;

namespace Tookuyam
{
    public class ConstructionModeFacade : MonoBehaviour
    {
        public ConstructionSelectionUI selectionUI;
        public BoundsVisualizer boundsVisualizer;

        ConstructionModeSwitcher modeSwitcher;

        void OnEnable()
        {
            SelectMode selectMode = new(
                selectionUI
            );
            EditMode editMode = new(
                boundsVisualizer
            );
            ExistingMode existingMode = new();

            modeSwitcher = new ConstructionModeSwitcher(
                selectMode,
                editMode,
                existingMode
            );
        }

        public void SetEditObject(GameObject gameObject)
        {
            BoundsBox bb = gameObject.GetComponent<BoundsBox>();
            boundsVisualizer.ChangeTarget(bb);
        }

        public void ChangeMode(EConstructionModes mode)
        {
            modeSwitcher.ChangeMode(mode);
        }

        public void Exit()
        {
            modeSwitcher.Exit();
        }
    }
}
