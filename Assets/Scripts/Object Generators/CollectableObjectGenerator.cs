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
            for (int i = 0; i < maxObjectsToGenerate; i++)
            {
                if (Random.Range(0, spawnchance) == 1)
                {
                    InstantiateGameObjectWithinArea();
                }
            }
        }

        private void InstantiateGameObjectWithinArea()
        {
            randomColumnIndex = Random.Range(0, 7);
            randomRowIndex = Random.Range(0, 5);
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
