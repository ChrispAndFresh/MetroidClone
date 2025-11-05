using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1; //How much health the enemy has
    public float speed = 5f; //How fast the enemy is
    public int enemyDamage = 15; //How much damage the enemy does to the player

   
    /// <summary>
    /// Allows the enemy to take damage
    /// If the enemy's health goes to zero or bellow, destroy the enemy
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamaged(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks if what is colliding is the player
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Damages the player
            collision.gameObject.GetComponent<PlayerController>().GetDamaged(enemyDamage);
        }
    }
}
