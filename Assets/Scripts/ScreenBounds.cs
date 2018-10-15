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
        Rigidbody2D playerRB;

        // Update is called once per frame
        void Update()
        {
            if (!playerRB)
            {
                return;
            }

            if (playerRB.transform.position.x < left.position.x)
            {
                if (playerRB.velocity.x < 0)
                {
                    playerRB.transform.position = new Vector2(right.position.x, playerRB.transform.position.y);
                }
            }
            else if (playerRB.transform.position.x > right.position.x)
            {
                if (playerRB.velocity.x > 0)
                {
                    playerRB.transform.position = new Vector2(left.position.x, playerRB.transform.position.y);
                }
            }
        }

    } 
}
