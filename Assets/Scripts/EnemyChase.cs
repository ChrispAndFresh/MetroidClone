using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * Allows for big enemy to chase player when they enter trigger
 */

public class EnemyChase : MonoBehaviour
{
    bool chasingPlayer;
    GameObject player;


    /// <summary>
    /// If the player enters the trigger, set the big enemy to chase them
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            chasingPlayer = true;
            player = other.gameObject;
        }
    }


    /// <summary>
    /// When the player leaves the trigger, the enemy no longer chases the player 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            chasingPlayer = false;
            player = null;
        }
    }


    /// <summary>
    /// Returns value of chasingPlayer
    /// </summary>
    /// <returns>Returns true if player is inside the trigger
    /// Returns false if player is outside the trigger</returns>
    public bool ChasingPlayer()
    {
        return chasingPlayer;
    }

    /// <summary>
    /// Returns Player GameObject to get position
    /// </summary>
    /// <returns>Returns Player GameObject if player is in trigger
    /// Returns null if Player is outside of trigger</returns>
    public GameObject Player()
    {
        return player;
    }
}
