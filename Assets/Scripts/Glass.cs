using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/6/25
 * Allows for destructable walls if player has missiles
 */

public class Glass : MonoBehaviour
{
    //How much damage the player needs to do to destroy the wall
    public int health = 3;

    //If the player hits glass with a strong enough bullet, destroy glass
    public void Destroy(int damage)
    {
        if (damage >= health)
        {
            gameObject.SetActive(false);
        }
    }
}
