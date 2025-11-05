using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * When collected, player's bullets are upgrades to missiles
 */

public class MissileUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is overlapping is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Turns player bullets into missiles
            other.gameObject.GetComponent<PlayerController>().MissileUpgrade();
            Destroy(gameObject);
        }
    }
}
