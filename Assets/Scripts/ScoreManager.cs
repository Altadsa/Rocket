using UnityEngine;
using UnityEngine.UI;

namespace Rocket
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        Text scoreText;

        float score;

        int multiplier = 100;

        // Use this for initialization
        void Start()
        {
            score = 0;
        }

        // Update is called once per frame
        void Update()
        {
            score += multiplier * Time.deltaTime;
            scoreText.text = Mathf.RoundToInt(score).ToString();
            Debug.Log(score);
        }
    } 
}
