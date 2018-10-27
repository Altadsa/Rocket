using UnityEngine;

namespace Rocket
{
    public class MonsterObstacle : Obstacle
    {
        #region VARIABLES

        [SerializeField]
        Transform leftEdge;

        [SerializeField]
        Transform rightEdge;

        const float MIN_SPEED = 50.0f;
        const float MAX_SPEED = 200.0f;

        float speed;

        bool movingRight = true;

        #endregion

        #region UNITY_LIFECYCLE

        new private void Start()
        {
            base.Start();
            speed = Random.Range(MIN_SPEED, MAX_SPEED);
        }

        private void FixedUpdate()
        {
            MoveMonster();
        }

        new private void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            if (collision.GetComponent<ScreenEdge>())
            {
                movingRight = !movingRight;
            }
        }

        #endregion

        #region PRIVATE_FUNCTIONS

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

        #endregion

    } 
}
