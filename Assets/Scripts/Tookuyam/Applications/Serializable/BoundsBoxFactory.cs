
using UnityEngine;

namespace Tookuyam
{
    [System.Serializable]
    public class BoundsBoxFactory
    {
        [SerializeField] Material boundsMaterial;
        [SerializeField] string layerName;

        public BoundsBox AddComponent(GameObject target)
        {
            BoundsBox bb = target.AddComponent<BoundsBox>();
            bb.target = target;
            bb.boundsMaterial = boundsMaterial;
            bb.layerName = layerName;
            return bb;
        }
    }
}