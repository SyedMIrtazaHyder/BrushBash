using System.Collections;
using UnityEngine;

public class BrushScale : MonoBehaviour
{
    [SerializeField] MeshRenderer terrainMesh; // Reference to the object whose size will determine the resizing
    [SerializeField] private float divisor;
    private void Start()
    {
        StartCoroutine(ResizeToReferenceSize());
    }

    private IEnumerator ResizeToReferenceSize()
    {
        yield return new WaitUntil(() => terrainMesh.transform.localScale.x > 1);
        if (terrainMesh != null)
        {
            // Get the size of the reference object's renderer bounds
            Bounds referenceBounds = terrainMesh.bounds;
            Debug.Log("Reference Object Available");

            // Resize this object's local scale to match the reference object's size
            transform.localScale = new Vector3(referenceBounds.size.x * transform.localScale.x / divisor, referenceBounds.size.x * transform.localScale.y / divisor, referenceBounds.size.x * transform.localScale.z / divisor);
            Debug.Log(transform.localScale.ToString());
        }
        else
        {
            Debug.LogWarning("Reference object is not assigned.");
        }
    }
}
