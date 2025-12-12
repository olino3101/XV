using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Tookuyam
{
    [RequireComponent(typeof(UniversalAdditionalCameraData))]
    public class PreviewCamera : MonoBehaviour
    {
        [SerializeField] RenderTexture targetTexture;
        [SerializeField] GameObject targetObject;
        [SerializeField] Color backgroundColor;
        [SerializeField] string previewLayer;
        [SerializeField][Range(0f, 10f)] float _zoom = 5f;
        public float zoom
        {
            get => _zoom;
            set => _zoom = Mathf.Clamp(value, 0f, 10f);
        }

        ObjectPreviewer objectPreviewer;

        void Update()
        {
            if (targetObject)
                FocusTargetObject();
        }

        void OnEnable()
        {
            var cam = GetComponent<Camera>();
            if (cam == null)
                return ;
            objectPreviewer = new (cam);
            objectPreviewer.SetTargetTexture(targetTexture);
            objectPreviewer.SetBackgroundColor(backgroundColor);
            objectPreviewer.SetTargetObject(targetObject);
        }

        public void SetTarget(GameObject gameObject)
        {
            targetObject = gameObject;
            objectPreviewer.SetTargetObject(targetObject);
        }

        private void FocusTargetObject()
        {
            if (objectPreviewer == null)
                return;
            float distance = 10f - zoom;
            objectPreviewer.distance = distance;
        }
    }
}
