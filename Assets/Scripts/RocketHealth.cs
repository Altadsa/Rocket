using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class RocketHealth : MonoBehaviour
    {

        public void DestroyRocket()
        {
            Destroy(gameObject);
        }

    } 
}
