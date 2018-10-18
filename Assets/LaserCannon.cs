using UnityEngine;

namespace Rocket
{
    [System.Serializable]
    public class LaserCannon : MonoBehaviour
    {
        [SerializeField]
        GameObject projectilePrefab;

        int ammo = 10;

        // Update is called once per frame
        void Update()
        {
            Rocket rocket = gameObject.GetComponentInParent<Rocket>();
            if (!rocket) { return; }

            transform.position = rocket.transform.position;
            FireCannon();
        }

        private void FireCannon()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (ammo > 0)
                {
                    Instantiate(projectilePrefab).transform.position = gameObject.transform.position;
                    ammo--;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    } 
}
