using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class SpawnArea : MonoBehaviour
    {
        [SerializeField]
        GameObject spawnAreaPrefab;

        [SerializeField]
        GameObject starPrefab;

        [SerializeField]
        GameObject itemPrefab;

        public float speed;

        int maxColumns = 5;
        int maxRows = 5;
        int maxObstaclesPerArea = 4;

        int randomColumnIndex, randomRowIndex;

        float xPadding = 1.0f;
        float yPadding = 2.0f;

        Vector2[,] spawnPoints;

        public Vector2[,] GetAreaSpawnPoints()
        {
            return spawnPoints;
        }

        public void MarkSpawnAreaPosition(int columnIndex, int rowIndex)
        {
            spawnPoints[columnIndex, rowIndex] = Vector2.zero;
        }

        private void Start()
        {
            DeleteDuplicateChildrenIfExists();
            spawnPoints = GenerateSpawnPoints();
            GenerateItems(starPrefab, 3);
            GenerateItems(itemPrefab, 20);
        }

        private void Update()
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        private void DeleteDuplicateChildrenIfExists()
        {
            if (transform.childCount > 0)
            {
                DestroyChildren();
            }
        }

        private void GenerateItems(GameObject itemToGenerate, int spawnProbability)
        {
            if (Random.Range(0, spawnProbability) == 0)
            {
                //InstantiateGameObjectWithinArea(itemToGenerate);
            }
        }

        private void GenerateObstacles(GameObject obstaclesToGenerate)
        {
            for (int i = 0; i < maxObstaclesPerArea; i++)
            {
                //InstantiateGameObjectWithinArea(obstaclesToGenerate);
            }
        }

        private void InstantiateObjectAndMarkPosition(GameObject objectToInstantiate)
        {
            GameObject objectInstance = Instantiate(objectToInstantiate, transform);
            objectInstance.transform.parent = gameObject.transform;
            objectInstance.transform.position = spawnPoints[randomColumnIndex, randomRowIndex];
            spawnPoints[randomColumnIndex, randomRowIndex] = Vector2.zero;
        }

        private Vector2[,] GenerateSpawnPoints()
        {
            Vector2[,] spawnPoints = new Vector2[maxColumns, maxRows];

            Bounds bounds = GetComponent<BoxCollider2D>().bounds;

            Vector2 startPos = new Vector2(bounds.min.x, bounds.max.y);
            Vector2 vectPos = new Vector2(startPos.x + xPadding, startPos.y - yPadding);

            for (int x = 0; x < maxColumns; x++)
            {
                for (int y = 0; y < maxRows; y++)
                {
                    spawnPoints[x, y] = vectPos;
                    Vector2 newVectPos = new Vector2(vectPos.x + xPadding, vectPos.y);
                    vectPos = newVectPos;
                }
                vectPos = new Vector2(startPos.x + xPadding, vectPos.y - yPadding);
            }

            return spawnPoints;
        }

        private void DestroyChildren()
        {
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Rocket rocketHealth = collision.GetComponent<Rocket>();

            if (rocketHealth)
            {
                InstantiateNewAreaAndSetPosition();
            }
        }

        private void InstantiateNewAreaAndSetPosition()
        {
            GameObject newSpawnArea = Instantiate(spawnAreaPrefab);
            newSpawnArea.transform.position = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Rocket rocketHealth = collision.GetComponent<Rocket>();

            if (rocketHealth)
            {
                DestroyChildren();
                Destroy(gameObject);
            }
        }
    }
}
