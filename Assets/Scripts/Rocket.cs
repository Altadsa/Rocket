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
            levelManager.LoadLevel(mainMenuName);
        }

        public void AddItem(GameObject itemToAdd)
        {
            GameObject itemInstance = Instantiate(itemToAdd);
            itemInstance.transform.parent = transform; 
        }

        public void AddStar()
        {
            starsCollected++;
        }

    } 
}
