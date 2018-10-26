using UnityEngine;
using UnityEngine.UI;

namespace Rocket
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        Text scoreText;

        public float score;

        int multiplier = 100;

        #region Singleton
        private static ScoreManager instance;
        private static readonly object padlock = new object();
        public static ScoreManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (!instance)
                    {
                        instance = FindObjectOfType<ScoreManager>();
                    }
                    return instance; 
                }
            }
        } 
        #endregion

        // Use this for initialization
        public void OnGameStarted()
        {
            score = 0;
        }

        // Update is called once per frame
        void Update()
        {
            score += multiplier * Time.deltaTime;
            scoreText.text = Mathf.RoundToInt(score).ToString();
        }
    } 
}
