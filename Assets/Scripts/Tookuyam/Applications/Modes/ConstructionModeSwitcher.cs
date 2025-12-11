

using System.Collections.Generic;
using UnityEngine;

namespace Tookuyam
{
    public class ConstructionModeSwitcher
    {
        IConstructionMode currentMode;
        EConstructionModes nextMode;
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

        public async Awaitable ChangeModeAtNextFrame(EConstructionModes mode)
        {
            if (nextMode != EConstructionModes.None)
                return ;
            nextMode = mode;
            await HideNextFrame();
            nextMode = EConstructionModes.None;
        }

        async Awaitable HideNextFrame()
        {
            await Awaitable.NextFrameAsync();
            ChangeMode(nextMode);
        }

        public void Exit()
        {
            currentMode?.Exit();
            currentMode = null;
        }
    }
}