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

        public void OnRocketDestroyed()
        {
            SetScoreText();
            SetHighScore();
        }

        private void SetScoreText()
        {
            int score = (int)ScoreManager.Instance.score;
            string scoreString = score.ToString();
            scoreText.text = string.Format("Score: {0}", scoreString);
        }

        private void SetHighScore()
        {
            int scoreThisGame = (int)ScoreManager.Instance.score;
            int highScore = playerPreferences.GetHighScore();

            if (highScore < scoreThisGame)
            {
                playerPreferences.SetHighScore(scoreThisGame);
            }
            highScoreText.text = "HS: " + playerPreferences.GetHighScore();
        }
    } 
}
