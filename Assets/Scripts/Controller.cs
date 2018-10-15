using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Controller : MonoBehaviour
    {
        public float travelSpeed;

        Rigidbody2D rocketRB;

        // Use this for initialization
        void Start()
        {
            rocketRB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            //rocketRB.AddForce(Vector2.up * travelSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rocketRB.velocity = Vector2.right * travelSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rocketRB.velocity = Vector2.left * travelSpeed * Time.deltaTime;
            }
            else
            {
                rocketRB.velocity = Vector2.zero;
            }
        }
    } 
}
