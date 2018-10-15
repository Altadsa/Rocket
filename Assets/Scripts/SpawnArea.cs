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

        private void Start()
        {
            GenerateObstacles(obstaclePrefab);
        }

        private void GenerateObstacles(GameObject obstaclesToGenerate)
        {
            Vector2[,] spawnPoints = GenerateSpawnPoints();
            for (int i = 0; i < 3; i++)
            {
                GameObject obstacleInstance = Instantiate(obstaclePrefab);
                obstacleInstance.transform.parent = gameObject.transform;
                obstacleInstance.transform.position = spawnPoints[Random.Range(0, 2), Random.Range(0, 4)];
            }
        }

        private Vector2[,] GenerateSpawnPoints()
        {
            Vector2[,] spawnPoints = new Vector2[3,5];
            float xPadding = 1.0f;
            float yPadding = 2.0f;
            Vector2 startPos = GetComponent<BoxCollider2D>().bounds.max;
            Vector2 vectPos = startPos;

            vectPos = vectPos - new Vector2(xPadding, yPadding);
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    spawnPoints[x, y] = vectPos;
                    Vector2 newVectPos = new Vector2(vectPos.x - xPadding, vectPos.y);
                    vectPos = newVectPos;
                }
                vectPos = new Vector2(startPos.x, vectPos.y - yPadding);
            }

            return spawnPoints;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();

            if (rocketHealth)
            {
                Instantiate(spawnAreaPrefab).transform.position = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
            }

            Debug.Log("Spawning a new Spawn Area..");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();

            if (rocketHealth)
            {
                Debug.Log("Destroying Myself");
                Destroy(gameObject);
            }
        }
    } 
}
