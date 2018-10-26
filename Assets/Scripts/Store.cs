using UnityEngine;
using UnityEngine.UI;

namespace Rocket
{
    public class Store : MonoBehaviour
    {
        [SerializeField]
        Text starsText;

        #region Singleton

        private static Store _CurrentStore;
        private static readonly object padlock = new object();

        public static Store CurrentStore
        {
            get
            {
                lock (padlock)
                {
                    if (!_CurrentStore)
                    {
                        _CurrentStore = FindObjectOfType<Store>();
                    }
                    return _CurrentStore;
                }
            }
        } 
        #endregion

        public void UpdateAvailableStars()
        {
            string starCount = PlayerPreferences.CurrentPlayerPreferences.GetStars().ToString();
            starsText.text = string.Format("Stars Availabe: {0}", starCount);
        }
    }
}
