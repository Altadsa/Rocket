using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class StaticObstacle : Obstacle
    {
        float timeCounter = 0;

        new private void Start()
        {
            base.Start();
            float randomRotationFloat = Random.Range(0, 90);
            transform.rotation = new Quaternion(randomRotationFloat, randomRotationFloat, 0.0f, 0.0f);
        }

        private void Update()
        {
            timeCounter += Time.deltaTime;

            float x = Mathf.Cos(timeCounter);
            float y = Mathf.Sin(timeCounter);
            float z = 0.0f;
            float w = 0.0f;

            transform.rotation = new Quaternion(x, y, z, w);
        }
    } 
}
