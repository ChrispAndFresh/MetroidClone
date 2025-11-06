using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel 
 * 11/6/25
 * When collected, player's bullets are upgrades to the spazer (like in metroid)
 */

public class SpazerUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is overlapping is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Turns player bullets into spazer
            other.gameObject.GetComponent<PlayerController>().SpazerUpgrade();
            Destroy(gameObject);
        }
    }
}
