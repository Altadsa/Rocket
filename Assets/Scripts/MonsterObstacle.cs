using UnityEngine;

namespace Rocket
{
    public class MonsterObstacle : Obstacle
    {
        [SerializeField]
        Transform leftEdge;

        [SerializeField]
        Transform rightEdge;

        float speed = 100.0f;

        bool movingRight = true;

        // Use this for initialization

        private void FixedUpdate()
        {
            MoveMonster();
        }

        private void MoveMonster()
        {
            if (movingRight)
            {
                obstacleRB.velocity = Vector2.right * speed * Time.deltaTime;
            }
            else
            {
                obstacleRB.velocity = Vector2.left * speed * Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.GetComponent<ScreenEdge>())
            {
                movingRight = !movingRight;
            }
        }
    } 
}
