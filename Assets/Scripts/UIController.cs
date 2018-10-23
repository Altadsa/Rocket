using UnityEngine;
using UnityEngine.UI;

namespace Rocket
{
    public class UIController : MonoBehaviour
    {

        [SerializeField]
        Text ammoText;

        [SerializeField]
        Text starsText;

        Rocket rocket;

        private void OnEnable()
        {
            rocket = FindObjectOfType<Rocket>();
        }

        private void Update()
        {
            if (rocket)
            {
                if (rocket.GetComponentInChildren<LaserCannon>())
                {
                    ammoText.transform.parent.gameObject.SetActive(true);
                    ammoText.text = ": " + rocket.GetComponentInChildren<LaserCannon>().GetAmmo();
                }
                else
                {
                    ammoText.transform.parent.gameObject.SetActive(false);
                }
                starsText.text = ": " + Rocket.starsCollected;
            }
        }

    } 
}
