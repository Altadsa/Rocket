using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Rocket : MonoBehaviour
    {

        public static int starsCollected = 0;

        [SerializeField]
        Event onRocketDestroyed;

        private static Rocket instance;
        public static Rocket Instance
        {
            get
            {
                if (!instance)
                {
                    instance = FindObjectOfType<Rocket>();
                }
                return instance;
            }
        }

        public void SetRocketSprite(Sprite spriteToSet)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = spriteToSet;
        }

        public void DestroyRocket()
        {
            gameObject.SetActive(false);
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
