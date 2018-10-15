using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class SpawnArea : MonoBehaviour
    {
        [SerializeField]
        GameObject spawnAreaPrefab;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();

            if (rocketHealth)
            {
                Instantiate(spawnAreaPrefab).transform.position = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
            }

            Debug.Log("Spawning a new Spawn Area..");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();

            if (rocketHealth)
            {
                Debug.Log("Destroying Myself");
                Destroy(gameObject);
            }
        }
    } 
}
