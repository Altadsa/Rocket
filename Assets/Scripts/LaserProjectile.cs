using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class LaserProjectile : MonoBehaviour
    {

        Rigidbody2D projectileRB;

        public float projectileSpeed;

        private void Start()
        {
            projectileRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            projectileRB.velocity = Vector2.up * projectileSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            if (obstacle)
            {
                Destroy(obstacle.gameObject);
                Destroy(gameObject);
            }
        }
    } 
}
