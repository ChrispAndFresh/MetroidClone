using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * Controls behavior of small enemies
 */

public class SmallEnemy : Enemy
{
    //References to left and right bounds of enemy
    public Transform leftPoint;
    public Transform rightPoint;

    //Sets left and right bounds of enemy
    private Vector3 startLeftPos;
    private Vector3 startRightPos;

    private Vector3 direction; //Enemy direction

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.left;
        startLeftPos = leftPoint.position;
        startRightPos = rightPoint.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    /// <summary>
    /// Moves the enemy left and right based off of set points
    /// </summary>
    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x <= startLeftPos.x)
        {
            direction = Vector3.right;
        }
        if (transform.position.x >= startRightPos.x)
        {
            direction = Vector3.left;
        }
    }
}
