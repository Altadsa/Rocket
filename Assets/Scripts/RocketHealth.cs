using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class RocketHealth : MonoBehaviour
    {
        [SerializeField]
        PlayerPreferences playerPreferences;

        [SerializeField]
        LevelManager levelManager;

        int starsCollected = 0;

        public void DestroyRocket()
        {
            Destroy(gameObject);
            playerPreferences.AddStars(starsCollected);
            starsCollected = 0;
            levelManager.LoadLevel("Menu");
        }

        public void AddStar()
        {
            starsCollected++;
        }

    } 
}
