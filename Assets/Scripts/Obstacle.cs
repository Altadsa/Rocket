using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Obstacle : MonoBehaviour
    {
        float speed = 100.0f;

        Rigidbody2D obstacleRB;

        private void Start()
        {
            obstacleRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            //obstacleRB.AddForce(Vector2.down * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            RocketHealth rocket = collision.GetComponent<RocketHealth>();
            if (rocket)
            {
                rocket.DestroyRocket();
            }
        }

    } 
}
