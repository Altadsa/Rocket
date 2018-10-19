using UnityEngine;
using UnityEngine.UI;

namespace Rocket
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]
        Text scoreText;

        [SerializeField]
        Text highScoreText;

        [SerializeField]
        PlayerPreferences playerPreferences;

        private void Start()
        {
            scoreText.text = "Score: " + playerPreferences.GetScoreThisGame();
            SetHighScore();
        }

        private void SetHighScore()
        {
            int scoreThisGame = playerPreferences.GetScoreThisGame();
            int highScore = playerPreferences.GetHighScore();

            if (highScore < scoreThisGame)
            {
                playerPreferences.SetHighScore(scoreThisGame);
            }
            highScoreText.text = "HS: " + playerPreferences.GetHighScore();
        }
    } 
}
