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

        void OnEnable()
        {
            SelectMode selectMode = new(
                () =>
                {
                    selectionUI.gameObject.SetActive(true);
                },
                () =>
                {
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
            ExistingMode existingMode = new(() =>
                {
                    boundsSelector.gameObject.SetActive(true);
                },
                () =>
                {
                    boundsSelector.gameObject.SetActive(false);
                });

            modeSwitcher = new ConstructionModeSwitcher(
                selectMode,
                editMode,
                existingMode
            );
        }

        public void ChangeSelectModeNextFrame()
        {
            ChangeModeNextFrame(EConstructionModes.Select);
        }

        public void ChangeEditModeNextFrame(GameObject gameObject)
        {
            SetEditObject(gameObject);
            ChangeModeNextFrame(EConstructionModes.Edit);
        }

        public void ChangeExistingModeNextFrame()
        {
            ChangeModeNextFrame(EConstructionModes.Existing);
        }

        public void Exit()
        {
            modeSwitcher.Exit();
        }

        private void SetEditObject(GameObject gameObject)
        {
            BoundsBox bb = gameObject.GetComponent<BoundsBox>();
            boundsVisualizer.ChangeTarget(bb);
        }

        private void ChangeModeNextFrame(EConstructionModes mode)
        {
            _ = modeSwitcher.ChangeModeAtNextFrame(mode);
        }
    }
}
