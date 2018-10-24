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

        private static Store _CurrentStore;

        public static Store CurrentStore
        {
            get
            {
                if (!_CurrentStore)
                {
                    _CurrentStore = FindObjectOfType<Store>();
                }
                return _CurrentStore;
            }
        }

        public void UpdateAvailableStars()
        {
            int starCount = PlayerPreferences.CurrentPlayerPreferences.GetStars();
            starsText.text = "Stars Availabe: " + starCount.ToString();
        }
    }
}
