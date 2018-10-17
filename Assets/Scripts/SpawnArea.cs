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
        GameObject obstaclePrefab;

        int maxColumns = 3;
        int maxRows = 5;

        private void Start()
        {
            DeleteDuplicateChildrenIfExists();
            GenerateObstacles(obstaclePrefab);
        }

        private void DeleteDuplicateChildrenIfExists()
        {
            if (transform.childCount > 0)
            {
                DestroyChildren();
            }
        }

        private void GenerateObstacles(GameObject obstaclesToGenerate)
        {
            Vector2[,] spawnPoints = GenerateSpawnPoints();
            for (int i = 0; i < 3; i++)
            {
                GameObject obstacleInstance = Instantiate(obstaclePrefab, transform);
                obstacleInstance.transform.parent = gameObject.transform;
                obstacleInstance.transform.position = spawnPoints[Random.Range(0, maxColumns), Random.Range(0, maxRows)];
            }
        }

        private Vector2[,] GenerateSpawnPoints()
        {

            Vector2[,] spawnPoints = new Vector2[maxColumns, maxRows];
            float xPadding = 1.0f;
            float yPadding = 2.0f;

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
                    Debug.Log(newVectPos);
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
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();

            if (rocketHealth)
            {
                GameObject newSpawnArea = Instantiate(spawnAreaPrefab);
                SpawnArea spawnArea = newSpawnArea.GetComponent<SpawnArea>();
                newSpawnArea.transform.position = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();

            if (rocketHealth)
            {
                DestroyChildren();
                Destroy(gameObject);
            }
        }
    }
}
