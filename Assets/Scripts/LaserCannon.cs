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

        #region UNITY LIFECYCLE

        private void Start()
        {
            Rocket rocketInstance = Rocket.Instance;
            if (rocketInstance)
            {
                if (rocketInstance.GetActiveSprite() != Rocket.Instance.GetDefaultSprite())
                {
                    GetComponentInChildren<SpriteRenderer>().enabled = false;
                }
            }
        }

        void Update()
        {
            Rocket rocket = gameObject.GetComponentInParent<Rocket>();
            if (!rocket) { return; }
            timer += Time.deltaTime;
            transform.position = rocket.transform.position;
            FireCannon();
        } 

        #endregion

        #region PUBLIC FUNCTIONS

        public void AddAmmo()
        {
            ammo += AMMO_PER_ROUND;
        }

        public int GetAmmo()
        {
            return ammo;
        }

        #endregion

        #region PRIVATE FUNCTIONS

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

        #endregion


    }
}
