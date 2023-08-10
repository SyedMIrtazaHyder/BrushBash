using System;
using UnityEngine;

public class SpawnerAndWallPlacer : MonoBehaviour
{
    [SerializeField] MeshRenderer terrainMesh;
    [SerializeField] bool vertical = false;
    [SerializeField] bool isTop = false;
    [SerializeField] float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        //local scale to keep walls of same scale
        //transform.localScale = new Vector3(terrainMesh.transform.localScale.x * multiplier, transform.localScale.y, terrainMesh.transform.localScale.z * multiplier);
        Bounds terrainBounds = terrainMesh.bounds;

        // Calculate positions for top and bottom edges
        if (isTop)
            transform.position = new Vector3(terrainBounds.center.x, terrainBounds.center.y, terrainBounds.max.z);
        else
            transform.position = new Vector3(terrainBounds.center.x, terrainBounds.center.y, terrainBounds.min.z);
        transform.localScale = new Vector3(terrainMesh.transform.localScale.x * multiplier, transform.localScale.y, terrainMesh.transform.localScale.z);
    }

}
