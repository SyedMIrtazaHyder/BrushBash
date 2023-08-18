using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] placeholderPrefabs; // Array of placeholder objects to spawn
    [SerializeField] private Material[] placeholderMaterials; // Array of placeholder materials to apply to enemy
    private Vector3 spawnPoint; // The point from which the objects will be spawned
    [SerializeField] private float spawnInterval; // Time interval between spawning objects
    [SerializeField] private MeshRenderer spawnMesh;
    [SerializeField] private float divisor = 1f;
    [SerializeField] private float enemySpeed = 1f;
    private float spawnTimer; // Timer to keep track of when to spawn the next object

    void Start()
    {
        // Start the timer
        StartCoroutine(WaitForPlacement());
        spawnTimer = spawnInterval;
    }

    private IEnumerator WaitForPlacement()
    {
        yield return new WaitUntil(() => transform.localScale.x < 100);//may work only for mobile games
        Debug.Log("Placement Complete");
        spawnPoint = transform.position;//transform.localScale
        spawnMesh = GetComponent<MeshRenderer>();
        //spawnPoint.z = transform.position.z;

    }
    void Update()
    {
        // Decrease the timer every frame
        spawnTimer -= Time.deltaTime;
        // Check if it's time to spawn a new object
        if (spawnTimer <= 0)
        {
            // Reset the timer
            spawnTimer = spawnInterval;

            // Spawn a random placeholder object from the array
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        if (placeholderPrefabs.Length == 0)
        {
            Debug.LogWarning("No placeholder prefabs assigned!");
            return;
        }

        // Randomly select a placeholder prefab from the array
        int randomIndex = UnityEngine.Random.Range(0, placeholderPrefabs.Length);
        GameObject prefabToSpawn = placeholderPrefabs[randomIndex];

        int randomMatIndex = UnityEngine.Random.Range(0, placeholderMaterials.Length);
        Material MaterialToAdjust = placeholderMaterials[randomMatIndex];

        //Getting a random location in bounds to spawn enemy
        Vector3 spawnPosition = spawnPoint;
        spawnPosition.x = UnityEngine.Random.Range(spawnMesh.bounds.min.x, spawnMesh.bounds.max.x);
        // Spawn the selected prefab at the specified spawn point
        GameObject spawn = Instantiate(prefabToSpawn, spawnPosition, transform.rotation);
        spawn.GetComponent<ConstantForce>().force *= enemySpeed;
        Renderer[] children = spawn.GetComponentsInChildren<Renderer>();
        //Debug.Log("Position: " + spawnPosition.ToString() + " when x is ");
        foreach (Renderer mr in children)
            mr.material = MaterialToAdjust;

        Vector3 originalScale = prefabToSpawn.transform.localScale;
        spawn.transform.localScale = new Vector3(   transform.localScale.x * originalScale.x / divisor,
                                                    transform.localScale.x * originalScale.y / divisor,
                                                    transform.localScale.x * originalScale.z / divisor);
    }
}
