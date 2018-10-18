using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class EDT : MonoBehaviour
    {

        float edtDuration = 10.0f;

        // Use this for initialization
        void Start()
        {
            Rocket rocket = GetComponentInParent<Rocket>();
            if (!rocket) { return; }

            StartCoroutine(TransferToEtherealDimension(edtDuration));
        }

        IEnumerator TransferToEtherealDimension(float duration)
        {
            Rocket rocket = GetComponentInParent<Rocket>();
            if (rocket)
            {
                rocket.GetComponent<PolygonCollider2D>().enabled = false;
                yield return new WaitForSeconds(duration);
                rocket.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }
    } 
}
