using UnityEngine;
using UnityEngine.UI;

namespace Rocket
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]
        Text score;

        [SerializeField]
        PlayerPreferences playerPreferences;

        private void Start()
        {
            score.text = "Score: " + playerPreferences.GetScoreThisGame();
        }
    } 
}
