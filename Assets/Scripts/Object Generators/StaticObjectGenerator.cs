using UnityEngine;

namespace Rocket
{
    public class StaticObjectGenerator : ObjectGenerator
    { 
        protected override void Generate()
        {
            for (int i = 0; i < maxObjectsToGenerate; i++)
            {
                InstantiateGameObjectWithinArea();
            }
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
