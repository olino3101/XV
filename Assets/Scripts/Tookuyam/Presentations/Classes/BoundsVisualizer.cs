using Tookuyam;
using UnityEngine;

public class BoundsVisualizer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Material boundsMaterial;
    private GameObject cube;

    void Start()
    {
        AddBounds();
    }

    void OnEnable()
    {
        AddBounds();
    }

    void OnDisable()
    {
        Destroy(cube);
        cube = null;
    }

    public void ChangeTarget(Transform target)
    {
        this.target = target;
        OnDisable();
        AddBounds();
    }

    void AddBounds()
    {
        if (cube != null || target == null)
            return ;
        Bounds bounds = RendererBoundsCalculator.Calculate(target.gameObject);
        bounds.Expand(0.1f);
        cube = new BoundsCubeBuilder()
            .WithBounds(bounds)
            .WithMaterial(boundsMaterial)
            .Build();
        cube.transform.SetParent(target);
    }
}
