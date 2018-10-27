using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class CollectableObjectGenerator : ObjectGenerator
    {
        [SerializeField]
        int spawnchance;

        protected override void Generate()
        {
            if (spawnArea.HasPlayerItem() || !objectToSpawn.GetComponent<Star>() && !SpawnArea.canSpawnItems) { return; }
            for (int i = 0; i < maxObjectsToGenerate; i++)
            {
                if (Random.Range(0, spawnchance) == 0)
                {
                    InstantiateGameObjectWithinArea();
                    if (!objectToSpawn.GetComponent<Star>())
                    {
                        LevelManager.timeElapsed = 0.0f;
                    }
                }
            }
        }

        protected override void InstantiateObject()
        {
            GameObject objectInstance = Instantiate(objectToSpawn, transform);
            objectInstance.transform.parent = gameObject.transform;
            objectInstance.transform.position = spawnArea.GetAreaSpawnPoints()[randomColumnIndex, randomRowIndex];
        }

        private void InstantiateGameObjectWithinArea()
        {
            randomColumnIndex = Random.Range(0, 7);
            randomRowIndex = Random.Range(0, 6);
            if (spawnArea.GetAreaSpawnPoints()[randomColumnIndex, randomRowIndex] != Vector2.zero)
            {
                InstantiateObject();
                spawnArea.MarkSpawnAreaPosition(randomColumnIndex, randomRowIndex);
            }
            else
            {
                InstantiateGameObjectWithinArea();
            }
        }

    } 
}
