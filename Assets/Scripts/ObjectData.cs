using UnityEngine;

public class ObjectData : MonoBehaviour
{
    [SerializeField] private Material material;

    public void SetName(string newName)
    {
        gameObject.name = newName;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void SetMaterial(Material newMaterial)
    {
        material = newMaterial;

        var renderer = GetComponent<Renderer>();
        if (renderer != null)
            renderer.material = material;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
