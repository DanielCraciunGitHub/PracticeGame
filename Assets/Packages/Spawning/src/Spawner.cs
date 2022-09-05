using System.Collections;
using System.Collections.Generic;
using Packages.Spawning.VectorPropertyDrawer;
using UnityEngine;

namespace Packages.Spawning.src
{
    public class Spawner : MonoBehaviour
    {
        private enum SpawnMode
        {
            Classic,
            Random,
            RandomEdges
        }
        [SerializeField] private SpawnMode spawnMode;

        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] private float spawnRate;
        [SerializeField] private float spawnDuration;
    
        [SerializeField] private List<Vector2> spawnLocations;
        [SerializeField] [VectorLabels("minX", "maxX")]
        private Vector2 sceneBoundsX;
        [SerializeField] [VectorLabels("minY", "maxY")]
        private Vector2 sceneBoundsY;


        private void Start()
        {
            switch (spawnMode)
            {
                case SpawnMode.Classic:
                    StartCoroutine(ClassicSpawn());
                    break;
                case SpawnMode.Random:
                    StartCoroutine(RandomSpawn());
                    break;
                case SpawnMode.RandomEdges:
                    StartCoroutine(RandomEdgesSpawn());
                    break;
            }
        }

        private IEnumerator ClassicSpawn()
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

        private IEnumerator RandomSpawn()
        {
            while (Time.time < spawnDuration || spawnDuration == 0)
            {
                Instantiate(objectToSpawn, RandomSpawnLocation(), Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private IEnumerator RandomEdgesSpawn()
        {
            while (Time.time < spawnDuration || spawnDuration == 0)
            {
                Instantiate(objectToSpawn, RandomEdgesSpawnLocation(), Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private Vector2 RandomSpawnLocation()
        {
            return new Vector2(Random.Range(sceneBoundsX.x, sceneBoundsX.y), Random.Range(sceneBoundsY.x, sceneBoundsY.y));
        }

        private Vector2 RandomEdgesSpawnLocation()
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
} 
