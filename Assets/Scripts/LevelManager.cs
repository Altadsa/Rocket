using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{
    public class LevelManager : MonoBehaviour
    {
        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1;
        }

        public void LoadLevel(string name)
        {
            SceneManager.LoadScene(name);
        }

    } 
}
