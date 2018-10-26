using UnityEngine;

namespace Rocket
{
    public class PlayerPreferences : MonoBehaviour
    {
        private static PlayerPreferences playerPreferences;
        public static PlayerPreferences CurrentPlayerPreferences
        {
            get
            {
                if (playerPreferences == null)
                {
                    playerPreferences = GameObject.FindObjectOfType<PlayerPreferences>();
                }
                return playerPreferences;
            }
        }

        private void OnRocketDeath()
        {
            AddStars(Rocket.starsCollected);
        }

        public int GetStars()
        {
            return PlayerPrefs.GetInt("Stars");
        }

        public void AddStars(int amountToAdd)
        {
            int total = PlayerPrefs.GetInt("Stars") + amountToAdd;
            PlayerPrefs.SetInt("Stars", total);
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt("High Score");
        }

        public void SetHighScore(int scoreToSet)
        {
            PlayerPrefs.SetInt("High Score", scoreToSet);
        }
    } 
}
