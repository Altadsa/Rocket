using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{
    public class LevelManager : MonoBehaviour
    {
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
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
            onGameStarted.Raise();
        }

        public void StartGame()
        {
            Rocket.Instance.gameObject.SetActive(true);
            onGameStarted.Raise();
        }
    } 
}
