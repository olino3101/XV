using System.Collections;
using System.Collections.Generic;
using Tookuyam;
using UnityEngine;
using UnityEngine.UIElements;

namespace Tookuyam
{
    public class ConstructionModeFacade : MonoBehaviour
    {
        public ConstructionSelectionUI selectionUI;
        public BoundsVisualizer boundsVisualizer;
        public BoundsBoxSelector boundsSelector;
        public PreviewCameraControllerForPrefab previewCameraController;
        [SerializeField]
        private XVObjectFactoroy xvObjectFactory;

        ConstructionModeSwitcher modeSwitcher;

        void OnEnable()
        {
            InitializeModeSwitcher();
        }

        void InitializeModeSwitcher()
        {
            Dictionary<EConstructionModes, IConstructionMode> modes = new()
            {
                {EConstructionModes.Select, InitializeSelectMode()},
                {EConstructionModes.Edit, InitializeEditMode()},
                {EConstructionModes.Existing, InitializeExistingMode()},                
            };
            modeSwitcher = new ConstructionModeSwitcher(modes);
        }

        SelectMode InitializeSelectMode()
        {
            List<ModePolicyRecord> selectModePolicies = new List<ModePolicyRecord>
            {
                new ModePolicyRecord(() => {
                    selectionUI.gameObject.SetActive(true);
                },() =>
                {
                    selectionUI.gameObject.SetActive(false);
                }),
                new ModePolicyRecord(() => {},
                () =>
                {
                    previewCameraController.CleanTarget();
                })
            };
            return new SelectMode(selectModePolicies);
        }

        EditMode InitializeEditMode()
        {
            List<ModePolicyRecord> editModePolicies = new List<ModePolicyRecord>
            {
                new ModePolicyRecord(() =>
                {
                    boundsVisualizer.gameObject.SetActive(true);
                    boundsSelector.gameObject.SetActive(true);
                }, () =>
                {
                    boundsVisualizer.gameObject.SetActive(false);
                    boundsSelector.gameObject.SetActive(false);
                })
            };

            return new EditMode(editModePolicies);
        }

        ExistingMode InitializeExistingMode()
        {
            List<ModePolicyRecord> existingModePolicies = new List<ModePolicyRecord>
            {
                new ModePolicyRecord(() => {
                    boundsSelector.gameObject.SetActive(true);
                }, () =>
                {
                    boundsSelector.gameObject.SetActive(false);
                })
            };
            return new ExistingMode(existingModePolicies);
        }

        public void OnEditButtonClick(ClickEvent evt)
        {
            ChangeExistingModeNextFrame();
        }

        public void OnClickConstructionButton(ClickEvent evt)
        {
            ChangeSelectModeNextFrame();
        }

        public void OnObjectChosen(GameObject gameObject)
        {
            GameObject go = xvObjectFactory.Instantiate(gameObject);
            ChangeEditModeNextFrame(go);
        }

        public void OnClickBoundsBox(RaycastHit hitinfo)
        {
            Transform parent = hitinfo.collider.gameObject.transform.parent;
            if (parent == null)
                return;
            ChangeEditModeNextFrame(parent.gameObject);
        }

        public void Exit()
        {
            modeSwitcher.Exit();
        }

        private void ChangeSelectModeNextFrame()
        {
            ChangeModeNextFrame(EConstructionModes.Select);
        }

        private void ChangeEditModeNextFrame(GameObject gameObject)
        {
            SetEditObject(gameObject);
            ChangeModeNextFrame(EConstructionModes.Edit);
        }

        private void ChangeExistingModeNextFrame()
        {
            ChangeModeNextFrame(EConstructionModes.Existing);
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
