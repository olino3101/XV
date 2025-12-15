using Tookuyam;
using UnityEngine;

public class BoundsVisualizer : MonoBehaviour
{
    [SerializeField] private BoundsBox target;

    void OnEnable()
    {
        target?.SetVisibility(true);
    }

    void OnDisable()
    {
        if (target)
            target.SetVisibility(false);
    }

    public void ChangeTarget(BoundsBox target)
    {
        if (this.target)
            this.target.SetVisibility(false);
        this.target = target;
        if (this.target)
            this.target.SetVisibility(true);
    }
}
