using UnityEngine;
using UnityEngine.UI;

namespace Rocket
{
    public class Store : MonoBehaviour
    {
        [SerializeField]
        Text starsText;

        [SerializeField]
        PlayerPreferences playerPreferences;

        // Use this for initialization
        void Start()
        {
            int starCount = playerPreferences.GetStars();
            starsText.text = "Stars Availabe: " + starCount.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
