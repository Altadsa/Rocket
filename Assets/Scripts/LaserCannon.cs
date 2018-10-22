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

        private float timer = 0.0f;

        private float reloadTime = 0.1f;

        // Update is called once per frame
        void Update()
        {
            Rocket rocket = gameObject.GetComponentInParent<Rocket>();
            if (!rocket) { return; }
            timer += Time.deltaTime;
            transform.position = rocket.transform.position;
            FireCannon();
        }

        private void FireCannon()
        {
            if (Input.GetKeyDown(KeyCode.J) || Input.touchCount > 0)
            {
                InstantiateProjectileAndUpdate();
            }
        }

        private void InstantiateProjectileAndUpdate()
        {
            if (timer >= reloadTime)
            {
                Instantiate(projectilePrefab).transform.position = gameObject.transform.position;
                UpdateAmmo();
                timer = 0.0f;
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

        public int GetAmmo()
        {
            return ammo;
        }
    }
}
