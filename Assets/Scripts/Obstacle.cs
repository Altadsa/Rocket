using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Obstacle : MonoBehaviour
    {
        protected Rigidbody2D obstacleRB;

        protected void Start()
        {
           obstacleRB = GetComponent<Rigidbody2D>();
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            Rocket rocket = collision.GetComponent<Rocket>();
            if (rocket)
            {
                rocket.DestroyRocket();
            }
        }

    } 
}
