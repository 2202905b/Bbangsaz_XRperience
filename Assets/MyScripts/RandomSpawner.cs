using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to instantiate
    public Transform[] spawnPoints; // Array of spawn points (e.g., Int1, Int2, Int3, ..., Int12)

    private List<GameObject> spawnedPrefabs = new List<GameObject>(); // List to keep track of spawned prefabs

    void Start()
    {
        if (spawnPoints.Length < 2)
        {
            Debug.LogError("Please assign at least 2 spawn points.");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Clear the list of spawned prefabs
            foreach (var spawnedPrefab in spawnedPrefabs)
            {
                if (spawnedPrefab != null)
                {
                    Destroy(spawnedPrefab);
                }
            }
            spawnedPrefabs.Clear();

            // Create a list of available indices
            List<int> indices = new List<int>();
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                indices.Add(i);
            }

            // Select 2 unique random indices
            int index1 = indices[Random.Range(0, indices.Count)];
            indices.Remove(index1);//Prevent reselection of index
            int index2 = indices[Random.Range(0, indices.Count)];
            indices.Remove(index2);//Prevent reselection of index
            int index3 = indices[Random.Range(0, indices.Count)];
            indices.Remove(index3);//Prevent reselection of index
            int index4 = indices[Random.Range(0, indices.Count)];
            indices.Remove(index4);//Prevent reselection of index
            int index5 = indices[Random.Range(0, indices.Count)];

            // Instantiate prefabs at the selected spawn points
            spawnedPrefabs.Add(Instantiate(prefabToSpawn, spawnPoints[index1].position, Quaternion.identity));
            spawnedPrefabs.Add(Instantiate(prefabToSpawn, spawnPoints[index2].position, Quaternion.identity));
            spawnedPrefabs.Add(Instantiate(prefabToSpawn, spawnPoints[index3].position, Quaternion.identity));
            spawnedPrefabs.Add(Instantiate(prefabToSpawn, spawnPoints[index4].position, Quaternion.identity));
            spawnedPrefabs.Add(Instantiate(prefabToSpawn, spawnPoints[index5].position, Quaternion.identity));

            // Wait for 0.3 seconds
            yield return new WaitForSeconds(2f);
        }
    }
}
