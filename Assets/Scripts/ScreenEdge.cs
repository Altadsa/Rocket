using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class ScreenEdge : MonoBehaviour
    {
        bool isInsideCollider;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(gameObject.name + " Triggered");
            isInsideCollider = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }

    } 
}
