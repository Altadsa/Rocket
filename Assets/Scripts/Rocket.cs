using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField]
        PlayerPreferences playerPreferences;

        [SerializeField]
        LevelManager levelManager;

        [SerializeField]
        StringConstant mainMenuName;

        int starsCollected = 0;

        public void DestroyRocket()
        {
            Destroy(gameObject);
            playerPreferences.AddStars(starsCollected);
            starsCollected = 0;
            playerPreferences.SetScoreThisGame((int)ScoreManager.score);
            levelManager.LoadLevel(mainMenuName);
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
