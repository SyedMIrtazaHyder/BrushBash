using System;
using System.Collections;
using UnityEngine;

public class SpawnerAndWallPlacer : MonoBehaviour
{
    [SerializeField] MeshRenderer terrainMesh;
    [SerializeField] bool isLeft = false;
    [SerializeField] bool isTop = false;
    [SerializeField] bool isWall = false;
    [SerializeField] float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSize());
        //local scale to keep walls of same scale
        //transform.localScale = new Vector3(terrainMesh.transform.localScale.x * multiplier, transform.localScale.y, terrainMesh.transform.localScale.z * multiplier);
    }

    private IEnumerator WaitForSize()
    {
        yield return new WaitUntil(() => terrainMesh.transform.localScale.z < 100);
        Debug.Log("Terrain Rescaled :)");

        Bounds terrainBounds = terrainMesh.bounds;

        if (isWall)
        {
            if (isLeft)
                transform.position = new Vector3(terrainBounds.min.x - transform.localScale.x/2, terrainBounds.center.y, terrainBounds.center.z);
            else
                transform.position = new Vector3(terrainBounds.max.x + transform.localScale.x/2, terrainBounds.center.y, terrainBounds.center.z);
            transform.localScale = new Vector3(terrainMesh.transform.localScale.x, transform.localScale.y, terrainMesh.transform.localScale.z * multiplier);
        }
        // Calculate positions for top and bottom edges
        else
        {
            if (isTop)
                transform.position = new Vector3(terrainBounds.center.x, terrainBounds.center.y, terrainBounds.max.z + transform.localScale.z / 2);
            else
                transform.position = new Vector3(terrainBounds.center.x, terrainBounds.center.y, terrainBounds.min.z - transform.localScale.z / 2);
            transform.localScale = new Vector3(terrainMesh.transform.localScale.x * multiplier, transform.localScale.y, terrainMesh.transform.localScale.z);
        }
    }
}
