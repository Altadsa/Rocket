using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Controller : MonoBehaviour
    {
        public float travelSpeed;

        Rigidbody2D rocketRB;

        void Start()
        {
            rocketRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MoveUsingArrowKeys();
        }

        private void MoveUsingArrowKeys()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rocketRB.velocity = new Vector2(1.0f * travelSpeed * Time.deltaTime, 0.0f);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rocketRB.velocity = new Vector2(-1.0f * travelSpeed * Time.deltaTime, 0.0f);
            }
            else
            {
                rocketRB.velocity = Vector2.zero;
            }
        }
    } 
}
