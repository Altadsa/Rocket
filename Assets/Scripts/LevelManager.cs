using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        GameObject spawnAreaPrefab;

        [SerializeField]
        Event onGameStarted;

        const float MIN_TIME_TO_RESPAWN = 20.0f;
        const float MAX_TIME_TO_RESPAWN = 45.0f;

        public static float timeElapsed;
        float timeToRespawn = 30.0f;

        private void Update()
        {
            IncrementTimeAndCheckIfCanSpawnItems();
        }

        private void IncrementTimeAndCheckIfCanSpawnItems()
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > timeToRespawn)
            {
                SpawnArea.canSpawnItems = true;
                timeToRespawn = RandomizeRespawnTime();
            }
            else
            {
                SpawnArea.canSpawnItems = false;
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1;
        }

        public void StartNewGame()
        {
            Rocket.Instance.gameObject.SetActive(true);
            onGameStarted.Raise();
            GenerateFirstSpawnArea();
            timeElapsed = 0;
        }

        public void OnGameOver()
        {
            SpawnArea[] spawnAreas = FindObjectsOfType<SpawnArea>();
            if (spawnAreas != null)
            {
                foreach (SpawnArea spawnArea in spawnAreas)
                { GameObject.Destroy(spawnArea.gameObject); }
            }
        }

        private float RandomizeRespawnTime()
        {
            float newSpawnTime = Random.Range(MIN_TIME_TO_RESPAWN, MAX_TIME_TO_RESPAWN);
            return newSpawnTime;
        }

        private void GenerateFirstSpawnArea()
        {
            GameObject spawnArea = Instantiate(spawnAreaPrefab);
            spawnArea.transform.parent = GameObject.Find("Game").transform;
        }
    } 
}
