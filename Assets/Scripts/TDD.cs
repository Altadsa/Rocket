using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class TDD : MonoBehaviour
    {

        Rocket rocket;

        float effectDuration = 10.0f;

        float currentTime = 0;

        private void Start()
        {
            rocket = GetComponentInParent<Rocket>();
            if (!rocket) { return; }
            transform.position = rocket.transform.position;
            Time.timeScale = 0.5f;
        }

        private void Update()
        {
            currentTime += (Time.deltaTime * 2);
            if (currentTime >= effectDuration)
            {
                Time.timeScale = 1;
                Destroy(gameObject);
            }
        }

    } 
}
