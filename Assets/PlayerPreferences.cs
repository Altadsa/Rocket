using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class PlayerPreferences : MonoBehaviour
    {

        public int GetStars()
        {
            return PlayerPrefs.GetInt("Stars");
        }

        public void AddStars(int amountToAdd)
        {
            int total = PlayerPrefs.GetInt("Stars") + amountToAdd;
            PlayerPrefs.SetInt("Stars", total);
        }
    } 
}
