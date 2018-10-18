using UnityEngine;

namespace Rocket
{
    [System.Serializable]
    public class LaserCannon : MonoBehaviour
    {
        [SerializeField]
        GameObject projectilePrefab;

        const int AMMO_PER_ROUND = 10;

        private int ammo = 10;

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

                Instantiate(projectilePrefab).transform.position = gameObject.transform.position;
                UpdateAmmo();
            }
        }

        private void UpdateAmmo()
        {
            ammo--;
            if (ammo == 0)
            {
                Destroy(gameObject);
            }
        }

        public void AddAmmo()
        {
            ammo += AMMO_PER_ROUND;
        }
    }
}
