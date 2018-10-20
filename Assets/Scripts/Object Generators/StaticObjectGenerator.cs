using UnityEngine;

namespace Rocket
{
    public class StaticObjectGenerator : ObjectGenerator
    {
        [SerializeField]
        float minScale;

        [SerializeField]
        float maxScale;

        protected override void Generate()
        {
            for (int i = 0; i < maxObjectsToGenerate; i++)
            {
                InstantiateGameObjectWithinArea();
            }
        }

        protected override void InstantiateObject()
        {
            GameObject objectInstance = Instantiate(objectToSpawn, transform);
            objectInstance.transform.parent = gameObject.transform;
            objectInstance.transform.position = spawnArea.GetAreaSpawnPoints()[randomColumnIndex, randomRowIndex];
            objectInstance.transform.localScale = RandomizeScale();
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

        private Vector2 RandomizeScale()
        {
            float randomScaleValue = Random.Range(minScale, maxScale);
            return new Vector3(randomScaleValue, randomScaleValue, 1.0f);
        }

    }
}
