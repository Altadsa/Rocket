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
        }

        public void OnRocketDestroyed()
        {
            SpawnArea[] spawnAreas = FindObjectsOfType<SpawnArea>();
            if (spawnAreas != null)
            {
                foreach (SpawnArea spawnArea in spawnAreas)
                { GameObject.Destroy(spawnArea.gameObject); }
            }
        }

        private void GenerateFirstSpawnArea()
        {
            GameObject spawnArea = Instantiate(spawnAreaPrefab);
            spawnArea.transform.parent = GameObject.Find("Game").transform;
        }
    } 
}
