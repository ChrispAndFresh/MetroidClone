using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * Template script for enemies containing health, damagae, and speed
 */

public class Enemy : MonoBehaviour
{
    public int health = 1; //How much health the enemy has
    public float speed = 5f; //How fast the enemy is
    public int enemyDamage = 15; //How much damage the enemy does to the player

    public GameObject healthDrop; //The enemy will drop a health pickup upon death
   
    /// <summary>
    /// Allows the enemy to take damage
    /// If the enemy's health goes to zero or bellow, destroy the enemy
    /// </summary>
    /// <param name="damage"></param>
    public virtual void GetDamaged(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false); //Disables enemy after death
            Instantiate(healthDrop, transform.position, transform.rotation);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Checks if what is colliding is the player
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Damages the player
            collision.gameObject.GetComponent<PlayerController>().GetDamaged(enemyDamage);
        }
    }
}
