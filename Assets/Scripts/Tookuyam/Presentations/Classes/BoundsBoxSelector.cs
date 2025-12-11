
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tookuyam
{
    public class BoundsBoxSelector : MonoBehaviour
    {
        [SerializeField] private ConstructionModeFacade modeFacade;

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
            int boundsBoxLayer = LayerMask.NameToLayer("BoundsBox");
            if (ClickRayCast(out hit, 100f, 1 << boundsBoxLayer))
            {
                Transform parent = hit.collider.transform.parent;
                if (parent)
                {
                    modeFacade.ChangeEditMode(parent.gameObject);
                    return;
                }
            }
            else
            {
                modeFacade.Exit();
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