using UnityEngine;

namespace Rocket
{
    public class MonsterObstacle : MonoBehaviour
    {

        Rigidbody2D monsterRB;

        float speed = 100.0f;
        public float downspeed;
        bool movingRight;

        // Use this for initialization
        void Start()
        {
            movingRight = true;
            monsterRB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            MoveMonster();
        }

        private void MoveMonster()
        {
            if (movingRight)
            {
                monsterRB.velocity = Vector2.right * speed * Time.deltaTime;
            }
            else
            {
                monsterRB.velocity = Vector2.left * speed * Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            RocketHealth rocketHealth = collision.GetComponent<RocketHealth>();
            if (rocketHealth)
            {
                rocketHealth.DestroyRocket();
            }

            if (collision.GetComponent<ScreenEdge>())
            {
                movingRight = !movingRight;
            }
        }
    } 
}
