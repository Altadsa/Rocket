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

        public void LoadLevel(StringConstant levelName)
        {
            SceneManager.LoadScene(levelName.Value());
        }

    } 
}
