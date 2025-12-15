using UnityEngine;

namespace Tookuyam
{
    public class RendererBoundsCalculator
    {
        public static Bounds Calculate(GameObject gameObject)
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
            if (renderers.Length == 0)
                return default;
            Bounds firstBounds = renderers[0].bounds;
            Bounds bounds = new Bounds(firstBounds.center, firstBounds.size);
            foreach (Renderer renderer in renderers)
            {
                bounds.Encapsulate(renderer.bounds);
            }
            return bounds;
        }
    }
}
