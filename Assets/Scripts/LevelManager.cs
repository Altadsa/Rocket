﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        StringConstant mainMenuName;

        private void Start()
        {
            Rocket rocket = GameObject.FindObjectOfType<Rocket>();
            if (rocket)
            {
                rocket.onRocketDeath += LoadLevelOnRocketDeath; 
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

        public void LoadLevel(StringConstant levelName)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(levelName.Value());
        }

        public void LoadLevelOnRocketDeath()
        {
            LoadLevel(mainMenuName);
        }

    } 
}
