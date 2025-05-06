using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovingObstacle : Obstacle
    {
        [SerializeField] private Vector2 pointA;
        [SerializeField] private Vector2 pointB;
        [SerializeField] private float speed = 2f;
        private bool goingToB = true;
        [SerializeField] private bool IsStatic; 
        private void Update()
        {
            if(!IsStatic)
            {
                Vector2 target = goingToB ? pointB : pointA;
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, target) < 0.1f)
                    goingToB = !goingToB;
            }
           
        }
    }
}