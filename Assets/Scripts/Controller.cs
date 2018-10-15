using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Controller : MonoBehaviour
    {
        public float travelSpeed;

        public float downspeed;

        Rigidbody2D rocketRB;

        // Use this for initialization
        void Start()
        {
            rocketRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            //rocketRB.AddForce(Vector2.up * travelSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rocketRB.velocity = new Vector2(1.0f * travelSpeed * Time.deltaTime, 1.0f * travelSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rocketRB.velocity = new Vector2(-1.0f * travelSpeed * Time.deltaTime, 1.0f * travelSpeed * Time.deltaTime);
            }
            else
            {
                rocketRB.velocity = Vector2.up * travelSpeed * Time.deltaTime;
            }
        }
    } 
}
