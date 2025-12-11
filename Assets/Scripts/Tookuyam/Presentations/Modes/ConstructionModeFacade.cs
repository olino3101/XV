using System.Collections;
using Tookuyam;
using UnityEngine;

namespace Tookuyam
{
    public class ConstructionModeFacade : MonoBehaviour
    {
        public ConstructionSelectionUI selectionUI;
        public BoundsVisualizer boundsVisualizer;
        public BoundsBoxSelector boundsSelector;

        ConstructionModeSwitcher modeSwitcher;
        EConstructionModes nextMode = EConstructionModes.None;

        void OnEnable()
        {
            SelectMode selectMode = new(
                () => 
                {
                    selectionUI.gameObject.SetActive(true);
                },
                () => {
                    selectionUI.gameObject.SetActive(false);
                }
            );
            EditMode editMode = new(
                () =>
                {
                    boundsVisualizer.gameObject.SetActive(true);
                    boundsSelector.gameObject.SetActive(true);
                },
                () =>
                {
                    boundsVisualizer.gameObject.SetActive(false);
                    boundsSelector.gameObject.SetActive(false);
                }
            );
            ExistingMode existingMode = new(() => {}, () => {});

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

        public async Awaitable ChangeMode(EConstructionModes mode)
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
            modeSwitcher.ChangeMode(nextMode);
        }

        public void ChangeEditMode(GameObject gameObject)
        {
            SetEditObject(gameObject);
            _ = ChangeMode(EConstructionModes.Edit);
        }

        public void Exit()
        {
            modeSwitcher.Exit();
        }
    }
}
