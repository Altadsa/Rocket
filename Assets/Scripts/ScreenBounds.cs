using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class ScreenBounds : MonoBehaviour
    {
        [SerializeField]
        Transform left;

        [SerializeField]
        Transform right;

        [SerializeField]
        Controller player;

        [SerializeField]
        Rigidbody2D playerRB;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (player.transform.position.x < left.position.x)
            {
                if (playerRB.velocity.x < 0)
                {
                    player.transform.position = new Vector2(right.position.x, player.transform.position.y);
                }
            }
            else if (player.transform.position.x > right.position.x)
            {
                if (playerRB.velocity.x > 0)
                {
                    player.transform.position = new Vector2(left.position.x, player.transform.position.y);
                }
            }
        }

    } 
}
