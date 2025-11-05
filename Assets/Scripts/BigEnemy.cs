using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * Controls behavior of Big Enemy
 */

public class BigEnemy : Enemy
{
    
    public EnemyChase enemyTrigger; //reference to the trigger that causes the enemy to chase the player
    private bool chasingPlayer; //Determines whether the enemy is chasing the player
    private GameObject player; //Used to get position of player to chase them


    // Start is called before the first frame update
    void Start()
    {
        chasingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        chasingPlayer = enemyTrigger.ChasingPlayer();
        player = enemyTrigger.Player();

        //If chasingPlayer is true, big enemy moves towards player's direction
        if (chasingPlayer)
        {
            //If the player is to the right, move the enemy right
            if (player.transform.position.x > transform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            //If the player is to the left, move the enemy left
            if (player.transform.position.x < transform.position.x)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }

    }

    

}

