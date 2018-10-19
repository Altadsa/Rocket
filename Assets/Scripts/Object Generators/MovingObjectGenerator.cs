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
                if (Random.Range(0, 2) == 1)
                {
                    InstantiateGameObjectWithinArea();
                } 
            }
        }

        private void InstantiateGameObjectWithinArea()
        {
            randomColumnIndex = Random.Range(0, 5);
            randomRowIndex = Random.Range(0, 5);
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
            for (int i = 0; i < 5; i++)
            {
                spawnArea.MarkSpawnAreaPosition(randomColumnIndex, i);
            }
        }
    } 
}
