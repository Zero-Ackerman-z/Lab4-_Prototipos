using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public bool isStatic = false;
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        if (!isStatic)
        {
            target = pointB.position;
        }
    }

    void Update()
    {
        if (isStatic) return; 

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthSystem>().TakeDamage(1);
        }
    }
}


