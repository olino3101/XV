

using UnityEngine;

namespace Tookuyam
{
    public static class LayerSetter
    {
        static public void SetRecursive(GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
                SetRecursive(child.gameObject, layer);
        }
    }
}