using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Star : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //TODO Add separate Script for Handling Collecting Items
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();

            if (rocketHealth)
            {
                rocketHealth.AddStar();
                Destroy(gameObject);
            }
        }

    } 
}
