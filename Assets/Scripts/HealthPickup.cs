using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * Allows for picking up health 
 */

public class HealthPickup : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is overlapping is the player
        if (other.GetComponent<PlayerController>())
        {
            //Heals player
            other.GetComponent<PlayerController>().GetHealed(health);
            Destroy(gameObject);
        }
    }
}
