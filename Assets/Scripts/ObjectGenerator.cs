using UnityEngine;

namespace Rocket
{
    [RequireComponent(typeof(SpawnArea))]
    public abstract class ObjectGenerator : MonoBehaviour
    {
        [SerializeField] protected
        GameObject objectToSpawn;

        //TODO Change to int const.
        [SerializeField] protected
        int maxObjectsToGenerate;

        protected SpawnArea spawnArea;

        protected int randomColumnIndex, randomRowIndex;

        protected void Start()
        {
            spawnArea = gameObject.GetComponent<SpawnArea>();
            GenerateIfSpawnPointsExist();
        }

        private void GenerateIfSpawnPointsExist()
        {
            if (spawnArea.GetAreaSpawnPoints() != null)
            {
                Generate();
            }
        }

        protected abstract void InstantiateObject();

        protected abstract void Generate();

    } 
}
