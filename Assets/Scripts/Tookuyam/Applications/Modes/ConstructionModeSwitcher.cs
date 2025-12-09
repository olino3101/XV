

using System.Collections.Generic;

namespace Tookuyam
{
    public class ConstructionModeSwitcher
    {
        IConstructionMode currentMode;
        Dictionary<EConstructionModes, IConstructionMode> modes = new();

        public ConstructionModeSwitcher(
            SelectMode selectMode,
            EditMode editMode,
            ExistingMode existingMode
        )
        {
            modes[EConstructionModes.Select] = selectMode;
            modes[EConstructionModes.Edit] = editMode;
            modes[EConstructionModes.Existing] = existingMode;
        }

        public void ChangeMode(EConstructionModes mode)
        {
            if (currentMode != null)
                currentMode.Exit();
            currentMode = modes[mode];
            currentMode.Enter();
        }

        public void Exit()
        {
            currentMode?.Exit();
            currentMode = null;
        }
    }
}