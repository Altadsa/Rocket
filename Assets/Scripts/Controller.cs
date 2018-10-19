
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Controller : MonoBehaviour
    {
        public float travelSpeed;

        Rigidbody2D rocketRB;

        Matrix4x4 baseMatrix = Matrix4x4.identity;

        void Start()
        {
            rocketRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MoveUsingAccelerometer();
        }

        public void Calibrate()
        {
            Quaternion rotate = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), Input.acceleration);

            Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotate, new Vector3(1.0f, 1.0f, 1.0f));

            this.baseMatrix = matrix.inverse;
        }

        public Vector3 AdjustedAccelerometer
        {
            get
            {
                return this.baseMatrix.MultiplyVector(Input.acceleration);
            }
        }

        private void MoveUsingAccelerometer()
        {
            if (AdjustedAccelerometer.x > 0.01f)
            {
                rocketRB.velocity = new Vector2(1.0f * travelSpeed * Time.deltaTime, 0.0f);
            }
            else if (AdjustedAccelerometer.x < 0.01f)
            {
                rocketRB.velocity = new Vector2(-1.0f * travelSpeed * Time.deltaTime, 0.0f);
            }
            else
            {
                rocketRB.velocity = Vector2.zero;
            }
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
