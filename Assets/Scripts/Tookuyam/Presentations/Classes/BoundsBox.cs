using UnityEngine;

namespace Tookuyam
{
    public class BoundsBox : MonoBehaviour
    {
        Material _boundsMaterial;
        public Material boundsMaterial
        {
            get => _boundsMaterial;
            set {
                _boundsMaterial = value;
                ApplyMaterial();
            }
        }

        GameObject _target;
        public GameObject target
        {
            get => _target;
            set
            {
                if (_target == value)
                    return ;
                _target = value;
                Rebuild();
            }
        }

        string _layerName = "Default";
        public string layerName
        {
            get => _layerName;
            set
            {
                _layerName = value;
                ApplyLayer();
            }
        }

        GameObject cube;

        public void SetVisibility(bool visible)
        {
            if (cube == null)
                return;
            var renderer = cube.GetComponent<Renderer>();
            if (renderer)
                renderer.enabled = visible;
        }

        void ApplyLayer()
        {
            if (cube == null)
                return ;
            int layer = LayerMask.NameToLayer(_layerName);
            if (layer == -1)
                return ;
            cube.layer = layer;
        }

        void ApplyMaterial()
        {
            if (cube == null)
                return ;
            var renderer = cube.GetComponent<Renderer>();
            if (renderer)
                renderer.sharedMaterial = _boundsMaterial;
        }

        void Rebuild()
        {
            if (cube)
            {
                Destroy(cube.gameObject);
                cube = null;
            }
            if (_target == null)
                return;
            Bounds bounds = RendererBoundsCalculator.Calculate(_target);
            bounds.Expand(0.1f);
            cube = new BoundsCubeBuilder()
                .WithLayer(_layerName)
                .WithCollider()
                .WithBounds(bounds)
                .WithMaterial(_boundsMaterial)
                .Build();
            cube.transform.SetParent(_target.transform);
        }
    }
}
