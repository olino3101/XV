

using UnityEngine;
using UnityEngine.InputSystem;

namespace Tookuyam
{
    [RequireComponent(typeof(PreviewCamera))]
    public class PreviewCameraControllerForPrefab : MonoBehaviour
    {
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
            if (nowPreviewObject != null)
                Destroy(nowPreviewObject);
            nowPreviewObject = Instantiate(prefab);
            previewCamera.SetTarget(nowPreviewObject);
        }
    }
}