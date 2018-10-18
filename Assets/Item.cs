using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        GameObject item;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Rocket rocket = collision.GetComponent<Rocket>();
            if (rocket)
            {
                rocket.AddItem(item);
                Destroy(gameObject);
            }
        }
    }

}