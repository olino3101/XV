

using UnityEngine;
using UnityEngine.InputSystem;

namespace Tookuyam
{
    [RequireComponent(typeof(PreviewCamera))]
    public class PreviewCameraControllerForPrefab : MonoBehaviour
    {
        [SerializeField] string previewLayerName;
        PreviewCamera previewCamera;
        GameObject nowPreviewObject;

        void OnEnable()
        {
            previewCamera = GetComponent<PreviewCamera>();
        }

        void Update()
        {
            previewCamera.zoom = previewCamera.zoom + Mouse.current.scroll.y.ReadValue();
        }

        public void SetTarget(GameObject prefab)
        {
            CleanTarget();
            nowPreviewObject = Instantiate(prefab);
            previewCamera.SetTarget(nowPreviewObject);
            int layer = LayerMask.NameToLayer(previewLayerName);
            if (layer == -1)
                return ;
            LayerSetter.SetRecursive(nowPreviewObject, layer);
        }

        public void CleanTarget()
        {
            if (nowPreviewObject != null)
            {
                Destroy(nowPreviewObject);
                nowPreviewObject = null;
            }
        }
    }
}