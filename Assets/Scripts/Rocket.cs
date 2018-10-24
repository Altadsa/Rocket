using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Rocket : MonoBehaviour
    {

        public static int starsCollected = 0;
        public static Sprite rocketSprite;

        [SerializeField]
        Event onRocketDestroyed;

        private void Start()
        {
            if (rocketSprite)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = rocketSprite;
            }
        }

        public void DestroyRocket()
        {
            Destroy(gameObject);
            starsCollected = 0;
            onRocketDestroyed.Raise();
        }

        public void AddItem(GameObject itemToAdd)
        {
            HandleLaserCannonItem(itemToAdd);
        }

        private void HandleLaserCannonItem(GameObject itemToAdd)
        {         
            if (CanRocketEquipItem(itemToAdd))
            {
                GameObject itemInstance = Instantiate(itemToAdd);
                itemInstance.transform.parent = transform;  
            }
            else
            {
                GetComponentInChildren<LaserCannon>().AddAmmo();
            }
        }

        private bool CanRocketEquipItem(GameObject itemToAdd)
        {
            if (!GetComponentInChildren<LaserCannon>()
                      || itemToAdd.GetComponent<EDT>()
                      || itemToAdd.GetComponent<TDD>())
            {
                return true;
            }
            return false;
        }

        public void AddStar()
        {
            starsCollected++;
        }

    } 
}
