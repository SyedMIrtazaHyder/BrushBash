using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] placeholderPrefabs; // Array of placeholder objects to spawn
    private Vector3 spawnPoint; // The point from which the objects will be spawned
    [SerializeField] GameObject Spawner;
    [SerializeField] private float spawnInterval; // Time interval between spawning objects
    [SerializeField] private MeshRenderer spawnMesh;
    private float spawnTimer; // Timer to keep track of when to spawn the next object

    void Start()
    {
        // Start the timer
        spawnTimer = spawnInterval;
        spawnPoint = spawnMesh.bounds.size;
        spawnPoint.z = Spawner.transform.position.z;
        //Debug.Log(spawnMesh.bounds.size.ToString());//spawnMesh.bounds.size.ToString()
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

        //Getting a random location in bounds to spawn enemy
        Vector3 spawnPosition = spawnPoint;
        spawnPosition.x = UnityEngine.Random.Range(-spawnPoint.x / 2, spawnPoint.x / 2);
        // Spawn the selected prefab at the specified spawn point
        Instantiate(prefabToSpawn, spawnPosition, gameObject.transform.rotation);
    }
}
