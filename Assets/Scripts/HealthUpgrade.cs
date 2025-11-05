using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * When collected, upgrades the players max health and completely heals them
 */

public class HealthUpgrade : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is overlapping is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Increases player's max health
            other.gameObject.GetComponent<PlayerController>().HealthUpgrade(health);
            Destroy(gameObject);
        }
    }
}
