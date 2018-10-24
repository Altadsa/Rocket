﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        StringConstant gameOverName;

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

        public void OnRocketDeath()
        {
            LoadLevel(gameOverName);
        }

    } 
}
