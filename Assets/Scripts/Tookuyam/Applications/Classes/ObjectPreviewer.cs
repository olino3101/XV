

using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

namespace Tookuyam
{
    public class ObjectPreviewer
    {
        private float _distance;
        public float distance
        {
            get => _distance;
            set
            {
                _distance = value;
                Update();
            }
        }

        private Camera camera;
        private UniversalAdditionalCameraData urpCamera;
        private Bounds targetBounds;
        private GameObject targetObject;

        public ObjectPreviewer(Camera urpCamera)
        {
            camera = urpCamera;
            this.urpCamera = urpCamera.GetUniversalAdditionalCameraData();
            this.urpCamera.renderType = CameraRenderType.Base;
            camera.clearFlags = CameraClearFlags.SolidColor;
        }

        public void SetTargetTexture(RenderTexture renderTexture)
        {
            camera.targetTexture = renderTexture;
        }

        public void SetBackgroundColor(Color backgroundColor)
        {
            camera.backgroundColor = backgroundColor;
        }

        public void SetTargetObject(GameObject obj)
        {
            if (obj == null)
                return ;
            targetObject = obj;
            targetBounds = RendererBoundsCalculator.Calculate(obj);
        }

        public void SetLayer(int layer)
        {
            if (layer == -1)
                return ;
            camera.cullingMask = 1 << layer;
        }

        public void Focus()
        {
            if (targetBounds == null || targetObject == null || camera == null)
                return ;
            camera.transform.position = targetBounds.center + (targetObject.transform.forward * -distance);
            camera.transform.LookAt(targetBounds.center);
        }

        public void Update()
        {
            Focus();
        }
    }
}