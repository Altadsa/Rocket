using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class PlayerPreferences : MonoBehaviour
    {

        public int GetStars()
        {
            return PlayerPrefs.GetInt("Stars");
        }

        public void AddStars(int amountToAdd)
        {
            int total = PlayerPrefs.GetInt("Stars") + amountToAdd;
            PlayerPrefs.SetInt("Stars", total);
        }

        public int GetScoreThisGame()
        {
            return PlayerPrefs.GetInt("Score");
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt("High Score");
        }

        public void SetScoreThisGame(int scoreToSet)
        {
            PlayerPrefs.SetInt("Score", scoreToSet);
        }

        public void SetHighScore(int scoreToSet)
        {
            PlayerPrefs.SetInt("High Score", scoreToSet);
        }
    } 
}
