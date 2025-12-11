
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Tookuyam
{
    public class BoundsBoxSelector : MonoBehaviour
    {
        [SerializeField] UnityEvent<RaycastHit> onClickEditableBoundsBox;
        [SerializeField] UnityEvent onClickOtherArea;

        void Update()
        {
            Mouse current = Mouse.current;
            if (current.leftButton.wasPressedThisFrame)
            {
                ChangeModeWithClickPoint();
            }
        }

        void ChangeModeWithClickPoint()
        {
            RaycastHit hit;
            int boundsBoxLayer = LayerMask.NameToLayer("EditableBoundsBox");
            if (ClickRayCast(out hit, 100f, 1 << boundsBoxLayer))
            {
                onClickEditableBoundsBox.Invoke(hit);
            }
            else
            {
                onClickOtherArea.Invoke();
            }
        }

        static bool ClickRayCast(out RaycastHit hitInfo,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers)
        {
            Mouse current = Mouse.current;
            Ray ray = Camera.main.ScreenPointToRay(current.position.ReadValue());
            return Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);
        }
    }
}