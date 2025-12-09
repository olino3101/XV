using Tookuyam;
using UnityEngine;

namespace Tookuyam
{
    public class ConstructionModeFacade : MonoBehaviour
    {
        public ConstructionSelectionUI selectionUI;

        ConstructionModeSwitcher modeSwitcher;

        void OnEnable()
        {
            SelectMode selectMode = new(
                selectionUI
            );
            EditMode editMode = new();
            ExistingMode existingMode = new();

            modeSwitcher = new ConstructionModeSwitcher(
                selectMode,
                editMode,
                existingMode
            );
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
