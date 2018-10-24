using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        StringConstant gameOverName;

        private void Start()
        {
            EventSystem.Current.RegisterListener(EVENT_TYPE.ROCKET_DESTROYED, LoadLevelOnRocketDeath);
        }

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
            Time.timeScale = 1;
            SceneManager.LoadScene(levelName.Value);
        }

        public void LoadLevelOnRocketDeath()
        {
            LoadLevel(gameOverName);
        }

    } 
}
