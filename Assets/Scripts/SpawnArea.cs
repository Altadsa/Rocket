using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class SpawnArea : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField]
        GameObject spawnAreaPrefab;

        [SerializeField]
        Vector2Constant paddingConstant;

        [SerializeField]
        IntConstant maxColumns;

        [SerializeField]
        IntConstant maxRows;

        public float speed;

        Vector2 padding;

        Vector2[,] spawnPoints; 

        #endregion

        #region UNITY LIFECYCLE

        private void Start()
        {
            padding = paddingConstant.Value();
            gameObject.name = "Spawn Area";
            DeleteDuplicateChildrenIfExists();
            spawnPoints = GenerateSpawnPoints();
        }

        private void Update()
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Rocket rocketHealth = collision.GetComponent<Rocket>();
            if (rocketHealth)
            {
                InstantiateNewAreaAndSetPosition();
            }
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

        #endregion

        #region PUBLIC FUNCTIONS

        public Vector2[,] GetAreaSpawnPoints()
        {
            return spawnPoints;
        }

        public void MarkSpawnAreaPosition(int columnIndex, int rowIndex)
        {
            spawnPoints[columnIndex, rowIndex] = Vector2.zero;
        }

        public bool HasPlayerItem()
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<Item>())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region PRIVATE FUNCTIONS

        private void DeleteDuplicateChildrenIfExists()
        {
            if (transform.childCount > 0)
            {
                DestroyChildren();
            }
        }

        private Vector2[,] GenerateSpawnPoints()
        {
            Vector2[,] spawnPoints = new Vector2[maxColumns.Value(), maxRows.Value()];

            Bounds bounds = GetComponent<BoxCollider2D>().bounds;

            Vector2 startPos = new Vector2(bounds.min.x, bounds.max.y);
            Vector2 vectPos = new Vector2(startPos.x + padding.x, startPos.y - padding.y);

            for (int x = 0; x < maxColumns.Value(); x++)
            {
                for (int y = 0; y < maxRows.Value(); y++)
                {
                    spawnPoints[x, y] = vectPos;
                    Vector2 newVectPos = new Vector2(vectPos.x + padding.x, vectPos.y);
                    vectPos = newVectPos;
                }
                vectPos = new Vector2(startPos.x + padding.x, vectPos.y - padding.y);
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

        private void InstantiateNewAreaAndSetPosition()
        {
            GameObject newSpawnArea = Instantiate(spawnAreaPrefab);
            newSpawnArea.transform.position = new Vector3(transform.position.x, transform.position.y + 14.0f, transform.position.z);
        }

        #endregion
    }
}
