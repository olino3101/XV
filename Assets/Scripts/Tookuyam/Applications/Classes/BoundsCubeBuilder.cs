using UnityEngine;

namespace Tookuyam
{
    public class BoundsCubeBuilder
    {
        private int layer;
        private bool hasCollider = false;
        private Bounds bounds = new(Vector3.zero, Vector3.one);
        private Material material;

        public BoundsCubeBuilder WithLayer(string layerName)
        {
            if (layerName == null)
                return this;
            layer = LayerMask.NameToLayer(layerName);
            return this;
        }

        public BoundsCubeBuilder WithCollider(bool enable = true)
        {
            hasCollider = enable;
            return this;
        }

        public BoundsCubeBuilder WithBounds(Bounds bounds)
        {
            this.bounds = bounds;
            return this;
        }

        public BoundsCubeBuilder WithMaterial(Material material)
        {
            this.material = material;
            return this;
        }

        public GameObject Build()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var renderer = go.GetComponent<Renderer>();
            var collider = go.GetComponent<Collider>();

            go.transform.position = bounds.center;
            go.transform.localScale = bounds.size;
            if (hasCollider)
            {
                collider.isTrigger = true;
            }
            else
            {
                Object.Destroy(go.GetComponent<Collider>());
            }
            if (layer != -1)
                go.layer = layer;
            if (material != null)
                renderer.material = material;
            return go;
        }
    }
}
