using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    enum SpawnMode
    {
        Classic,
        Random,
        RandomEdges
    }
    [SerializeField] SpawnMode spawnMode;

    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float spawnRate;
    [SerializeField] float spawnDuration;
    
    [SerializeField] List<Vector2> spawnLocations;
    [SerializeField] [VectorLabels("minX", "maxX")] Vector2 sceneBoundsX;
    [SerializeField] [VectorLabels("minY", "maxY")] Vector2 sceneBoundsY;


    void Start()
    {
        switch (spawnMode)
        {
            case SpawnMode.Classic:
                StartCoroutine(classicSpawn());
                break;
            case SpawnMode.Random:
                StartCoroutine(randomSpawn());
                break;
            case SpawnMode.RandomEdges:
                StartCoroutine(randomEdgesSpawn());
                break;
        }
    }

    IEnumerator classicSpawn()
    {
        int i = 0;
        int listLength = spawnLocations.Count;
        
        while (i < listLength && (Time.time < spawnDuration || spawnDuration == 0))
        {
            Instantiate(objectToSpawn, spawnLocations[i], Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            i++;
        }
    }
    IEnumerator randomSpawn()
    {
        while (Time.time < spawnDuration || spawnDuration == 0)
        {
            Instantiate(objectToSpawn, randomSpawnLocation(), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
    IEnumerator randomEdgesSpawn()
    {
        while (Time.time < spawnDuration || spawnDuration == 0)
        {
            Instantiate(objectToSpawn, randomEdgesSpawnLocation(), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    Vector2 randomSpawnLocation()
    {
        return new Vector2(Random.Range(sceneBoundsX.x, sceneBoundsX.y), Random.Range(sceneBoundsY.x, sceneBoundsY.y));
    }

    Vector2 randomEdgesSpawnLocation()
    {
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: // left
                return new Vector2(sceneBoundsX.x, Random.Range(sceneBoundsY.x, sceneBoundsY.y));
            case 1: // right
                return new Vector2(sceneBoundsX.y, Random.Range(sceneBoundsY.x, sceneBoundsY.y));
            case 2: // up
                return new Vector2(Random.Range(sceneBoundsX.x, sceneBoundsX.y), sceneBoundsY.y);
            case 3: // down
                return new Vector2(Random.Range(sceneBoundsX.x, sceneBoundsX.y), sceneBoundsY.x);
        }
        return Vector2.zero;
    }
    
} 
