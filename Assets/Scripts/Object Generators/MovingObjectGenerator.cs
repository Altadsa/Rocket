using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class MovingObjectGenerator : ObjectGenerator
    {
        [SerializeField]
        int spawnChance;

        protected override void Generate()
        {
            for (int i = 0; i < maxObjectsToGenerate; i++)
            {
                if (Random.Range(0, spawnChance) == 1)
                {
                    InstantiateGameObjectWithinArea();
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
                MarkRowWithinSpawnArea();
            }
            else
            {
                InstantiateGameObjectWithinArea();
            }
        }

        private void MarkRowWithinSpawnArea()
        {
            for (int i = 0; i < 6; i++)
            {
                spawnArea.MarkSpawnAreaPosition(randomColumnIndex, i);
            }
        }
    } 
}
